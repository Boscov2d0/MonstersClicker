using UnityEngine;

namespace MonstersGame
{
    public class FreezeBoost : Booster
    {
        /// <summary>
        /// ����� ��������� ������
        /// </summary>
        [SerializeField] private float _freezTime;

        public float FreezTime { get => _freezTime; set => _freezTime = value; }
    }
}