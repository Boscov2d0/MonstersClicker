using UnityEngine;

namespace MonstersGame {
    public class MonsterJumpController
    {
        RedMonster _redMonster;
        private Transform _monsterTransform;
        private Rigidbody _rigidbody;
        private float _jumpForse = 1;
        private bool _isBirth;
        //private bool _canJump;
        public int b;

        public bool IsBirth { get => _isBirth; set => _isBirth = value; }

        public MonsterJumpController(RedMonster redMonster)
        {
            _redMonster = redMonster;
            _monsterTransform = redMonster.MonsterTransform;
            _rigidbody = redMonster.Rigidbody;
            _jumpForse = redMonster.JumpForse;
            _isBirth = redMonster.IsBirth;
            //_canJump = redMonster.CanJump;
        }
        public void MyUpdate()
        {
            Debug.Log(_redMonster.CanJump);
            if (_isBirth && _redMonster.CanJump)
            {
                Jump();
            }
        }
        public void Jump()
        {
            _rigidbody.AddForce(_monsterTransform.up * _jumpForse, ForceMode.Impulse);
        }
    } 
}
