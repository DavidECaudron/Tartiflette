using UnityEngine;

public class DoorAnimator : MonoBehaviour
{
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSourceOpen = GetComponent<AudioSource>();
        _audioSourceClose = GetComponent<AudioSource>();
    }

    public void ToggleDoor()
    {
        if (!_isdoorOpen)
        {
            _animator.Play("DoorOpen", 0, 0.0f);
            _audioSourceOpen.Play();
            _isdoorOpen = true;
            Invoke("StopAudio", 1f);
        }

        else
        {
            _animator.Play("DoorClose", 0, 0.0f);
            _audioSourceClose.Play();
            _isdoorOpen = false;
            Invoke("StopAudio", 1f);
        }
    }

    private void StopAudio()
    {
        _audioSourceOpen.Stop();
    }

    [SerializeField] private AudioSource _audioSourceOpen;
    [SerializeField] private AudioSource _audioSourceClose;
    private Animator _animator;
    private bool _isdoorOpen = false;
}
