using UnityEngine;

public class DoorAnimator : MonoBehaviour
{
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void ToggleDoor()
    {
        if (!_isdoorOpen)
        {
            _animator.Play("DoorOpen", 0, 0.0f);
            _audioSource.Play();
            _isdoorOpen = true;
        }

        else
        {
            _animator.Play("DoorClose", 0, 0.0f);
            _audioSource.Play();
            _isdoorOpen = false;
        }
    }

    private AudioSource _audioSource;
    private Animator _animator;
    private bool _isdoorOpen = false;
}
