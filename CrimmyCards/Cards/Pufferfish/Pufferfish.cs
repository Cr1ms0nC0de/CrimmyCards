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
    class Pufferfish : CustomCard
    {
        //private static MonoBehaviours.Puff puff_effect = new Puff();
        //PufferfishArt pufferfish;
        private float thorns_damage = 0.25f;
        internal static CardInfo Card = null;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            cardInfo.allowMultiple = false;
            gameObject.GetOrAddComponent<ClassNameMono>();

            //statModifiers.health = 3.0f;
            UnityEngine.Debug.Log($"[{CrimmyCards.ModInitials}][Card] {GetTitle()} has been setup.");
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            player.gameObject.GetOrAddComponent<Thorns>();
            characterStats.GetAdditionalData().damage_percent += thorns_damage;   

            UnityEngine.Debug.Log($"[{CrimmyCards.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            if (player.gameObject.GetComponent<Thorns>() != null)
            {
                //var thorns_damage = player.gameObject.GetComponent<Thorns>();
                characterStats.GetAdditionalData().damage_percent -= thorns_damage;
                if (characterStats.GetAdditionalData().damage_percent <= 0)
                {
                    Destroy(player.gameObject.GetComponentInChildren<Thorns>());
                }
            }
            UnityEngine.Debug.Log($"[{CrimmyCards.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
        }

        protected override string GetTitle()
        {
            return "Pufferfish";
        }
        protected override string GetDescription()
        {
            return "Pufferfish";
        }
        protected override GameObject GetCardArt()
        {
            return CrimmyCards.PufferfishArt;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Rare;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Thorns",
                    amount = "+25%",
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
            gameObject.GetOrAddComponent<ClassNameMono>();
        }
    }
}