using System.Collections.Generic;
using UnityEngine;

namespace MonstersGame
{
    public class DestroyBoostController
    {
        public void Destroy(MonsterSpawner spawner, List<GameObject> monsters) 
        {
            for (int i = 0; i < monsters.Count; i++) 
            {
                spawner.Deactivate(monsters[i].GetComponent<Monster>());
            }
            monsters.Clear();
        }
    }
}
