using System;
using UnityEngine;

namespace MonstersGame
{
    public class PlayerController
    {
        private Camera _camera;
        private Ray _ray;
        RaycastHit _hit;
        private int _forceOfDamage;

        public Action<Monster, int> TapOnMonster = delegate (Monster monster, int forceOfDamage) { };
        public Action<Booster> TapOnBoost;

        public PlayerController(Player player) 
        {
            _camera = player.Camera;
            _ray = player.Ray;
            _hit = player.Hit;
            _forceOfDamage = player.ForceOfDamage;
        }

        public void MyUpdate()
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(_ray, out _hit))
                {
                    if (_hit.collider.tag == "Monster")
                    {
                        TapOnMonster.Invoke(_hit.transform.gameObject.GetComponent<Monster>(), _forceOfDamage);
                    }
                }
                if (Physics.Raycast(_ray, out _hit))
                {
                    if (_hit.collider.tag == "Boost")
                    {
                        TapOnBoost.Invoke(_hit.transform.gameObject.GetComponent<Booster>());
                    }
                }
            }
        }
    }
}