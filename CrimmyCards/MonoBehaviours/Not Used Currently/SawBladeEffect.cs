using UnityEngine;
using ModdingUtils.MonoBehaviours;
using UnboundLib.Cards;
using UnboundLib;
using ModdingUtils.Extensions;
using System;
using System.Collections.Generic;
using CrimmyCards.Cards;
using Photon.Pun;
using UnityEngine.SceneManagement;

namespace CrimmyCards.MonoBehaviours
{
    internal class SawBladeEffect : ReversibleEffect
    {
        private float duration = 0;
        public bool doEffect;
        public override void OnOnDestroy()
        {
            block.BlockAction = (Action<BlockTrigger.BlockTriggerType>)Delegate.Remove(block.BlockAction, new Action<BlockTrigger.BlockTriggerType>(OnBlock));
        }
        public void OnBlock(BlockTrigger.BlockTriggerType trigger)
        {
            if (doEffect)
            {
                ApplyModifiers();
                GetComponent<PhotonView>().RPC("RPCA_SpawnSaw_Stat", RpcTarget.All, player.transform.position, 1f /*Sawblade scale*/);
            }
            duration = 3f;
            ColorEffect effect = player.gameObject.AddComponent<ColorEffect>();
            effect.SetColor(Color.magenta);
        }

        public override void OnStart()
        {
            block.BlockAction = (Action<BlockTrigger.BlockTriggerType>)Delegate.Combine(block.BlockAction, new Action<BlockTrigger.BlockTriggerType>(OnBlock));
            SetLivesToEffect(int.MaxValue);
        }
        [PunRPC]
        //public void RPCA_SpawnSaw_Stat(Vector2 position, float scale)
        //{
        //    var saw = Instantiate(CrimmyCards.instance.betterSawObj, position, Quaternion.identity);
        //    saw.GetComponent<DamageBox>().damage = 27 * scale;
        //    saw.transform.localScale = new Vector3(scale, scale);
        //    saw.transform.SetParent(SceneManager.GetSceneAt(1).GetRootGameObjects()[0].transform);
        //    var rem = saw.AddComponent<RemoveAfterSeconds>();
        //    rem.seconds = 4.5f;
        //}
        public override void OnUpdate()
        {
            if (!(duration <= 0))
            {
                duration -= TimeHandler.deltaTime;
                data.healthHandler.Heal(0.2f);
            }
            else
            {
                ClearModifiers();
                UnityEngine.GameObject.Destroy(this.gameObject.GetOrAddComponent<ColorEffect>());
            }
        }
    }
}
