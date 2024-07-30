using YGameTemplate.Infrastructure.StateMachine;
using PerikDiContainer;

namespace YGameTemplate.UI
{
    public class HUDController
    {
        private HUDRoot _hud;

        public HUDController(HUDRoot hud, DiContainer sceneContainer, GameStateMachine gameStateMachine)
        {
            _hud = hud;
            BindMainGameCanvas(hud, sceneContainer);
            BindEndGameCanvas(hud, gameStateMachine);
        }

        public void SetEndGameText(string value) => _hud.SetEndGameText(value);

        public void OnGameOver()
        {
            SetEndGameText("GameOver");
            ShowEndGameCanvas();
        }

        public void OnVictory()
        {
            SetEndGameText("Victory");
            ShowEndGameCanvas();
        }

        private void BindMainGameCanvas(HUDRoot hud, DiContainer container)
        {

        }

        private void BindEndGameCanvas(HUDRoot hud, GameStateMachine gameStateMachine)
        {
            hud.EndGameButtonPressed += () => gameStateMachine.Enter<MainMenuState>();
        }

        private void ShowEndGameCanvas()
        {
            _hud.MainGameCanvas.SetActive(false);
            _hud.PauseCanvas.SetActive(false);
            _hud.EndGameCanvas.SetActive(true);
        }
    }
}