using BepInEx;
using UnboundLib;
using UnboundLib.Cards;
using CrimmyCards.Cards;
using HarmonyLib;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using UnityEngine;

namespace CrimmyCards
{
    // These are the mods required for our mod to work
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch", BepInDependency.DependencyFlags.HardDependency)]
    // Declares our mod to Bepin
    [BepInPlugin(ModId, ModName, Version)]
    // The game our mod is associated with
    [BepInProcess("Rounds.exe")]
    public class CrimmyCards : BaseUnityPlugin
    {
        private const string ModId = "com.nwilki.rounds.CrimmyCards";
        private const string ModName = "CrimmyCards";
        public const string Version = "0.1.0"; // What version are we on (major.minor.patch)?
        public const string ModInitials = "CRMY";

        public static CrimmyCards instance { get; private set; }

        void Awake()
        {
            // Use this to call any harmony patch files your mod may have
            var harmony = new Harmony(ModId);
            harmony.PatchAll();
        }
        void Start()
        {
            instance = this;
            CustomCard.BuildCard<Pufferfish>();
            CustomCard.BuildCard<Carrot>();
        }
        private static readonly AssetBundle Bundle = Jotunn.Utils.AssetUtils.LoadAssetBundleFromResources("bundle", typeof(CrimmyCards).Assembly);

        public static GameObject PufferfishArt = Bundle.LoadAsset<GameObject>("C_Pufferfish");
        public static GameObject CarrotArt = Bundle.LoadAsset<GameObject>("C_Carrot");

    }
}