using UnityEngine;

namespace MonstersGame
{
    public class MonsterFlyController
    {
        private Transform _monsterTransform;
        /// <summary>
        /// Высота полета
        /// </summary>
        private float _heightFly = 2f;
        /// <summary>
        /// Трансформировался ли монстрик на поле
        /// </summary>
        private bool _isBirth;
        /// <summary>
        /// Трансформировался ли монстрик на поле
        /// </summary>
        public bool IsBirth { get => _isBirth; set => _isBirth = value; }

        public MonsterFlyController(YellowMonster yellowMonster)
        {
            _monsterTransform = yellowMonster.MonsterTransform;
            _heightFly = yellowMonster.HeightFly;
            _isBirth = yellowMonster.IsBirth;

        }
        public void MyUpdate()
        {
            if (_isBirth)
            {
                Fly();
            }
        }
        public void Fly()
        {
            _monsterTransform.position = new Vector3(_monsterTransform.position.x, Mathf.PingPong(Time.time * 4f, _heightFly), _monsterTransform.position.z);
        }
    }
}
