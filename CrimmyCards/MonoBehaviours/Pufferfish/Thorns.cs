using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModdingUtils.MonoBehaviours;
using ModdingUtils.RoundsEffects;
using UnityEngine;
using UnboundLib;
using CrimmyCards.Extensions;
using ClassesManagerReborn.Util;
using Photon.Pun;
using UnboundLib.Cards;
using UnboundLib.Networking;
using CrimmyCards.Cards.Pufferfish;

namespace CrimmyCards.MonoBehaviours
{
    class Thorns : WasHitEffect
    {
        public override void WasDealtDamage(Vector2 damage, bool selfDamage)
        {
            Player attacking_player = this.gameObject.GetComponent<Player>().data.lastSourceOfDamage;
            CharacterStatModifiersAdditionalData data = base.GetComponent<Player>().GetComponent<CharacterStatModifiers>().GetAdditionalData();
            if (!selfDamage && attacking_player != null)
            {
                Vector2 thorns_damage = new Vector2(-data.damage_percent * damage.x, -data.damage_percent * damage.y);
                Vector2 enemy_pos = attacking_player.data.playerVel.position;
                if (data.poison) {
                     Unbound.Instance.ExecuteAfterFrames(1, () =>
                     {
                         attacking_player.data.healthHandler.TakeDamageOverTime(thorns_damage, enemy_pos, data.poisonDuration, data.poisonInterval, Color.blue);
                     });
                }
                else
                {
                    Unbound.Instance.ExecuteAfterFrames(1, () =>
                    {
                        attacking_player.data.healthHandler.DoDamage(thorns_damage, enemy_pos, Color.blue);
                    });
                }
            }
        }
    }
}
