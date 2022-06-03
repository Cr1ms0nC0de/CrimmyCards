using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using CrimmyCards.MonoBehaviours;

namespace CrimmyCards.Cards
{
    class Portal_Gun : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            cardInfo.allowMultiple = false;
            gun.reloadTimeAdd = 0.1f;
            gun.reflects = 2;

            var portal = (GameObject)Resources.Load("4 map objects/Box_Destructible");
            var spriteRen = portal.GetComponent<SpriteRenderer>();
            var obj = new GameObject();
            obj.transform.position = new Vector3(1000, 0, 0);
            obj.transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
            var rendrer = obj.AddComponent<SpriteRenderer>();
            rendrer.sprite = spriteRen.sprite;
            rendrer.color = spriteRen.color;
            obj.AddComponent<RotateBullet>();
            var sf = obj.AddComponent<SFPolygon>();
            sf.verts = spriteRen.GetComponent<SFPolygon>().verts;
            sf._looped = true;
            sf.shadowLayers = -1;
            sf.opacity = 1;

            gun.objectsToSpawn = new[]
            {
                new ObjectsToSpawn()
                {
                    AddToProjectile = obj
                }
            };
            UnityEngine.Debug.Log($"[{CrimmyCards.ModInitials}][Card] {GetTitle()} has been setup.");
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            player.gameObject.GetOrAddComponent<PortalGun_Mono>();
            //ObjectsToSpawn item = ((GameObject)Resources.Load("0 cards/Mayhem")).GetComponent<Gun>().objectsToSpawn[0];
            //List<ObjectsToSpawn> list = gun.objectsToSpawn.ToList<ObjectsToSpawn>();
            //list.Add(item);
            //gun.objectsToSpawn = list.ToArray();
            UnityEngine.Debug.Log($"[{CrimmyCards.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Run when the card is removed from the player
            UnityEngine.Debug.Log($"[{CrimmyCards.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
        }

        protected override string GetTitle()
        {
            return "Portal gun";
        }
        protected override string GetDescription()
        {
            return "The cake is a lie";
        }
        protected override GameObject GetCardArt()
        {
            return null;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Common;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Effect",
                    amount = "No",
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
}