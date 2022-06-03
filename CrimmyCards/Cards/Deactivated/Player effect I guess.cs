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
    class Player_effect_I_guess : CustomCard
    {
        System.Random random = new System.Random();
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            int rand = random.Next(9);
            switch (rand)
            {
                case 0:
                    statModifiers.health = 1.2f;
                    break;
                case 1:
                    statModifiers.jump = 1.2f;
                    break;
                case 2:
                    statModifiers.lifeSteal = 1.2f;
                    break;
                case 3:
                    statModifiers.movementSpeed = 1.2f;
                    break;
                case 4:
                    statModifiers.numberOfJumps += 1;
                    break;
                case 5:
                    statModifiers.regen += 3;
                    break;
                case 6:
                    statModifiers.respawns += 1;
                    break;
                case 7:
                    statModifiers.sizeMultiplier = 0.8f;
                    break;
                case 8:
                    statModifiers.secondsToTakeDamageOver = 1.2f;
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
            return "Player effect I guess";
        }
        protected override string GetDescription()
        {
            return "You get something player related randomly every round";
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
                    stat = "Player Effect",
                    amount = "+20%, -20%, +1. or +3",
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