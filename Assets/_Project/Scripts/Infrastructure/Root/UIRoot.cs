using UnityEngine;

namespace Project.Infrastructure.Root
{
    public class UIRoot : MonoBehaviour
    {
        [SerializeField] private LoadingScreenView _loadingScreen;
        [SerializeField] private Canvas _childCanvas;

        public Transform UICanvasTransform => _childCanvas.transform;

        public void Hide()
        {
            _childCanvas.enabled = false;
        }

        public void Show()
        {
            _childCanvas.enabled = true;
        }

        public void AttachUI(Transform ui)
        {
            ui.SetParent(UICanvasTransform, false);
        }

        public void ShowLoadingScreen()
        {
            _loadingScreen.gameObject.SetActive(true);
        }

        public void HideLoadingScreen()
        {
            _loadingScreen.gameObject.SetActive(false);
        }
    }
}