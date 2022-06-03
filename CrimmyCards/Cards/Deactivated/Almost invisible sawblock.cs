//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using UnboundLib;
//using UnboundLib.Cards;
//using UnityEngine;
//using CrimmyCards.MonoBehaviours;
//using Photon.Pun;
//using UnityEngine.Events;
//using CrimmyCards.Extensions;

//namespace CrimmyCards.Cards
//{
//    public class Almost_invisible_sawblock : CustomCard
//    {
//        int sawCount = 0;
//        private GameObject sawObj;
//        Boolean stopforce = false;
//        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
//        {
//            cardInfo.allowMultiple = false;
//            block.forceToAddUp = 10;
//            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
//            UnityEngine.Debug.Log($"[{CrimmyCards.ModInitials}][Card] {GetTitle()} has been setup.");
//        }
//        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
//        {
//            player.gameObject.AddComponent<AlmostInvisiblesawblock_Mono>();
//            sawObj = new GameObject("saw");
//            sawObj.AddComponent<CrimmyCardsMonoBehaviour>();
//            var jump = sawObj.AddComponent<PlayerDoJump>();
//            jump.multiplier = 1;
//            var trigger = sawObj.AddComponent<BlockTrigger>();
//            trigger.blockRechargeEvent = new UnityEvent();
//            trigger.successfulBlockEvent = new UnityEvent();
//            trigger.triggerSuperFirstBlock = new UnityEvent();
//            trigger.triggerFirstBlockThatDelaysOthers = new UnityEvent();
//            trigger.triggerEventEarly = new UnityEvent();
//            trigger.triggerEvent = new UnityEvent();
//            trigger.triggerEvent.AddListener(() =>
//            {
//                if (PhotonNetwork.IsMasterClient)
//                {

//                    PhotonNetwork.Instantiate("4 map objects/MapObject_Saw_Stat", player.transform.position, Quaternion.identity);
//                    var scale = jump.transform.parent.transform.localScale;
//                    jump.ExecuteAfterSeconds(0.08f, () =>
//                    {
//                        var parent = jump.transform.parent;
//                        parent.GetComponent<PhotonView>().RPC("RPCA_FixBox", RpcTarget.All);
//                        parent.GetComponent<PhotonView>().RPC("RPCA_BigBox", RpcTarget.All);
//                    });
//                    jump.ExecuteAfterSeconds(0.15f, () =>
//                    {
//                        var parent = jump.transform.parent;
//                        parent.GetComponent<PhotonView>().RPC("RPCA_FixBox", RpcTarget.All);
//                    });

//                    sawCount++;
//                }
//                // var rem = box.AddComponent<RemoveAfterSeconds>();
//                // rem.seconds = 4;

//            });
//            sawObj.transform.SetParent(player.gameObject.transform);

//            //Edits values on player when card is selected
//            UnityEngine.Debug.Log($"[{CrimmyCards.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
//        }
//        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
//        {
//            //Run when the card is removed from the player
//            DestroyImmediate(sawObj);
//            UnityEngine.Debug.Log($"[{CrimmyCards.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
//        }

//        protected override string GetTitle()
//        {
//            return "Almost invisible saw block";
//        }
//        protected override string GetDescription()
//        {
//            return "You spawn very very small saws when you block";
//        }
//        protected override GameObject GetCardArt()
//        {
//            return CrimmyCards.SawBlockArt;
//        }
//        protected override CardInfo.Rarity GetRarity()
//        {
//            return CardInfo.Rarity.Uncommon;
//        }
//        protected override CardInfoStat[] GetStats()
//        {
//            return new CardInfoStat[]
//            {
//                new CardInfoStat()
//                {
//                    positive = true,
//                    stat = "super Small Saw blocks",
//                    amount = "infinite",
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