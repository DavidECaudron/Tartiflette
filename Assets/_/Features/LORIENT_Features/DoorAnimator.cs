using UnityEngine;

public class DoorAnimator : MonoBehaviour
{
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void ToggleDoor()
    {
        if (!_isdoorOpen)
        {
            _animator.Play("DoorOpen", 0, 0.0f);
            _isdoorOpen = true;
        }

        else
        {
            _animator.Play("DoorClose", 0, 0.0f);
            _isdoorOpen = false;
        }
    }

    private Animator _animator;
    private bool _isdoorOpen = false;
}
