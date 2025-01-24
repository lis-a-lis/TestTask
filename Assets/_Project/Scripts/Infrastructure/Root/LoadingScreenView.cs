using UnityEngine;
using UnityEngine.UI;

namespace Project.Infrastructure.Root
{
    public class LoadingScreenView : MonoBehaviour
    {
        public void ShowLoadingScreen()
        {
            gameObject.SetActive(true);
        }

        public void HideLoadingScreen()
        {
            gameObject.SetActive(false);
        }
    }
}