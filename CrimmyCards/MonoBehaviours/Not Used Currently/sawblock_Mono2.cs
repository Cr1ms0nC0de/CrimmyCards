using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Events;
using ModdingUtils.MonoBehaviours;
using TemporaryStatsPatch;
using HarmonyLib;
using BepInEx;
using UnboundLib.Cards;
using UnboundLib;

namespace CrimmyCards.MonoBehaviours
{
    internal class Sawblock_Mono2 : ReversibleEffect
    {
        private float duration = 0;
        public GameObject pog;
        public override void OnOnDestroy()
        {
            block.BlockAction = (Action<BlockTrigger.BlockTriggerType>)Delegate.Remove(block.BlockAction, new Action<BlockTrigger.BlockTriggerType>(OnBlock));
        }
        private void OnBlock(BlockTrigger.BlockTriggerType trigger)
        {
            if (duration <= 0)
            {
                ApplyModifiers();
            }
            duration = 3f;
            ColorEffect effect = player.gameObject.AddComponent<ColorEffect>();
            effect.SetColor(Color.red);
        }
        [PunRPC]
        public override void OnStart()
        {
            var currentObj = MapManager.instance.currentMap.Map.gameObject.transform.GetChild(MapManager.instance.currentMap.Map.gameObject.transform.childCount - 1);
            var rigid = currentObj.GetComponent<Rigidbody2D>();
            pog = currentObj.GetComponent<GameObject>();
            rigid.isKinematic = false;
            rigid.simulated = true;
            block.BlockAction = (Action<BlockTrigger.BlockTriggerType>)Delegate.Combine(block.BlockAction, new Action<BlockTrigger.BlockTriggerType>(OnBlock));
            SetLivesToEffect(int.MaxValue);
        }
        public override void OnUpdate()
        {
            if (!(duration <= 0))
            {
                duration -= TimeHandler.deltaTime;
                //data.healthHandler.Heal(0.2f);
            }
            else
            {
                ClearModifiers();
                UnityEngine.GameObject.Destroy(this.gameObject.GetOrAddComponent<ColorEffect>());
                Destroy(pog);
            }
        }
        [PunRPC]
        public void RPCA_FixBox()
        {
            //currentObj.GetComponent<DamageBox>().damage = 1;
            //currentObj.GetComponent<DamagableEvent>().deathEvent = new UnityEvent();
            //currentObj.GetComponent<DamagableEvent>().deathEvent.AddListener(() =>
            //{
            //    Destroy(currentObj.gameObject);
            //});

        }

        [PunRPC]
        public void RPCA_BigBox()
        {
            var currentObj = MapManager.instance.currentMap.Map.gameObject.transform.GetChild(MapManager.instance.currentMap.Map.gameObject.transform.childCount - 1);
            currentObj.transform.localScale *= 1.5f;
            //currentObj.transform.localScale *= 0.1f;
        }
    }
}
