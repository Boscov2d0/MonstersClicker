using UnityEngine;

namespace MonstersGame
{
    public class MonstersPool
    {
        /// <summary>
        /// Пул деактивированных черных монстриков
        /// </summary>
        private Transform _unusedBlackMonstersPool;
        /// <summary>
        /// Пул деактивированных желтых монстриков
        /// </summary>
        private Transform _unusedYellowMonstersPool;
        /// <summary>
        /// Пул деактивированных красных монстриков
        /// </summary>
        private Transform _unusedRedMonstersPool;
        /// <summary>
        /// Пул монстриков на сцене
        /// </summary>
        private Transform _usedPool;
        static GameObject _monster;

        public MonstersPool()
        {
            _unusedBlackMonstersPool = new GameObject("BlackMonstersPool").transform;
            _unusedYellowMonstersPool = new GameObject("YellowMonstersPool").transform;
            _unusedRedMonstersPool = new GameObject("RedMonstersPool").transform;
            _usedPool = new GameObject("UsedMonstersPool").transform;
        }

        public GameObject GetOrCreate(string type)
        {
            switch (type)
            {
                case "BlackMonster":
                    DecideFrom(_unusedBlackMonstersPool, type);
                    break;
                case "YellowMonster":
                    DecideFrom(_unusedYellowMonstersPool, type);
                    break;
                case "RedMonster":
                    DecideFrom(_unusedRedMonstersPool, type);
                    break;
            }

            _monster.transform.position = new Vector3(Random.Range(-10f, 2f), _monster.transform.position.y, Random.Range(2f, -8f));

            return _monster;
        }
        /// <summary>
        /// Проверяем, если в нужном пуле есть нужный монстрик - достаем
        /// Иначе создаем нового
        /// </summary>
        /// <param name="pool"></param>
        /// <param name="type"></param>
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

        /// <summary>
        /// Достаем монстрика из пула
        /// </summary>
        /// <param name="pool"></param>
        private void GetOld(Transform pool) 
        {
            _monster = pool.GetChild(0).gameObject;
            _monster.transform.SetParent(_usedPool);
        }

        /// <summary>
        /// Создаем нового монстрика
        /// </summary>
        /// <param name="type"></param>
        private void CreateNew(string type)
        {
            GameObject monsterPrefab = Resources.Load<GameObject>(type);
            _monster = GameObject.Instantiate(monsterPrefab);
            _monster.name = type;
            _monster.transform.SetParent(_usedPool);
        }

        /// <summary>
        /// При деактивации монстрика берем его в нужный пул деактивированных монстриков
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="type"></param>
        public void ReturnToPool(Transform transform, string type)
        {
            switch (type)
            {
                case "BlackMonster":
                    transform.transform.SetParent(_unusedBlackMonstersPool);
                    break;
                case "YellowMonster":
                    transform.transform.SetParent(_unusedYellowMonstersPool);
                    break;
                case "RedMonster":
                    transform.transform.SetParent(_unusedRedMonstersPool);
                    break;
            }
        }
    }
}