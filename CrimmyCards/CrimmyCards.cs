using BepInEx;
using UnboundLib;
using UnboundLib.Cards;
using CrimmyCards.Cards;
using HarmonyLib;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using UnityEngine;
using CrimmyCards.MonoBehaviours;
using RarityLib.Utils;
using RarityLib;
using CrimmyCards.Cards.Testing;
using CrimmyCards.Cards.Pufferfish;
using System.Collections;
using UnboundLib.GameModes;

namespace CrimmyCards
{
    // These are the mods required for our mod to work
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("root.rarity.lib", BepInDependency.DependencyFlags.HardDependency)]
    // Declares our mod to Bepin
    [BepInPlugin(ModId, ModName, Version)]
    // The game our mod is associated with
    [BepInProcess("Rounds.exe")]
    public class CrimmyCards : BaseUnityPlugin
    {
        private const string ModId = "com.nwilki.rounds.CrimmyCards";
        private const string ModName = "CrimmyCards";
        public const string Version = "0.5.1"; // What version are we on (major.minor.patch)?
        public const string ModInitials = "CRMY";
        public const string TestingInitials = "Testing";

        public static CardCategory TestCardCategory;

        private bool debug = true;
        //public GameObject betterSawObj;

        public static CrimmyCards instance { get; private set; }

        void Awake()
        {
            // Use this to call any harmony patch files your mod may have
            var harmony = new Harmony(ModId);
            harmony.PatchAll();
            //RarityUtils.AddRarity([RarityName], [Relitive Rarity (Common is 1, Rare is 0.1)], [Color when selected], [Color when not sected]);
            RarityUtils.AddRarity("Galactic", 0.0125f, new Color(0, 0.03f * 5f, 0.44f * 5f), new Color(0, 0.03f, 0.44f));
        }
        void Start()
        {
            //// Create bettersaw

            //var saw = (GameObject)Resources.Load("4 map objects/MapObject_Saw_Stat");
            //var betterSaw = Instantiate(saw);
            //DestroyImmediate(betterSaw.GetComponent<PhotonMapObject>());
            //DontDestroyOnLoad(betterSaw);
            //betterSaw.GetComponent<DamageBox>().damage = 27;
            ////DestroyImmediate(betterSaw.GetComponent<Collider2D>());
            ////betterSaw.transform.Rotate(new Vector3(90,0 ));
            //betterSaw.transform.localScale = Vector3.one;
            //betterSaw.transform.position = new Vector3(1000, 0, 0);
            ////PhotonNetwork.PrefabPool.RegisterPrefab("MapObject_Saw_Stat", betterSaw);
            //betterSawObj = betterSaw;

            //Cards

            instance = this;
            //CustomCard.BuildCard<Pufferfish>();
            CustomCard.BuildCard<Carrot>();
            //CustomCard.BuildCard<Block_effect_I_guess>();
            //CustomCard.BuildCard<Gun_Effect_I_guess>();
            //CustomCard.BuildCard<Player_effect_I_guess>();
            //CustomCard.BuildCard<Sawblock>();
            CustomCard.BuildCard<Small>();
            //CustomCard.BuildCard<Bouncy_block>();
            //CustomCard.BuildCard<Mini_Sawblock>();
            //CustomCard.BuildCard<Almost_invisible_sawblock>();
            //CustomCard.BuildCard<Portal_Gun>();
            //CustomCard.BuildCard<Bounce>();
            CustomCard.BuildCard<bullet_hell>();
            CustomCard.BuildCard<Hook_shot>();
            //CustomCard.BuildCard<Crimmys_Deal>();
            //CustomCard.BuildCard<Actual_Bullet_Hell>();
            CustomCard.BuildCard<BattleOfGods>();
            CustomCard.BuildCard<SwordOfTheCosmos>();
            CustomCard.BuildCard<BattleOfAnts>();
            //CustomCard.BuildCard<Pufferfish>();
            CustomCard.BuildCard<Pufferfish>((card) => Pufferfish.Card = card);
            CustomCard.BuildCard<poisonousSpikes>((card) => poisonousSpikes.Card = card);
            //CustomCard.BuildCard<InstantTransmission>();

            if (debug)
            {
                // Build Testing Cards
                TestCardCategory = CustomCardCategories.instance.CardCategory("Testing Cards");

                CustomCard.BuildCard<RemoveAll>();
                CustomCard.BuildCard<RemoveTestingCards>();
                CustomCard.BuildCard<RemoveLast>();
                CustomCard.BuildCard<RemoveFirst>();

                CustomCard.BuildCard<DoRoundStart>();
                CustomCard.BuildCard<DoGameStart>();
                CustomCard.BuildCard<DoBattleStart>();
                CustomCard.BuildCard<DoPointStart>();
                CustomCard.BuildCard<DoPickStart>();
                CustomCard.BuildCard<DoPlayerPickStart>();
                CustomCard.BuildCard<DoRoundEnd>();
                CustomCard.BuildCard<DoGameEnd>();
                CustomCard.BuildCard<DoPointEnd>();
                CustomCard.BuildCard<DoPickEnd>();
                CustomCard.BuildCard<DoPlayerPickEnd>();
                CustomCard.BuildCard<DoInitStart>();
                CustomCard.BuildCard<DoInitEnd>();
                CustomCard.BuildCard<SimulateRoundStart>();
                CustomCard.BuildCard<SimulateRoundEnd>();
                CustomCard.BuildCard<SimulateRound>();
                CustomCard.BuildCard<SimulatePickPhase>();

                //CustomCard.BuildCard<AddPointToTeam>();
                //CustomCard.BuildCard<AddRoundToTeam>();
                //CustomCard.BuildCard<ResetTeamScores>(); 
            }
        }
        public void TriggerGameModeHook(string key)
        {
            StartCoroutine(ITriggerGameModeHook(key));
        }

        private IEnumerator ITriggerGameModeHook(string key)
        {
            yield return GameModeManager.TriggerHook(key);
            yield break;
        }

        internal static AssetBundle Bundle = Jotunn.Utils.AssetUtils.LoadAssetBundleFromResources("bundle", typeof(CrimmyCards).Assembly);

        public static GameObject PufferfishArt = Bundle.LoadAsset<GameObject>("C_Pufferfish");
        public static GameObject CarrotArt = Bundle.LoadAsset<GameObject>("C_Carrot");
        public static GameObject SawBlockArt = Bundle.LoadAsset<GameObject>("C_SawBlock");
        public static GameObject SwordOfTheCosmosArt = Bundle.LoadAsset<GameObject>("C_SwordOfTheCosmos");
        public static GameObject BattleOfGodsArt = Bundle.LoadAsset<GameObject>("Battle of the gods");
    }
}