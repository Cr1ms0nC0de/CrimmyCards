using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;

namespace CrimmyCards.Cards
{
    class Gun_Effect_I_guess : CustomCard
    {
        System.Random random = new System.Random();
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            int rand = random.Next(13);
            switch (rand)
            {
                case 0:
                    gun.reflects += 1;
                    break;
                case 1:
                    gun.ammo += 1;
                    break;
                case 2:
                    gun.attackSpeed = 1.2f;
                    break;
                case 3:
                    gun.bursts += 1;
                    break;
                case 4:
                    gun.damage = 1.2f;
                    break;
                case 5:
                    gun.damageAfterDistanceMultiplier = 1.2f;
                    break;
                case 6:
                    gun.dmgMOnBounce = 1.2f;
                    break;
                case 7:
                    gun.explodeNearEnemyDamage = 1.2f;
                    gun.explodeNearEnemyRange = 1.2f;
                    break;
                case 8:
                    gun.knockback = 1.2f;
                    break;
                case 9:
                    gun.numberOfProjectiles += 1;
                    break;
                case 10:
                    gun.projectileSize = 1.2f;
                    break;
                case 11:
                    gun.projectileSpeed = 1.2f;
                    break;
                case 12:
                    gun.reloadTime = 0.8f;
                    break;
            }
            UnityEngine.Debug.Log($"[{CrimmyCards.ModInitials}][Card] {GetTitle()} has been setup.");
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            UnityEngine.Debug.Log($"[{CrimmyCards.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            UnityEngine.Debug.Log($"[{CrimmyCards.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
        }

        protected override string GetTitle()
        {
            return "Gun effect I guess";
        }
        protected override string GetDescription()
        {
            return "You get something gun related";
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
                    stat = "Gun Effect",
                    amount = "+20%, -20%, or +1",
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