using UnityEngine;

namespace MonstersGame
{
    public class BlackMonster : Monster
    {
        [SerializeField] private int _hp;

        public override void Awake()
        {
            base.Awake();

            Init();
        }
        public override void Init() 
        {
            base.Init();
            HP = _hp;
            transform.position = new Vector3(transform.position.x, 20, transform.position.z);
        }
    }
}
