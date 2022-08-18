﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using CrimmyCards.Extensions;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using UnityEngine;

namespace CrimmyCards.Cards.Testing
{
    class TestingCard : CustomCard
    {
        public void RemoveTestingCards(Player player)
        {
            CrimmyCards.instance.ExecuteAfterFrames(25, () => {
                List<CardInfo> testCards = new List<CardInfo>();
                foreach (var card in player.data.currentCards)
                {
                    if (card.categories.Contains(CrimmyCards.TestCardCategory))
                    {
                        testCards.Add(card);
                    }
                }

                ModdingUtils.Utils.Cards.instance.RemoveCardsFromPlayer(player, testCards.ToArray(), ModdingUtils.Utils.Cards.SelectionType.All, true);
            });
        }

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            cardInfo.categories = new CardCategory[] { CrimmyCards.TestCardCategory };
            //CrimmyCards.instance.DebugLog($"[{CrimmyCards.ModInitials}][Card] {GetTitle()} Built");
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {

            //WillsWackyCards.instance.DebugLog($"[{WillsWackyCards.ModInitials}][Card] {GetTitle()} Added to Player {player.playerID}");
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //WillsWackyCards.instance.DebugLog($"[{WillsWackyCards.ModInitials}][Card] {GetTitle()} removed from Player {player.playerID}");
        }

        protected override string GetTitle()
        {
            return "Card Name";
        }
        protected override string GetDescription()
        {
            return "Card Description";
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
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.TechWhite;
        }
        public override string GetModName()
        {
            return CrimmyCards.TestingInitials;
        }
        public override bool GetEnabled()
        {
            return true;
        }
    }
}