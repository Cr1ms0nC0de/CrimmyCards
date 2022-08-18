using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using BepInEx;
using UnboundLib.Cards;
using UnityEngine;
using ModdingUtils.MonoBehaviours;
using TemporaryStatsPatch;
using CrimmyCards.MonoBehaviours;
using CrimmyCards.TempEffects;
using ClassesManagerReborn.Util;
using CrimmyCards.Extensions;
using CrimmyCards.Utils;

namespace CrimmyCards.Cards.Pufferfish
{
    class poisonousSpikes : CustomCard
    {
        //private static MonoBehaviours.Puff puff_effect = new Puff();
        //PufferfishArt pufferfish;
        private float poisonDuration = 2f;
        private float poisonInterval = 0.8f;
        internal static CardInfo Card = null;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            //cardInfo.allowMultiple = false;

            //statModifiers.health = 3.0f;
            UnityEngine.Debug.Log($"[{CrimmyCards.ModInitials}][Card] {GetTitle()} has been setup.");
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //player.gameObject.GetOrAddComponent<Thorns>();
            characterStats.GetAdditionalData().poison = true;
            characterStats.GetAdditionalData().poisonDuration += poisonDuration;
            characterStats.GetAdditionalData().poisonInterval *= poisonInterval;

            UnityEngine.Debug.Log($"[{CrimmyCards.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            if (player.gameObject.GetComponent<Thorns>() != null)
            {
                int count = 0;
                
                characterStats.GetAdditionalData().poisonDuration -= poisonDuration;
                characterStats.GetAdditionalData().poisonInterval /= poisonInterval;
                
                foreach (var card in player.data.currentCards.Where((cardInfo) => cardInfo.cardName.ToLower() == "Poisonous Spikes".ToLower()))
                {
                    count++;
                }
                if (count == 1)
                {
                    characterStats.GetAdditionalData().poison = false;
                }
            }
            UnityEngine.Debug.Log($"[{CrimmyCards.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
        }

        protected override string GetTitle()
        {
            return "Poisonous Spikes";
        }
        protected override string GetDescription()
        {
            return "Thorns inflict damage over time to targets";
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
                    positive = true,
                    stat = "Poison Thorns Interval",
                    amount = "-20%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Poison Thorns Duration",
                    amount = "+2s",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.DefensiveBlue;
        }
        public override string GetModName()
        {
            return CrimmyCards.ModInitials;
        }
        public override void Callback()
        {
            gameObject.GetOrAddComponent<ClassNameMono>().className = pufferfishClass.name;
        }
    }
}