using ClassesManagerReborn;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnboundLib.Cards;
using UnboundLib.GameModes;

namespace CrimmyCards.Cards.Pufferfish
{
    class pufferfishClass : ClassHandler
    {
        internal static string name = "Puffer";
        public override IEnumerator Init()
        {
            UnityEngine.Debug.Log("Regestering: " + name);
            
            while(!(Pufferfish.Card && poisonousSpikes.Card)) yield return null;
            ClassesRegistry.Register(Pufferfish.Card, CardType.Entry);
            ClassesRegistry.Register(poisonousSpikes.Card, CardType.Card, Pufferfish.Card);
        }
        public override IEnumerator PostInit()
        {
            //ClassesRegistry.Get(FasterShields.Card).Blacklist(Harvester.Card);
            //ClassesRegistry.Get(SharperScythes.Card).Blacklist(Guardian.Card);
            yield break;
        }
    }
}
