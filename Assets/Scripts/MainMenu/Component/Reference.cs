using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class Reference
    {
        private GameObject _mainCanvas;
        private GameObject _mainCamera;
        private GameObject _directionalLight;
        private GameObject _table;
        private GameObject _gameObject;

        public GameObject MainCanvas 
        {
            get
            {
                GameObject _canvasPrefab = Resources.Load<GameObject>("UI/MainMenu/MainCanvas");
                _mainCanvas = Object.Instantiate(_canvasPrefab);
                return _mainCanvas;
            }
            set 
            {
                _mainCanvas = value;
            }
        }
        public GameObject MainCamera
        {
            get
            {
                GameObject _mCameraPrefab = Resources.Load<GameObject>("MainCamera");
                _mainCamera = Object.Instantiate(_mCameraPrefab);
                return _mainCamera;
            }
            set
            {
                _mainCamera = value;
            }
        }
        public GameObject DirectionalLight
        {
            get
            {
                GameObject _dLightPrefab = Resources.Load<GameObject>("DirectionalLight");
                _directionalLight = Object.Instantiate(_dLightPrefab);
                return _directionalLight;
            }
            set
            {
                _directionalLight = value;
            }
        }
        public GameObject Table
        {
            get
            {
                GameObject _tablePrefab = Resources.Load<GameObject>("MyTable");
                _table = Object.Instantiate(_tablePrefab);
                return _table;
            }
            set
            {
                _table = value;
            }
        }
        public GameObject GameObject
        {
            get
            {
                GameObject _gObjectPrefab = Resources.Load<GameObject>("GameObject");
                _gameObject = Object.Instantiate(_gObjectPrefab);
                return _gameObject;
            }
            set
            {
                _gameObject = value;
            }
        }
    }
}
