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
        /// <summary>
        /// <see cref="GetObjectById"/> alternative method
        /// </summary>
        /// <param name="guid">global unique id</param>
        /// <returns><see cref="ObjectPrimitive"/> - stores an object and its parameters</returns>
        public ObjectPrimitive GetObjectPrimitiveById(Guid guid)
        {
            return _primitives.FirstOrDefault(p => p.Id == guid);
        }
        public void RemoveObjectById(Guid guid)
        {
            var primitive = _primitives.FirstOrDefault(p => p.Id == guid);
            _primitives.Remove(primitive);
        }

        public void AddObjectPrimitiveToList(ObjectPrimitive primitive)
        {
            _primitives.Add(primitive);
        }
    }
}