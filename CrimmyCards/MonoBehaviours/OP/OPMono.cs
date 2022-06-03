using UnityEngine;
using UnboundLib.GameModes;
using ModdingUtils.MonoBehaviours;
using UnboundLib.Cards;
using UnboundLib;
using ModdingUtils.Extensions;
using System;
using System.Collections.Generic;
using CrimmyCards.Cards;
using ModdingUtils.GameModes;
using System.Linq;

namespace CrimmyCards.MonoBehaviours
{
    internal class OPMono : ReversibleEffect
    {
        internal class GodsMono : ReversibleEffect, IPointEndHookHandler, IPointStartHookHandler, IGameStartHookHandler
        {
            private float healthMultiplier = 1f;
            private float sizeMultiplier = 1f;
            public override void OnStart()
            {
                InterfaceGameModeHooksManager.instance.RegisterHooks(this);
                data = GetComponentInParent<CharacterData>();
                this.applyImmediately = false;
                this.SetLivesToEffect(int.MaxValue);
            }

            public void OnPointStart()
            {
                healthMultiplier = 1f;
                sizeMultiplier = 1f;
                foreach (Player otherPlayer in PlayerManager.instance.players)
                {
                    if (otherPlayer.playerID != player.playerID)
                    {
                        foreach (var card in otherPlayer.data.currentCards.Where((cardInfo) => cardInfo.cardName.ToLower() == "Battle of The Gods".ToLower()))
                        {
                            healthMultiplier *= 7.5f;
                            sizeMultiplier *= 0.67f;
                        }
                    }
                }

                this.characterDataModifier.health_mult = healthMultiplier;
                this.characterDataModifier.maxHealth_mult = healthMultiplier;
                this.characterStatModifiers.sizeMultiplier = sizeMultiplier;
                this.ApplyModifiers();
            }

            public void OnPointEnd()
            {
                this.ClearModifiers();
            }

            public void OnGameStart()
            {
                UnityEngine.GameObject.Destroy(this);
            }

            public override void OnOnDestroy()
            {
                InterfaceGameModeHooksManager.instance.RemoveHooks(this);
            }
        }

        internal class CosmosMono : ReversibleEffect, IPointEndHookHandler, IPointStartHookHandler, IGameStartHookHandler
        {
            private float damageMultiplier = 1f;
            public override void OnStart()
            {
                InterfaceGameModeHooksManager.instance.RegisterHooks(this);
                data = GetComponentInParent<CharacterData>();
                this.applyImmediately = false;
                this.SetLivesToEffect(int.MaxValue);
            }
            public void OnPointStart()
            {
                damageMultiplier = 1f;
                foreach (Player otherPlayer in PlayerManager.instance.players)
                {
                    if (otherPlayer.playerID != player.playerID)
                    {
                        foreach (var card in otherPlayer.data.currentCards.Where((cardInfo) => cardInfo.cardName.ToLower() == "Sword of The Cosmos".ToLower()))
                        {
                            damageMultiplier *= 5.0f;
                        }
                    }
                }

                this.data.weaponHandler.gun.bulletDamageMultiplier = damageMultiplier;
                this.ApplyModifiers();
            }

            public void OnPointEnd()
            {
                this.ClearModifiers();
            }

            public void OnGameStart()
            {
                UnityEngine.GameObject.Destroy(this);
            }

            public override void OnOnDestroy()
            {
                InterfaceGameModeHooksManager.instance.RemoveHooks(this);
            }
        }
        internal class AntsMono : ReversibleEffect, IPointEndHookHandler, IPointStartHookHandler, IGameStartHookHandler
        {
            private float healthMultiplier = 1f;
            private float sizeMultiplier = 1f;
            public override void OnStart()
            {
                InterfaceGameModeHooksManager.instance.RegisterHooks(this);
                data = GetComponentInParent<CharacterData>();
                this.applyImmediately = false;
                this.SetLivesToEffect(int.MaxValue);
            }
            public void OnPointStart()
            {
                healthMultiplier = 1f;
                sizeMultiplier = 1f;
                foreach (Player otherPlayer in PlayerManager.instance.players)
                {
                    if (otherPlayer.playerID != player.playerID)
                    {
                        foreach (var card in otherPlayer.data.currentCards.Where((cardInfo) => cardInfo.cardName.ToLower() == "Battle of The Ants".ToLower()))
                        {
                            healthMultiplier *= 0.5f;
                            sizeMultiplier *= 0.75f;
                        }
                    }
                }

                this.characterDataModifier.health_mult = healthMultiplier;
                this.characterDataModifier.maxHealth_mult = healthMultiplier;
                this.characterStatModifiers.sizeMultiplier = sizeMultiplier;
                this.ApplyModifiers();
            }

            public void OnPointEnd()
            {
                this.ClearModifiers();
            }

            public void OnGameStart()
            {
                UnityEngine.GameObject.Destroy(this);
            }

            public override void OnOnDestroy()
            {
                InterfaceGameModeHooksManager.instance.RemoveHooks(this);
            }
        }
    }
}
