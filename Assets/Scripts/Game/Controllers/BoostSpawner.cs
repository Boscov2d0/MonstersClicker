using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MonstersGame
{
    public class BoostSpawner
    {
        private List<string> _type = new List<string>();

        private GameObject _booster;

        private float _time;
        private float _minTimeToSpawn = 5f;
        private float _maxTimeToSpawn = 10f;

        BoostPool testPool = new BoostPool();

        public GameObject Booster { get => _booster; set => _booster = value; }

        public BoostSpawner()
        {
            _time = Random.Range(_minTimeToSpawn, _maxTimeToSpawn);

            _type.Add("FreezeBoost");
            _type.Add("DestroyBoost");
        }

        public void SpawnTimer()
        {
            _time -= Time.deltaTime;
            if (_time <= 0)
            {
                _time = Random.Range(_minTimeToSpawn, GlobalBase.TimeToSpawn);
                Spawn();
            }
        }
        private void Spawn()
        {
            int index = Random.Range(0, 2);
            _booster = testPool.GetOrCreate(_type[index]);
        }
        public void Deactivate(Booster booster)
        {
            booster.gameObject.SetActive(false);
            booster.transform.position = new Vector3(50, 50, 0);
            testPool.ReturnToPool(booster.transform, booster.name);
        }
    }
}