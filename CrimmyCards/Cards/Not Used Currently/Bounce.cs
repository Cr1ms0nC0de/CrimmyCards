using System;
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
    class Bounce : CustomCard
    {
        private GameObject sawObj;
        System.Random rnd = new System.Random();
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
            block.cdAdd = 0.01f;
            
            UnityEngine.Debug.Log($"[{CrimmyCards.ModInitials}][Card] {GetTitle()} has been setup.");
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Edits values on player when card is selected
            ObjectsToSpawn item = ((GameObject)Resources.Load("0 cards/Mayhem")).GetComponent<Gun>().objectsToSpawn[0];
            List<ObjectsToSpawn> list = gun.objectsToSpawn.ToList<ObjectsToSpawn>();
            list.Add(item);
            gun.objectsToSpawn = list.ToArray();
            var trigger = sawObj.AddComponent<BlockTrigger>();
            trigger.blockRechargeEvent = new UnityEvent();
            trigger.successfulBlockEvent = new UnityEvent();
            trigger.triggerSuperFirstBlock = new UnityEvent();
            trigger.triggerFirstBlockThatDelaysOthers = new UnityEvent();
            trigger.triggerEventEarly = new UnityEvent();
            trigger.triggerEvent = new UnityEvent();
            trigger.triggerEvent.AddListener(() =>
            {
                if (PhotonNetwork.IsMasterClient)
                {
                    int x = rnd.Next(-100, 100);
                    int y = rnd.Next(-100, 100);
                    player.transform.AddXPosition(x);
                    player.transform.AddYPosition(y);
                    //PhotonNetwork.Instantiate("4 map objects/MapObject_Saw_Stat", player.transform.position, Quaternion.identity);
                    //var scale = jump.transform.parent.transform.localScale;

                }
                // var rem = box.AddComponent<RemoveAfterSeconds>();
                // rem.seconds = 4;

            });
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Run when the card is removed from the player
            UnityEngine.Debug.Log($"[{CrimmyCards.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
        }

        protected override string GetTitle()
        {
            return "Bounce";
        }
        protected override string GetDescription()
        {
            return "CardDescription";
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