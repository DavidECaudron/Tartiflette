using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    #region Unity API

    private void Start()
    {
        _actualCharacterHeight = _characterHeight * 0.5f + 0.1f;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleJump();
    }

    #endregion


    #region Main Methods

    private void HandleJump()
    {
        ActuallyJump();

        if (_rigidbody.velocity.y < 0)
        {
            _rigidbody.velocity += Vector3.up * Physics.gravity.y * (_fallMultiplier - 1) * Time.deltaTime;
        }
        else if (_rigidbody.velocity.y > 0 && !_isPressingJump)
        {
            _rigidbody.velocity += Vector3.up * Physics.gravity.y * (_lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private void ActuallyJump()
    {
        if (!_canJump() || !_isPressingJump) return;

        _rigidbody.velocity = Vector2.up * _jumpForce;
        _currentJumpCount++;
    }

    private bool _canJump()
    {
        if (isGrounded()) { _currentJumpCount = 0; return true; }

        else if (!isGrounded() && _currentJumpCount < _jumpCount) return true;

        return false;
    }

    private bool isGrounded()
    {
        Debug.DrawRay(transform.position, Vector3.down * _actualCharacterHeight);
        if (Physics.Raycast(transform.position, Vector3.down, _actualCharacterHeight))
        {
            return true;
        }
        return false;
    }

    public void OnJumpInput(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            _isPressingJump = true;
        }
        else if (ctx.canceled)
        {
            _isPressingJump = false;
        }
    }

    #endregion


    #region Private and Protected Members

    [SerializeField] private float _characterHeight;
    [SerializeField] private int _jumpCount;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _fallMultiplier;
    [SerializeField] private float _lowJumpMultiplier;

    private Rigidbody _rigidbody;
    private int _currentJumpCount;
    private float _actualCharacterHeight;
    private bool _isPressingJump;

    #endregion
}