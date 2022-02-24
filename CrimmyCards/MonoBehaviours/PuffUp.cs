using System;
using System.Collections.Generic;
using System.Text;
using ModdingUtils.MonoBehaviours;
using TemporaryStatsPatch;
using HarmonyLib;
using UnityEngine;
using BepInEx;
using UnboundLib.Cards;

namespace CrimmyCards.MonoBehaviours
{
    internal class PuffUp : ReversibleEffect
    {
        public override void OnStart()
        {
            characterStatModifiers.health = 3.0f;
            characterStatModifiers.sizeMultiplier = 2.2f;
            characterStatModifiers.movementSpeed = 0.8f;
            characterStatModifiers.gravity = 1.2f;
            block.additionalBlocks = 1;
            block.cdAdd -= 0.25f;
            this.ApplyModifiers();
        }
    }
}
