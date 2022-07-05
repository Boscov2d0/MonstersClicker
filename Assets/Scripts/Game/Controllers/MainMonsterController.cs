using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonstersGame
{
    public class MainMonsterController : IUpdate
    {
        Monster _monster;
        MonsterBirthController _birthController;
        MonsterMoveController _moveController;
        MonsterFlyController _flyController;
        //MonsterJumpController _jumpController;
        MonsterDeathController _deathController;

        public MainMonsterController(Monster monster) 
        {
            _monster = monster;
            ID = UnityEngine.Random.Range(1, 1000);
            Awake();
        }
        private void Awake() 
        {
            _birthController = new MonsterBirthController(_monster);
            _birthController.WasBorn += UploadStatus;
            _moveController = new MonsterMoveController(_monster);
            _deathController = new MonsterDeathController(_monster);
            if (_monster is YellowMonster)
            {
                _flyController = new MonsterFlyController(_monster as YellowMonster);
            }
            /*
            else if (_monster is RedMonster)
            {
                _jumpController = new MonsterJumpController(_monster as RedMonster);
            }
            */
            _monster.OnTrigger += _moveController.ChangeDirection;

        }
        public void MyUpdate()
        {/*
            Debug.Log("_moveController.IsBirth " + _moveController.IsBirth);
            Debug.Log("_birthController.IsBirth" + _birthController.IsBirth);
            Debug.Log(_moveController.IsBirth + "  ---  " + _birthController.IsBirth);
            */
            if (!_monster.IsDeath)
            {
                _birthController.MyUpdate();
                _moveController.MyUpdate();
                if (_flyController != null)
                {
                    _flyController.MyUpdate();
                }
                /*
                if (_jumpController != null)
                {
                    _jumpController.MyUpdate();
                }
                */
            }
            _deathController.MyUpdate();
        }
        private void UploadStatus()
        {
            _moveController.IsBirth = _birthController.IsBirth;
            if (_flyController != null)
            {
                _flyController.IsBirth = _birthController.IsBirth;
            }
            /*
            if (_jumpController != null)
            {
                _jumpController.IsBirth = _birthController.IsBirth;
            }
            */
        }

        public void RiseSpeed() 
        {
            _monster.InitSpeed();
        }
        public void RiseHP() 
        {
            _deathController.InitHealth(2);
        }
    }
}