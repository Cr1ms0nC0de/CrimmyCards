using System;
using System.Runtime.CompilerServices;
using HarmonyLib;
using ModdingUtils.Extensions;
using UnboundLib.Utils;
using UnityEngine;

namespace CrimmyCards.Extensions
{
    public class CharacterStatModifiersAdditionalData
    {
        public float recoil;
        public float damage_percent;
        public Boolean poison;
        public float poisonDuration;
        public float poisonInterval;
        //public float sawBladeScale;
        public GameObject cube;

        public CharacterStatModifiersAdditionalData()
        {
            recoil = 0f;
            damage_percent = 0f;
            poison = false;
            poisonDuration = 0f;
            poisonInterval = 1.25f;
            //sawBladeScale = 1;
            cube = null;
        }
    }
    public static class CharacterStatModifiersExtension
    {
        public static readonly ConditionalWeakTable<CharacterStatModifiers, CharacterStatModifiersAdditionalData> data = new ConditionalWeakTable<CharacterStatModifiers, CharacterStatModifiersAdditionalData>();

        public static CharacterStatModifiersAdditionalData GetAdditionalData(this CharacterStatModifiers statModifiers)
        {
            return data.GetOrCreateValue(statModifiers);
        }

        public static void AddData(this CharacterStatModifiers characterstats, CharacterStatModifiersAdditionalData value)
        {
            try
            {
                data.Add(characterstats, value);
            }
            catch (Exception) { }
        }

        // reset additional CharacterStatModifiers when ResetStats is called
        [HarmonyPatch(typeof(CharacterStatModifiers), "ResetStats")]
        private class CharacterStatModifiersPatchResetStats
        {
            private static void Prefix(CharacterStatModifiers __instance)
            {
                var additionalData = __instance.GetAdditionalData();
                additionalData.recoil = 0f;
                additionalData.damage_percent = 0f;
                additionalData.poison = false;
                additionalData.poisonDuration = 0f;
                additionalData.poisonInterval = 1.25f;
                //additionalData.sawBladeScale = 1;
                additionalData.cube = null;
            }
        }
    }
}
