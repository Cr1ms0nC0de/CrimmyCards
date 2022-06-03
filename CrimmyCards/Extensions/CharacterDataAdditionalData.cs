using System;
using System.Runtime.CompilerServices;
//using CrimmyCards.TempEffects;
using HarmonyLib;

namespace CrimmyCards.Extensions
{
    public class CharacterDataAdditionalData
    {

        public CharacterDataAdditionalData()
        {

        }
    }

    public static class CharacterDataExtension
    {
        public static readonly ConditionalWeakTable<CharacterData, CharacterDataAdditionalData> data =
            new ConditionalWeakTable<CharacterData, CharacterDataAdditionalData>();

        public static CharacterDataAdditionalData GetAdditionalData(this CharacterData block)
        {
            return data.GetOrCreateValue(block);
        }

        public static void AddData(this CharacterData block, CharacterDataAdditionalData value)
        {
            try
            {
                data.Add(block, value);
            }
            catch (Exception) { }
        }
    }
}