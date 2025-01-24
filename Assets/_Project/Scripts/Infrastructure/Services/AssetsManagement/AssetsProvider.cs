using UnityEngine;

namespace Project.Infrastructure.Services.AssetsManagement
{
    public class AssetsProvider : IAssetsProvider
    {
        public T LoadPrefab<T>(string prefabPath) where T : MonoBehaviour
        {
            return Resources.Load<T>(prefabPath);
        }

        public T LoadPrefabInstance<T>(string prefabPath) where T : MonoBehaviour
        {
            T prefab = Resources.Load<T>(prefabPath);
            T instance = Object.Instantiate(prefab);
            return instance;
        }

        public T LoadScriptableObject<T>(string scriptableObjectPath) where T : ScriptableObject
        {
            return Resources.Load<T>(scriptableObjectPath);
        }
    }
}