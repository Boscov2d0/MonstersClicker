using System;
using UnityEngine;

namespace MonstersGame
{
    public abstract class Monster : MonoBehaviour
    {
        private int _hp;
        private float _speed;
        private bool _isDeath;
        private bool _isBirth;
        private Transform _monsterTransform;
        //private Rigidbody _rigidbody;
        private Transform _body;
        private BoxCollider _collider;

        public int HP { get { return _hp; } set { _hp = value; } }
        public float Speed { get { return _speed; } set { _speed = value; } }
        public bool IsDeath { get => _isDeath; set  => _isDeath = value; }
        public bool IsBirth { get => _isBirth; set => _isBirth = value; }
        public Transform MonsterTransform { get => _monsterTransform; set => _monsterTransform = value; }
        public Transform Body { get => _body; set => _body = value; }
        public BoxCollider Collider { get => _collider; set => _collider = value; }

        public Action OnTrigger;

        public virtual void Awake()
        {
            _monsterTransform = transform;
            _body = transform.GetChild(0);
            //_rigidbody = GetComponent<Rigidbody>();
            _speed = GlobalBase.MonsterSpeed;

            Init();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Wall")
            {
                OnTrigger?.Invoke();
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.tag == "Monster" || collision.transform.tag == "Boost")
            {
                OnTrigger?.Invoke();
            }
        }
        public virtual void Init() 
        {
            _monsterTransform.transform.GetChild(0).gameObject.SetActive(true);
            _monsterTransform.transform.GetChild(2).gameObject.SetActive(false);
            _monsterTransform.GetComponent<Monster>().IsDeath = false;
            _monsterTransform.GetComponent<Monster>().IsBirth = false; 
            _monsterTransform.transform.GetComponent<BoxCollider>().enabled = true;
            _monsterTransform.GetComponent<Rigidbody>().isKinematic = false;
        }
        public void InitSpeed() 
        {
            _speed = GlobalBase.MonsterSpeed;
        }
        public void InitHealth()
        {
            _hp *= 2;
        }
    }
}