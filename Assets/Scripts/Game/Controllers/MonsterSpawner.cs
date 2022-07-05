using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MonstersGame 
{
    public class MonsterSpawner
    {
        private List<string> _type = new List<string>();
        private GameObject _monster;

        private int _maxLevelOfMonster = 1;
        private float _time;
        private float _minTimeToSpawn = 1f;
        private float _maxTimeToSpawn;
        private bool _stopSpawn;

        MonstersPool testPool = new MonstersPool();

        public int MaxLevelOfMonster { get => _maxLevelOfMonster; set => _maxLevelOfMonster = value; }
        public GameObject Monster { get => _monster; set => _monster = value; }
        public bool StopSpawn { get => _stopSpawn; set => _stopSpawn = value; }

        public Action AddMonsterToList;

        public MonsterSpawner()
        {
            InitTimeSpawn();
            _time = Random.Range(_minTimeToSpawn, _maxTimeToSpawn);

            _type.Add("BlackMonster");
            _type.Add("YellowMonster");
            _type.Add("RedMonster");
        }

        public void SpawnTimer()
        {
            if (!StopSpawn)
            {
                _time -= Time.deltaTime;
                if (_time <= 0)
                {
                    _time = Random.Range(_minTimeToSpawn, GlobalBase.TimeToSpawn);
                    Spawn();
                }
            }
        }
        private void Spawn()
        {
            int index = Random.Range(0, _maxLevelOfMonster);
            _monster = testPool.GetOrCreate(_type[index]);
            _monster.GetComponent<Monster>().Init();
            AddMonsterToList?.Invoke();
        }
        public void Deactivate(Monster monster) 
        {
            testPool.ReturnToPool(monster.transform, monster.name);
        }
        public void InitTimeSpawn() 
        {
            _maxTimeToSpawn = GlobalBase.TimeToSpawn;
        }
    }
}