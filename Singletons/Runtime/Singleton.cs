#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

namespace M320.Singletons
{
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        public static T Instance { get; private set; }

        protected virtual void Awake() 
        {
            Initialize(() => Destroy(this));
        }

        protected virtual void OnValidate()
        {
            #if UNITY_EDITOR
            Initialize(() => EditorApplication.delayCall += () => DestroyImmediate(this));
            #endif
        }

        private void Initialize(System.Action destroy) 
        {
            if (Instance != null && this != null && Instance != this)
            {
                Debug.LogWarning($"Singleton {typeof(T)} already exists. Destroying duplicate on gameObject {gameObject.name}.");
                destroy.Invoke();
                return;
            }
            Instance = this as T;
        }
    }
}
