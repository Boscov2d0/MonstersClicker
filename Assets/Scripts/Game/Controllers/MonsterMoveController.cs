using UnityEngine;

namespace MonstersGame
{
    public class MonsterMoveController
    {
        private Transform _monsterTransform;
        private bool _isBirth;
        private float _speed;
        private float _positionX;
        private float _positionZ;

        public bool IsBirth { get => _isBirth; set => _isBirth = value; }

        public MonsterMoveController(Monster monster)
        {
            _monsterTransform = monster.MonsterTransform;
            _speed = monster.Speed;
            _isBirth = monster.IsBirth;
            SetDirection();
        }

        public virtual void MyUpdate()
        {
            if (_isBirth)
            {
                Move();
            }
        }
        public void Move()
        {
            _monsterTransform.position += new Vector3(_positionX * _speed, 0, _positionZ * _speed);
        }
        /// <summary>
        /// ������ ����������� ��������
        /// </summary>
        private void SetDirection()
        {
            _positionX = Random.Range(-1f, 1f);
            _positionZ = Random.Range(-1f, 1f);
        }
        /// <summary>
        /// �������� ����������� �������� (�������� ��� ������������ � ���-��)
        /// </summary>
        public void ChangeDirection()
        {
            _positionX *= -1f;
            _positionZ *= -1f;
            Move();
        }
    }
}
