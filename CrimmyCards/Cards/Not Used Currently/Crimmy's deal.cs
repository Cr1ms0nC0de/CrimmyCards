using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using CrimmyCards.MonoBehaviours;
using Photon.Pun;
using UnityEngine.Events;
using CrimmyCards.Extensions;
using HarmonyLib;

namespace CrimmyCards.Cards
{
    public class Crimmys_Deal : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            cardInfo.allowMultiple = false;
            block.autoBlock = true;
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
            UnityEngine.Debug.Log($"[{CrimmyCards.ModInitials}][Card] {GetTitle()} has been setup.");
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            var mono = player.gameObject.GetOrAddComponent<SquishEffect>();
            player.gameObject.AddComponent<QuickReflexesEffect>();
            //var mono2 = player.gameObject.GetOrAddComponent<Shoot_Block_Mono>();
            //Edits values on player when card is selected
            UnityEngine.Debug.Log($"[{CrimmyCards.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Run when the card is removed from the player
            var mono = player.gameObject.GetOrAddComponent<SquishEffect>();
            UnityEngine.GameObject.Destroy(mono);
            UnityEngine.Debug.Log($"[{CrimmyCards.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
        }

        protected override string GetTitle()
        {
            return "Squish block";
        }
        protected override string GetDescription()
        {
            return "you auto block, but at what cost";
        }
        protected override GameObject GetCardArt()
        {
            return null;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Uncommon;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Random teleporting",
                    amount = "more",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.ColdBlue;
        }
        public override string GetModName()
        {
            return CrimmyCards.ModInitials;
        }
    }
    public class QuickReflexesEffect : MonoBehaviour
    {
        // blank mono which just marks the player as being able to autoblock
    }
    // necessary patches

    // these patches were not running previously when put inside QuickReflexesEffect
    // organizing them this way causes them to run properly

    [HarmonyPatch(typeof(Block), "ResetStats")]
    class BlockPatchResetStats
    {
        static void PostFix(Block __instance)
        {
            var quickReflexesEffect = __instance.GetComponent<QuickReflexesEffect>();
            if (quickReflexesEffect != null)
            {
                GameObject.Destroy(quickReflexesEffect);
            }
        }
    }
    [HarmonyPatch(typeof(ProjectileHit), "RPCA_DoHit")]
    [HarmonyPriority(Priority.First)]
    class ProjectileHitPatchRPCA_DoHit
    {
        private static void Prefix(ProjectileHit __instance, Vector2 hitPoint, Vector2 hitNormal, Vector2 vel, int viewID, int colliderID, ref bool wasBlocked)
        {
            // prefix to allow autoblocking

            HitInfo hitInfo = new HitInfo();
            hitInfo.point = hitPoint;
            hitInfo.normal = hitNormal;
            hitInfo.collider = null;
            if (viewID != -1)
            {
                PhotonView photonView = PhotonNetwork.GetPhotonView(viewID);
                hitInfo.collider = photonView.GetComponentInChildren<Collider2D>();
                hitInfo.transform = photonView.transform;
            }
            else if (colliderID != -1)
            {
                hitInfo.collider = MapManager.instance.currentMap.Map.GetComponentsInChildren<Collider2D>()[colliderID];
                hitInfo.transform = hitInfo.collider.transform;
            }
            HealthHandler healthHandler = null;
            if (hitInfo.transform)
            {
                healthHandler = hitInfo.transform.GetComponent<HealthHandler>();
            }
            if (healthHandler && healthHandler.GetComponent<CharacterData>() && healthHandler.GetComponent<Block>())
            {
                Block block = healthHandler.GetComponent<Block>();
                if (healthHandler.GetComponent<QuickReflexesEffect>() != null && block.counter >= block.Cooldown())
                {
                    wasBlocked = true;
                    if (healthHandler.GetComponent<CharacterData>().view.IsMine) { block.TryBlock(); }
                }
            }
        }
    }
}