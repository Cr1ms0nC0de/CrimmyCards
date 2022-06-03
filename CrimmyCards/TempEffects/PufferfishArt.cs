using ModdingUtils.Extensions;
using ModdingUtils.MonoBehaviours;
using Photon.Pun;
using UnityEngine;
using UnboundLib;

namespace CrimmyCards.TempEffects
{
    internal class PufferfishArt : CounterReversibleEffect
    {
        public GameObject pufferfish;
        

        public override void OnApply()
        {
            throw new System.NotImplementedException();
        }

        public override void OnStart()
        {
            base.OnStart(); 
            pufferfish = Instantiate(CrimmyCards.Bundle.LoadAsset<GameObject>("pufferfish"), player.transform);
            pufferfish.transform.localPosition = Vector3.zero;
        }
        public override void OnUpdate()
        {
            base.OnUpdate();
            pufferfish.transform.localScale = player.transform.localScale;
        }
        public override void Reset()
        {
            throw new System.NotImplementedException();
        }

        public override CounterStatus UpdateCounter()
        {
            throw new System.NotImplementedException();
        }

        public override void UpdateEffects()
        {
            throw new System.NotImplementedException();
        }
    }
}
