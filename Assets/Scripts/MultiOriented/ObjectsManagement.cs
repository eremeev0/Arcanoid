using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.MultiOriented
{
    public class ObjectsManagement
    {
        private ObjectsManagement() { }
        private static ObjectsManagement _management;
        public static ObjectsManagement GetManagement()
        {
            return _management ?? (_management = new ObjectsManagement());
        }




        private readonly List<ObjectPrimitive> _primitives = new List<ObjectPrimitive>();

        public GameObject Get(Guid guid)
        {
            return _primitives.FirstOrDefault(p => p.Id == guid).Object;
        }

        public void Remove(Guid guid)
        {
            _primitives.Remove(_primitives.FirstOrDefault(p => p.Id == guid));
        }

        public void AddObjectToList(GameObject obj)
        {
            _primitives.Add(new ObjectPrimitive(obj, Guid.NewGuid()));
        }
    }
}