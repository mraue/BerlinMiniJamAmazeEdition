using System;
using System.Collections.Generic;
using UnityEngine;

namespace CreatingDust.Shared.Pool
{
    public class PrefabInstancePool : MonoBehaviour
    {
        public GameObject prefab;
        public Action<GameObject> onInstantiate = (go) => { };
        public Action<GameObject> onReturn = (go) => { };

        public Stack<GameObject> _pool = new Stack<GameObject>();

        public GameObject Get()
        {
            GameObject instance = null;

            if (_pool.Count > 0)
            {
                instance = _pool.Pop();
            }
            else
            {
                instance = Instantiate(prefab) as GameObject;
                onInstantiate(instance);
            }

            UpdateName();

            return instance;
        }

        public void Return(GameObject instance)
        {            
            instance.transform.SetParent(this.transform);
            instance.transform.localPosition = Vector3.zero;
            instance.SetActive(false);

            onReturn(instance);

            _pool.Push(instance);

            UpdateName();
        }

        void UpdateName()
        {
            name = string.Format("PrefabInstancePool (Pooled:{0})", _pool.Count);
        }
    }
}