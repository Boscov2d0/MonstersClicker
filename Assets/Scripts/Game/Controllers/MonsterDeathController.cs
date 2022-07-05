using UnityEngine;

namespace MonstersGame
{
    public class MonsterDeathController
    {
        private Monster _monster;
        private int _healthPoint;
        private float _deathTimer = 2f;

        public MonsterDeathController(Monster monster)
        {
            _monster = monster;
            _healthPoint = monster.HP;
        }
        
        public void MyUpdate() 
        {
            if (_monster.IsDeath) 
            {
                _deathTimer -= Time.deltaTime;
                if (_deathTimer <= 0) 
                {
                    Death();
                }
            }
        }

        public bool HealthChange(int damage)
        {
            _monster.HP -= damage;
            return CheckHP();
        }
        private bool CheckHP()
        {
            if (_monster.HP <= 0)
            {
                PreDeath();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Деактивируем тело монтрика, и активируем эффект смерти (Particle Systems)
        /// </summary>
        private void PreDeath() 
        {
            _monster.IsDeath = true;
            _monster.transform.GetChild(0).gameObject.SetActive(false);
            _monster.transform.GetChild(2).gameObject.SetActive(true);
            _monster.transform.GetComponent<Rigidbody>().isKinematic = true;
            _monster.transform.GetComponent<BoxCollider>().enabled = false;
        }
        private void Death() 
        {
            _monster.transform.position = new Vector3(0, 20, 0);          
            _deathTimer = 2f;
        }
        public void InitHealth(int value) 
        {
            _monster.HP *= value;
        }
    }
}
