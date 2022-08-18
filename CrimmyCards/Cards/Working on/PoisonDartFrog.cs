//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using UnboundLib;
//using UnboundLib.Cards;
//using UnityEngine;
//using System.Runtime.CompilerServices;

//namespace CrimmyCards.Cards
//{
//    class PoisonDartFrog : CustomCard
//    {

//        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
//        {
//            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
//            statModifiers.health = 1.50f;
//            statModifiers.movementSpeed = 0.85f;
//            var saw = (GameObject)Resources.Load("4 map objects/MapObject_Saw_Stat");
//            var betterSaw = Instantiate(saw);
//            var explosiveBullet = (GameObject)Resources.Load("0 cards/Mayhem");
//            var A_ScreenEdge = explosiveBullet.GetComponent<Gun>().objectsToSpawn[0];
//            gun.objectsToSpawn = new[]
//            {
//                new ObjectsToSpawn()
//                {
//                    AddToProjectile = betterSaw
//                },
//                A_ScreenEdge
//            };
//        }
//        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
//        {
//            player.gameObject.GetOrAddComponent<Gun>().GetComponent<RayHitPoison>().enabled = true;
//            player.gameObject.GetOrAddComponent<Gun>().GetComponent<RayHitPoison>().time = 2f;
//            player.gameObject.GetOrAddComponent<Gun>().GetComponent<RayHitPoison>().interval = 0.5f;

//            //Edits values on player when card is selected
//        }
//        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
//        {
//            //Run when the card is removed from the player
//        }

//        protected override string GetTitle()
//        {
//            return "Poison Dart Frog";
//        }
//        protected override string GetDescription()
//        {
//            return "This is a frightening frog. That's a poisonous frog! If he strikes someone, they will be poisoned!";
//        }
//        protected override GameObject GetCardArt()
//        {
//            return null;
//        }
//        protected override CardInfo.Rarity GetRarity()
//        {
//            return CardInfo.Rarity.Rare;
//        }
//        protected override CardInfoStat[] GetStats()
//        {
//            return new CardInfoStat[]
//            {
//                new CardInfoStat()
//                {
//                    positive = true,
//                    stat = "health",
//                    amount = "+50%",
//                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
//                },
//                new CardInfoStat()
//                {
//                    positive = true,
//                    stat = "Poison",
//                    amount = "3 seconds",
//                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
//                },
//                new CardInfoStat()
//                {
//                    positive = false,
//                    stat = "Movement Speed",
//                    amount = "-15%",
//                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
//                }
//            };
//        }
//        protected override CardThemeColor.CardThemeColorType GetTheme()
//        {
//            return CardThemeColor.CardThemeColorType.ColdBlue;
//        }
//        public override string GetModName()
//        {
//            return CrimmyCards.ModInitials;
//        }
//    }
//}