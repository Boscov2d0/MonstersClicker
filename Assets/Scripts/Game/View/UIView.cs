using UnityEngine;
using UnityEngine.UI;

namespace MonstersGame
{
    public class UIView : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private Button _mainMenuButton2;
        [SerializeField] private Text _level;

        public Text Level { get => _level; set => _level = value; }
        public GameObject GameOverPanel { get => _gameOverPanel; set => _gameOverPanel = value; }
        public Button RestartButton { get => _restartButton; set => _restartButton = value; }
        public Button MeinMenuButton { get => _mainMenuButton; set => _mainMenuButton = value; }
        public Button MainMenuButton2 { get => _mainMenuButton2; set => _mainMenuButton2 = value; }
    }
}