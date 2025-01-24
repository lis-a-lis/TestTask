using UnityEngine;

namespace Project.Infrastructure.Services.AssetsManagement
{
    public interface IAssetsProvider
    {
        public T LoadPrefab<T>(string prefabPath) where T : MonoBehaviour;
        public T LoadPrefabInstance<T>(string prefabPath) where T : MonoBehaviour;
        public T LoadScriptableObject<T>(string scriptableObjectPath) where T : ScriptableObject;
    }
}