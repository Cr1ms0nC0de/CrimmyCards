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
using RarityLib.Utils;
using RarityLib;
namespace CrimmyCards.Cards
{
    class BattleOfGods : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            cardInfo.allowMultiple = false;
            UnityEngine.Debug.Log($"[{CrimmyCards.ModInitials}][Card] {GetTitle()} has been setup.");
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            foreach (Player otherPlayer in PlayerManager.instance.players)
            {
                if (otherPlayer.playerID != player.playerID)
                {
                    otherPlayer.gameObject.GetOrAddComponent<OPMono.GodsMono>();
                }
            }

            data.maxHealth *= 15.0f;
            characterStats.sizeMultiplier *= 0.57f;
            UnityEngine.Debug.Log($"[{CrimmyCards.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            UnityEngine.Debug.Log($"[{CrimmyCards.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
        }

        protected override string GetTitle()
        {
            return "Battle of The Gods";
        }
        protected override string GetDescription()
        {
            return "Two primordial forces locked in eternal combat.";
        }
        protected override GameObject GetCardArt()
        {
            return CrimmyCards.BattleOfGodsArt;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return RarityUtils.GetRarity("Galactic");
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]{
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Other players health",
                    amount = "*7.5",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Your health",
                    amount = "*15",
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
    }
}