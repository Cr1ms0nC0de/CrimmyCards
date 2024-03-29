﻿using System;
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
using CardChoiceSpawnUniqueCardPatch.CustomCategories;
namespace CrimmyCards.Cards
{
    public class Hook_shot : CustomCard
    {

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            cardInfo.allowMultiple = false;
            gun.knockback = -5.0f;
            gun.ammo = 7;
            gun.gravity = 0.5f;
            gun.numberOfProjectiles = 4;
            gun.reloadTimeAdd = 0.25f;
            gun.projectileSpeed = 1.5f;
            gun.damage = 0.7f;
            gun.spread = .2f;
            gun.evenSpread = .5f;
            gun.destroyBulletAfter = 0.25f;
            //gun.timeBetweenBullets = 0.25f;
            UnityEngine.Debug.Log($"[{CrimmyCards.ModInitials}][Card] {GetTitle()} has been setup.");
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //var mono = player.gameObject.AddComponent<Shoot_Block_Mono>();
            
            characterStats.GetAdditionalData().recoil -= 5.0f;
            //Edits values on player when card is selected

            //characterStats.GetAdditionalData().recoil = -100;
            UnityEngine.Debug.Log($"[{CrimmyCards.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Run when the card is removed from the player
            //var mono = player.gameObject.AddComponent<Shoot_Block_Mono>();
            //UnityEngine.GameObject.Destroy(mono);
            UnityEngine.Debug.Log($"[{CrimmyCards.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
        }

        protected override string GetTitle()
        {
            return "Hook shot";
        }
        protected override string GetDescription()
        {
            return "A shotgun that is also somehow a grappling hook";
        }
        protected override GameObject GetCardArt()
        {
            return null;
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
                    stat = "Ammo",
                    amount = "+7",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Bullets",
                    amount = "+4",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Bullet Speed",
                    amount = "+50%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "knockback",
                    amount = "-400%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "recoil",
                    amount = "-400%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Damage",
                    amount = "-30%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "reload time",
                    amount = "+0.25s",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.TechWhite;
        }
        public override string GetModName()
        {
            return CrimmyCards.ModInitials;
        }
    }
}