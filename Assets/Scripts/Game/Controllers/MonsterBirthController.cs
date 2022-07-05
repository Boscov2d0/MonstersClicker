using System;
using UnityEngine;

namespace MonstersGame
{
    public class MonsterBirthController
    {
        /// <summary>
        /// Трансформировался ли монстрик на поле
        /// </summary>
        private bool _isBirth;
        private Transform body;

        private float timer = 2f;

        public Action WasBorn;
        /// <summary>
        /// Трансформировался ли монстрик на поле
        /// </summary>
        public bool IsBirth { get => _isBirth; set => _isBirth = value; }

        public MonsterBirthController(Monster monster)
        {
            body = monster.Body;
            _isBirth = monster.IsBirth;
        }

        /// <summary>
        /// Монстрик трансформировался
        /// </summary>
        public void Birth()
        {
            _isBirth = true;
            body.gameObject.SetActive(true);
            WasBorn?.Invoke();
        }
        public void MyUpdate() 
        {
            if (!_isBirth)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    Birth();
                    timer = 2f;
                }
            }
        }
    }
}
