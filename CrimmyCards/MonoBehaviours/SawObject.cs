using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace CrimmyCards.MonoBehaviours
{
    public class SawObject : MonoBehaviour
    {
        void Awake()
        {
            transform.localRotation = Quaternion.Euler(new Vector3(90, 0, 0));
        }
        
    }
}
