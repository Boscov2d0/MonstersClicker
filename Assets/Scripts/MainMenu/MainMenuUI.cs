using UnityEngine;

namespace MainMenu
{
    public class MainMenuUI
    {
        private GameObject _mainCanvas;

        public GameObject MainCanvas { get => _mainCanvas; set => _mainCanvas = value; }

        public MainMenuUI(GameObject canvas) 
        {
            _mainCanvas = canvas;
        }
    }
}
