using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private int _forceOfDamage;

    private Ray _ray;
    private RaycastHit _hit;

    public int ForceOfDamage { get => _forceOfDamage; set => _forceOfDamage = value; }
    public Ray Ray { get => _ray; set => _ray = value; }
    public RaycastHit Hit { get => _hit; set => _hit = value; }
    public Camera Camera { get => _camera; set => _camera = value; }
}
