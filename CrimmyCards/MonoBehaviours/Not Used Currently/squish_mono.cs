using UnityEngine;
using ModdingUtils.MonoBehaviours;
using UnboundLib.Cards;
using UnboundLib;
using ModdingUtils.Extensions;
using System;
using System.Collections.Generic;
using CrimmyCards.Cards;

namespace CrimmyCards.MonoBehaviours
{
    internal class SquishEffect : ReversibleEffect
    {
        private float duration = 0;
        System.Random rnd = new System.Random();
        static int x;
        static int y;
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
            duration = 1f;
            ColorEffect effect = player.gameObject.AddComponent<ColorEffect>();
            effect.SetColor(Color.white);
        }

        public override void OnStart()
        {
            block.BlockAction = (Action<BlockTrigger.BlockTriggerType>)Delegate.Combine(block.BlockAction, new Action<BlockTrigger.BlockTriggerType>(OnBlock));
            SetLivesToEffect(int.MaxValue);
        }
        public override void OnUpdate()
        {
            if (!(duration <= 0))
            {
                duration -= TimeHandler.deltaTime;
                //player.transform.localScale = new Vector3((float)player.transform.localScale.x * 2, (float)player.transform.localScale.y / 2);
                //x = rnd.Next((-Screen.width / 2) + (int)player.transform.localScale.x, (Screen.width / 2) - (int)player.transform.localScale.x);
                //y = rnd.Next((-Screen.height / 2) + (int)player.transform.localScale.y, (Screen.height / 2) + (int)player.transform.localScale.y);
                x = rnd.Next(-15, 15 + 1);
                y = rnd.Next(-15, 15 + 1);
                player.transform.localPosition = new Vector3(x, y);
            }
            else
            {
                ClearModifiers();
                UnityEngine.GameObject.Destroy(this.gameObject.GetOrAddComponent<ColorEffect>());
            }
        }
    }
}
