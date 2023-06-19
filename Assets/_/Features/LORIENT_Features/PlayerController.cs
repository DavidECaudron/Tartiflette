using UnityEngine;
using static UnityEngine.Input;

public class PlayerController : MonoBehaviour
{
    #region Public Members



    #endregion


    #region Unity API

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        _actualCharacterHeight = _characterHeight * 0.5f + 0.1f;
    }

    private void Update()
    {
        Move();
        Rotate();
        Jump();
    }


    #endregion


    #region Main Methods

    private void Move()
    {
        if (GetAxis("Vertical") < 0.1 && GetAxis("Vertical") > -0.1) return;
        float translation = GetAxis("Vertical") * _speed * Time.deltaTime;
        //transform.Translate(0, 0, translation);
        _rigidbody.MovePosition(transform.position + (transform.forward * translation));

    }

    private void Rotate()
    {
        if (GetAxis("Horizontal") < 0.5 && GetAxis("Horizontal") > -0.5) return;
        float rotation = GetAxis("Horizontal") * _rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);
    }

    private void Jump()
    {
        ActuallyJump();

        if (_rigidbody.velocity.y < 0)
        {
            _rigidbody.velocity += Vector3.up * Physics.gravity.y * (_fallMultiplier - 1) * Time.deltaTime;
        }
        else if (_rigidbody.velocity.y > 0 && !GetButton("Fire1"))
        {
            _rigidbody.velocity += Vector3.up * Physics.gravity.y * (_lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private void ActuallyJump()
    {
        if(!_canJump() || !GetButtonDown("Fire1")) return;

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

    #endregion


    #region Utils



    #endregion


    #region Private and Protected Members

    [Header("Characteristics")]
    [SerializeField] private float _characterHeight;
    [SerializeField][Range(0,1000)] private float _speed;
    [SerializeField] private float _rotationSpeed;

    [Header("Jump")]
    [SerializeField] private int _jumpCount;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _fallMultiplier;
    [SerializeField] private float _lowJumpMultiplier;
    private int _currentJumpCount;
    private float _actualCharacterHeight;

    private Rigidbody _rigidbody;

    #endregion
}