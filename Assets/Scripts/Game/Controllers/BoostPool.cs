using UnityEngine;

namespace MonstersGame
{
    public class BoostPool
    {
        private Transform _unusedFreezBoostPool;
        private Transform _unusedDestroyBoostPool;
        private Transform _usedPool;
        static GameObject _boost;

        public BoostPool()
        {
            _unusedFreezBoostPool = new GameObject("FreezBoostPool").transform;
            _unusedDestroyBoostPool = new GameObject("DestroyBoostPool").transform;
            _usedPool = new GameObject("UsedBoostPool").transform;
        }

        public GameObject GetOrCreate(string type)
        {
            switch (type)
            {
                case "FreezeBoost":
                    DecideFrom(_unusedFreezBoostPool, type);
                    break;
                case "DestroyBoost":
                    DecideFrom(_unusedDestroyBoostPool, type);
                    break;
            }

            _boost.transform.position = new Vector3(Random.Range(-10f, 2f), 0.5f, Random.Range(2f, -8f));

            return _boost;
        }
        private void DecideFrom(Transform pool, string type)
        {
            if (pool.transform.childCount > 2)
            {
                GetOld(pool);
            }
            else
            {
                CreateNew(type);
            }
        }
        private void GetOld(Transform pool)
        {
            _boost = pool.GetChild(0).gameObject;
            _boost.gameObject.SetActive(true);
            _boost.transform.SetParent(_usedPool);
        }
        private void CreateNew(string type)
        {
            GameObject boosterPrefab = Resources.Load<GameObject>(type);
            _boost = GameObject.Instantiate(boosterPrefab);
            _boost.name = type;
            _boost.transform.SetParent(_usedPool);
        }

        public void ReturnToPool(Transform transform, string type)
        {
            switch (type)
            {
                case "FreezeBoost":
                    transform.transform.SetParent(_unusedFreezBoostPool);
                    break;
                case "DestroyBoost":
                    transform.transform.SetParent(_unusedDestroyBoostPool);
                    break;
            }
        }
    }
}
