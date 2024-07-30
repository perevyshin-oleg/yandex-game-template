using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace YGameTemplate.UI
{
    public class HUDRoot : MonoBehaviour
    {
        [Header("MainGame")]
        [SerializeField] private CanvasGroup _mainGameCanvas;
        [SerializeField] private Button _pauseButton;
        [Header("PauseMenu")]
        [SerializeField] private CanvasGroup _pauseCanvas;
        [Header("EndGame")]
        [SerializeField] private CanvasGroup _endGameCanvas;
        [SerializeField] private Button _endGameButton;
        [SerializeField] private TextMeshProUGUI _endGameText;

        public event Action EndTurnButtonPressed;
        public event Action EndGameButtonPressed;

        public CanvasGroup MainGameCanvas { get => _mainGameCanvas; }
        public CanvasGroup PauseCanvas { get => _pauseCanvas; }
        public CanvasGroup EndGameCanvas { get => _endGameCanvas; }

        public void SetEndGameText(string text) => _endGameText.text = text;

        private void OnEnable()
        {
            _endGameButton.onClick.AddListener(EndGameCallback);
            _pauseButton.onClick.AddListener(PauseButtonCallback);
        }

        private void OnDisable()
        {
            _endGameButton.onClick.RemoveListener(EndGameCallback);
            _pauseButton.onClick.RemoveListener(PauseButtonCallback);
        }

        private void EndGameCallback() => EndGameButtonPressed?.Invoke();
        private void PauseButtonCallback() => EndGameButtonPressed?.Invoke();
    }
}