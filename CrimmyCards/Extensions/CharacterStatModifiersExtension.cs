using System;
using System.Runtime.CompilerServices;
using HarmonyLib;
using ModdingUtils.Extensions;
using UnboundLib.Utils;
using UnityEngine;

namespace CrimmyCards.Extensions
{
    public partial class CharacterStatModifiersAdditionalData
    {
        public float recoil;
        public float sawBladeScale;
        public GameObject cube;

        public CharacterStatModifiersAdditionalData()
        {
            recoil = 0;
            sawBladeScale = 1;
            cube = null;
        }
    }
    public static class CharacterStatModifiersExtension
    {
        public static readonly ConditionalWeakTable<CharacterStatModifiers, CharacterStatModifiersAdditionalData> data = new ConditionalWeakTable<CharacterStatModifiers, CharacterStatModifiersAdditionalData>();

        public static CharacterStatModifiersAdditionalData GetAdditionalData(this CharacterStatModifiers characterstats)
        {
            return data.GetOrCreateValue(characterstats);
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
        class CharacterStatModifiersPatchResetStats
        {
            private static void Prefix(CharacterStatModifiers __instance)
            {

                __instance.GetAdditionalData().recoil = 0;
                __instance.GetAdditionalData().sawBladeScale = 1;
                __instance.GetAdditionalData().cube = null;
            }
        }
    }
}
