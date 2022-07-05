using UnityEngine;

namespace MonstersGame
{
    public class YellowMonster : Monster
    {
        [SerializeField] private int _hp;
        /// <summary>
        /// Высота полета монстра
        /// </summary>
        [SerializeField] private float _heightFly;

        public float HeightFly { get => _heightFly; set => _heightFly = value; } 

        public override void Awake()
        {
            base.Awake();
            Init();
        }
        public override void Init()
        {
            base.Init();
            HP = _hp;
            transform.position = new Vector3(transform.position.x, 7, transform.position.z);
        }
    }
}