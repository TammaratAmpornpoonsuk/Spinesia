using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caton
{
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T _instance;
        public static T Instance => _instance;

        protected virtual void Awake()
        {
            _instance = this as T;
        }
    }
}
