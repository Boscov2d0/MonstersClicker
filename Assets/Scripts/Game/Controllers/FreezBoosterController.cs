using UnityEngine;

namespace MonstersGame
{
    public class FreezBoosterController
    {
        private MonsterSpawner _monsterSpawner;
        private float _timer;
        private float _currentTimer;
        private bool _freez;
        public FreezBoosterController(FreezeBoost boost) 
        {
            _timer = boost.FreezTime;
            _currentTimer = _timer;
        }

        public void MyUpdate()
        {
            if (_freez) 
            {
                _currentTimer -= Time.deltaTime;
                if (_currentTimer <= 0) 
                {
                    UnFreez();
                }
            } 
        }
        public void StartFreez(MonsterSpawner monsterSpawner) 
        {
            _monsterSpawner = monsterSpawner;
            _freez = true;
            FreezSpawn();
        }
        private void FreezSpawn() 
        {
            _monsterSpawner.StopSpawn = true;
        }
        private void UnFreez() 
        {
            _currentTimer = _timer;
            _freez = false;
            _monsterSpawner.StopSpawn = false;
        }
    }
}
