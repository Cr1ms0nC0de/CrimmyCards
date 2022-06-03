using ModdingUtils.MonoBehaviours;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace CrimmyCards.MonoBehaviours
{
    internal class Shoot_Block_Mono : ReversibleEffect
	{
		public Player _player;
		public void AttackAction() { this._player.data.block.TryBlock(); }
		public override void OnStart()
		{
			base.OnStart();
            this._player = base.GetComponent<Player>();
            //this._player.data.GetComponent<Gun>().AddAttackAction(AttackAction);
            //this._player.data.block.TryBlock();
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002289 File Offset: 0x00000489
		private void Update()
		{
			this._player.data.block.TryBlock();
		}
	}
}

