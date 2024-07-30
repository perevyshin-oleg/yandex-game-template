using DG.Tweening;
using System.Runtime.CompilerServices;
using UnityEngine;


namespace YGameTemplate.UI
{
    public class LoadingCurtain : MonoBehaviour
    {
        [SerializeField] private ProgressBarUI _progressBar;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _showHideDuration;

        public ProgressBarUI progressBar { get => _progressBar; }

        public void ShowCurtain()
        {
            _progressBar.Value = 0;
            _canvasGroup.alpha = 0;
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.DOFade(1, _showHideDuration);
        }

        public void HideCurtain()
        {
            _progressBar.Value = 1;
            _canvasGroup.DOFade(0, _showHideDuration);
            _canvasGroup.SetActive(false);
            GameObject.Destroy(this);
        }
    }
}