#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

namespace M320.Singletons
{
    public abstract class SingletonSO<T> : ScriptableObject where T : SingletonSO<T>
    {
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            #if UNITY_EDITOR
            Initialize(DestroyAsset);
            #endif
        }

        protected virtual void OnValidate()
        {
            #if UNITY_EDITOR
            Initialize(() => EditorApplication.delayCall += DestroyAsset);
            #endif
        }

        #if UNITY_EDITOR
        private void DestroyAsset() 
        {
            string assetPath = AssetDatabase.GetAssetPath(this);
            AssetDatabase.DeleteAsset(assetPath);
            AssetDatabase.Refresh();
        }
        #endif

        private void Initialize(System.Action destroy)
        {
            if (Instance != null && this != null && Instance != this)
            {
                Debug.LogWarning($"SingletonSO {typeof(T)} already exists. Destroying duplicate {name}.");
                destroy.Invoke();
                return;
            }
            Instance = this as T;
        }
    }
}
