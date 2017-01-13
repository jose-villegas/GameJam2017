using UnityEngine;

[RequireComponent(typeof(Animator), typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private SidescrollingActor _character;
    [SerializeField] private GroundCollider _groundCollider;

    private CharacterController _controller;
    private Animator _animator;
    private Vector3 _axisInput;
    private Vector3 _movement;
    private Quaternion _facingForward;
    private Quaternion _facingBackwards;
    private bool didDoubleJump = false;

    // Use this for initialization
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _facingForward = transform.rotation;
        _facingBackwards = _facingForward * Quaternion.Euler(0, 180, 0);

        if (!_character)
        {
            Debug.LogError("Missing " + typeof(SidescrollingActor) + "... Disabling " + this);
            enabled = false;
        }
    }

    void FixedUpdate()
    {
        _axisInput.x = Input.GetAxis("Horizontal");
        _axisInput.y = Input.GetAxisRaw("Vertical");
        // turning
        transform.rotation = _axisInput.x > 0 ? _facingForward :
                             _axisInput.x < 0 ? _facingBackwards : transform.rotation;
        // movement
        HorizontalMovement();
        // jumping / falling
        VerticalMovement();
        // physics gravity
        _movement += Physics.gravity * Time.deltaTime;
        _controller.Move(_movement * Time.deltaTime);
    }

    void VerticalMovement()
    {
        if (_controller.isGrounded && _groundCollider.IsGrounded)
        {
            if (_axisInput.y > 0)
            {
                _movement.y = _character.JumpSpeed * _axisInput.y;
                _animator.SetTrigger("Jump");
            }

            didDoubleJump = false;
        }
        else
        {
            _animator.SetBool("Falling", true);

            // double jump
            if(_axisInput.y > 0 && _animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Jumping Up") && !didDoubleJump)
            {
                _movement.y = _character.JumpSpeed * _axisInput.y;
                _animator.SetTrigger("Double Jump");
                didDoubleJump = true;
            }
        }
    }

    void HorizontalMovement()
    {
        if (_controller.isGrounded && _groundCollider.IsGrounded)
        {
            _movement.x = _character.HorizontalSpeed * _axisInput.x;
            _animator.SetFloat("Horizontal", _axisInput.x);
            // reset vertical states
            _animator.SetBool("Falling", false);
            _animator.ResetTrigger("Jump");
            _animator.ResetTrigger("Double Jump");
        }
        else
        {
            _movement.x = _character.AirStrafeSpeed * _axisInput.x;
        }
    }
}
