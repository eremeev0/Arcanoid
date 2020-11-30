using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

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

        public GameObject GetObjectById(Guid guid)
        {
            return _primitives.FirstOrDefault(p => p.Id == guid).Object;
        }

        public void RemoveObjectById(Guid guid)
        {
            var primitive = _primitives.FirstOrDefault(p => p.Id == guid);
            Object.Destroy(primitive.Object);
            _primitives.Remove(primitive);
        }

        public void AddObjectPrimitiveToList(ObjectPrimitive primitive)
        {
            _primitives.Add(primitive);
        }
    }
}