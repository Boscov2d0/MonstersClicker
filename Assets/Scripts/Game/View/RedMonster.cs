using UnityEngine;

namespace MonstersGame
{
    public class RedMonster : Monster
    {
        [SerializeField] private int _hp;
        [SerializeField] private float _jumpForse;

        private Rigidbody _rigitbody;
        private bool _canJump;

        public Rigidbody Rigidbody { get => _rigitbody; }
        public float JumpForse { get => _jumpForse; set => _jumpForse = value; }
        public bool CanJump { get => _canJump; set => _canJump = value; }

        public override void Awake()
        {
            base.Awake();

            _rigitbody = GetComponent<Rigidbody>();
            Init();
        }
        private void  OnCollisionEnter(Collision collision)
        {
            if (IsBirth)
            {
                if (collision.transform.tag == "Floor")
                {

                    _canJump = true;
                }
                else
                {
                    _canJump = false;
                }
            }
        }
        public override void Init()
        {
            base.Init();
            HP = _hp;
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        }
    }
}