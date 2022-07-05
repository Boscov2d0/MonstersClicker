using UnityEngine;

namespace MonstersGame
{
    public class Booster : MonoBehaviour
    {
        private Transform _monsterTransform;

        public Transform MonsterTransform { get => _monsterTransform; set => _monsterTransform = value; }

        public virtual void Awake()
        {
            _monsterTransform = transform;
        }
    }
}
