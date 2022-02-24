using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Events;

namespace CrimmyCards.MonoBehaviours
{
    internal class Sawblock_Mono : CrimmyCardsMonoBehaviour
    {
       [PunRPC]
        public void RPCA_FixBox()
        {
            var currentObj = MapManager.instance.currentMap.Map.gameObject.transform.GetChild(MapManager.instance.currentMap.Map.gameObject.transform.childCount - 1);
            var rigid = currentObj.GetComponent<Rigidbody2D>();
            rigid.isKinematic = false;
            rigid.simulated = true;
            currentObj.GetComponent<DamagableEvent>().deathEvent = new UnityEvent();
            currentObj.GetComponent<DamagableEvent>().deathEvent.AddListener(() =>
            {
                Destroy(currentObj.gameObject);
            });
        }

        [PunRPC]
        public void RPCA_BigBox()
        {
            var currentObj = MapManager.instance.currentMap.Map.gameObject.transform.GetChild(MapManager.instance.currentMap.Map.gameObject.transform.childCount - 1);
            currentObj.transform.localScale *= 1.5f;
        }
    }
}
