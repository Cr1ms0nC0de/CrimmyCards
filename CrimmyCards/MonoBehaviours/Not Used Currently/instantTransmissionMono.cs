using ModdingUtils.MonoBehaviours;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnboundLib.Cards;
using UnboundLib;
using ModdingUtils.Extensions;
using CrimmyCards.Cards;

namespace CrimmyCards.MonoBehaviours
{
	internal class InstantTransmissionMono : ReversibleEffect
	{
		public Player _player;
        private float duration = 0;
        public override void OnOnDestroy()
        {
            block.BlockAction = (Action<BlockTrigger.BlockTriggerType>)Delegate.Remove(block.BlockAction, new Action<BlockTrigger.BlockTriggerType>(OnBlock));
        }
        //public void AttackAction() { this._player.data.block.TryBlock(); }
        public override void OnStart()
		{
			base.OnStart();
			this._player = base.GetComponent<Player>();
            block.BlockAction = (Action<BlockTrigger.BlockTriggerType>)Delegate.Combine(block.BlockAction, new Action<BlockTrigger.BlockTriggerType>(OnBlock));
            SetLivesToEffect(int.MaxValue);
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

        // Token: 0x0600000B RID: 11 RVA: 0x00002289 File Offset: 0x00000489
  //      private void Update()
		//{
		//	//this._player.data.block.TryBlock();
			
			
		//}
        public override void OnUpdate()
        {
            if (!(duration <= 0))
            {
                duration -= TimeHandler.deltaTime;
                //player.transform.localScale = new Vector3((float)player.transform.localScale.x * 2, (float)player.transform.localScale.y / 2);
                //x = rnd.Next((-Screen.width / 2) + (int)player.transform.localScale.x, (Screen.width / 2) - (int)player.transform.localScale.x);
                //y = rnd.Next((-Screen.height / 2) + (int)player.transform.localScale.y, (Screen.height / 2) + (int)player.transform.localScale.y);
                float angle = (float)Math.Atan2(this._player.GetComponent<Gun>().shootPosition.transform.forward.x, -this._player.GetComponent<Gun>().shootPosition.transform.forward.y);
                //this._player.transform.localPosition += this._player.GetComponent<Gun>().shootPosition.transform.forward * 5;
                Vector3 direction = new Vector3((float)Math.Cos(angle), (float)Math.Sin(angle));
                direction.Normalize();
                this._player.transform.localPosition += direction * 2;
            }
            else
            {
                ClearModifiers();
                UnityEngine.GameObject.Destroy(this.gameObject.GetOrAddComponent<ColorEffect>());
            }
        }
    }
}