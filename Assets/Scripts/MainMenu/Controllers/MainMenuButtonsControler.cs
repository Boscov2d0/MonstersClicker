using UnityEngine;
using UnityEngine.UI;
using System;

namespace MainMenu {
    public class MainMenuButtonsControler
    {
        private GameObject _mainCanvas;
        private GameObject _loadPanel;
        private Button _startGameButton;
        private Button _recordsListButton;
        private Button _titlesButton;
        private Button _exitGameButton;

        public Action StartPlayGame;
        public GameObject LoadPanel { get => _loadPanel; }
        public MainMenuButtonsControler(GameObject canvas) 
        {
            _mainCanvas = canvas;

            _loadPanel = _mainCanvas.transform.GetChild(1).gameObject;

            _startGameButton = _mainCanvas.transform.GetChild(0).GetChild(0).GetComponent<Button>(); ;
            _recordsListButton = _mainCanvas.transform.GetChild(0).GetChild(1).GetComponent<Button>();
            _titlesButton = _mainCanvas.transform.GetChild(0).GetChild(2).GetComponent<Button>();
            _exitGameButton = _mainCanvas.transform.GetChild(0).GetChild(3).GetComponent<Button>();

            _startGameButton.onClick.AddListener(StartGame);
            _recordsListButton.onClick.AddListener(RecorsList);
            _titlesButton.onClick.AddListener(Titles);
            _exitGameButton.onClick.AddListener(ExitGame);
        }

        private void StartGame() 
        {
            StartPlayGame.Invoke();
        }
        private void RecorsList()
        {
            Debug.Log("RecorsList");
        }
        private void Titles()
        {
            Debug.Log("Titles");
        }
        private void ExitGame()
        {
            Application.Quit();
        }

    }
}