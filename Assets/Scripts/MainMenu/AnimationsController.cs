using UnityEngine;

public class AnimationsController : MonoBehaviour
{
    private Animator _animator;

    private float _waitingContentTimer;

    public Animator Animator { get => _animator; set => _animator = value; }
    public float WaitingContentTimer { get => _waitingContentTimer; set => _waitingContentTimer = value; }

    public AnimationsController(Animator animator)
    {
        _animator = animator;
    }
    public void RestartWaitingContent() 
    {
        _waitingContentTimer = 0;
    }
}
