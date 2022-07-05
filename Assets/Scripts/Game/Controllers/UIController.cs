using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MonstersGame
{
    public class UIController
    {
        private Text _level;
        private GameObject _gameOverPanel;
        private Button _restartButton;
        private Button _mainMenuButton;
        private Button _mainMenuButton2;

        public UIController(UIView uIView)
        {
            _gameOverPanel = uIView.GameOverPanel;
            _level = uIView.Level;
            _restartButton = uIView.RestartButton;
            _restartButton.onClick.AddListener(ButtonRestart);
            _mainMenuButton = uIView.MeinMenuButton;
            _mainMenuButton.onClick.AddListener(ButtonMainMenu);
            _mainMenuButton2 = uIView.MainMenuButton2;
            _mainMenuButton2.onClick.AddListener(ButtonMainMenu);
        }

        public void ShowLevel(string str) 
        {
            _level.text = str;
        }
        public void ShowGameOver()
        {
            _gameOverPanel.SetActive(true);
        }
        private void ButtonRestart() 
        {
            SceneManager.LoadScene(1);
        }
        private void ButtonMainMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}