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
namespace CrimmyCards.Cards
{
    class Pufferfish : CustomCard
    {
        //private static MonoBehaviours.Puff puff_effect = new Puff();
        //PufferfishArt pufferfish;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            cardInfo.allowMultiple = false;
            statModifiers.health = 3.0f;
            UnityEngine.Debug.Log($"[{CrimmyCards.ModInitials}][Card] {GetTitle()} has been setup.");
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            HealthBasedEffect effect = player.gameObject.GetOrAddComponent<HealthBasedEffect>();
            //pufferfish = player.gameObject.AddComponent<PufferfishArt>();
            effect.characterStatModifiersModifier.sizeMultiplier_mult = 1.2f;
            effect.characterStatModifiersModifier.gravity_mult = 1.5f;
            effect.blockModifier.additionalBlocks_add = 1;
            effect.blockModifier.cdAdd_add -= 0.25f;
            effect.SetPercThresholdMax(0.999f);
            //puff_effect = player.gameObject.AddComponent<MonoBehaviours.Puff>();
            UnityEngine.Debug.Log($"[{CrimmyCards.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            HealthBasedEffect effect = player.gameObject.GetOrAddComponent<HealthBasedEffect>();
            UnityEngine.GameObject.Destroy(effect);
            UnityEngine.Debug.Log($"[{CrimmyCards.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
        }

        protected override string GetTitle()
        {
            return "Pufferfish";
        }
        protected override string GetDescription()
        {
            return "You puff up when damaged. Stats only apply when damaged, excluding health";
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
                    stat = "Health",
                    amount = "+200%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Blocks",
                    amount = "+1",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Block Cooldown",
                    amount = "-0.25s",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Size",
                    amount = "+50%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Gravity",
                    amount = "+20%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Movement Speed",
                    amount = "-20%",
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