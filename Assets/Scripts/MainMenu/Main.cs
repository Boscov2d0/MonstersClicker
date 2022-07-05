using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class Main : MonoBehaviour
    {
        Reference _reference;
        ObjectsPlacer _mainCanvas;
        MainMenuButtonsControler _buttonsControler;
        ObjectsPlacer _mainCamera;
        ObjectsPlacer _directionalLight;
        ObjectsPlacer _table;
        ObjectsPlacer _gameObject;

        AnimationsController _animationsController;

        private bool _canStartPlay;
        /// <summary>
        /// Таймер для запуска анимации
        /// </summary>
        float timer = 0;

        private void Awake()
        {
            _reference = new Reference();
            _mainCanvas = new ObjectsPlacer(_reference.MainCanvas);
            _buttonsControler = new MainMenuButtonsControler(_mainCanvas.Object);
            _buttonsControler.StartPlayGame += StartGameAnim;
            _buttonsControler.LoadPanel.SetActive(false);

            _mainCanvas.Object.SetActive(false);
            _mainCamera = new ObjectsPlacer(_reference.MainCamera);
            _directionalLight = new ObjectsPlacer(_reference.DirectionalLight);
            _table = new ObjectsPlacer(_reference.Table);
            _gameObject = new ObjectsPlacer(_reference.GameObject);

            _animationsController = new AnimationsController(_gameObject.Object.GetComponent<Animator>());
            _gameObject.Object.GetComponent<AnimationEvent>()._eventHellowContent += HellowContentEvent;
            _gameObject.Object.GetComponent<AnimationEvent>()._eventPreStartContent += PreStartContentEvent;
            _gameObject.Object.GetComponent<AnimationEvent>()._eventWaitingContent += WaitingContentEvent;

            timer = Random.Range(5, 10);
        }

        void Update()
        {
            if (_canStartPlay)
            {
                _mainCanvas.Object.SetActive(true);
                if (!_animationsController.Animator.GetBool("WaitingContent"))
                {
                    WaitingContentTimer();
                }
            }
        }
        private void StartGameAnim() 
        {
            _animationsController.Animator.SetBool("WaitingContent", false);
            _animationsController.Animator.SetBool("StartPlayAnimFinish", true);
        }
        private void WaitingContentTimer()
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                _animationsController.Animator.SetBool("WaitingContent", true);
            }
        }
        private void WaitingContentEvent()
        {
            _animationsController.Animator.SetBool("WaitingContent", false);
            timer = Random.Range(5, 10);
        }
        private void HellowContentEvent()
        {
            _canStartPlay = true;
        }
        private void PreStartContentEvent()
        {
            _animationsController.Animator.SetBool("StartPlayAnimFinish", false);
            _buttonsControler.LoadPanel.SetActive(true);
            SceneManager.LoadScene(1);
        }
    }
}
