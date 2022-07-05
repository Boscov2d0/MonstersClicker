using UnityEngine;

namespace MainMenu
{
    public class ObjectsPlacer
    {
        private GameObject _gameObject;

        public GameObject Object { get => _gameObject; set => _gameObject = value; }

        public ObjectsPlacer(GameObject gameObject)
        {
            _gameObject = gameObject;
        }
    }
}