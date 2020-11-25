using System;
using UnityEngine;

namespace Assets.Scripts.MultiOriented
{
    public struct ObjectPrimitive
    { 
        public GameObject @Object;
        public Guid Id;

        public ObjectPrimitive(GameObject obj, Guid id)
        {
            Object = obj;
            Id = id;
        }
    }
}