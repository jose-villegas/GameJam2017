using UnityEngine;

[RequireComponent(typeof(Animator), typeof(CharacterController), typeof(PlayerInfo))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _gravity = 9.81f;
    private PlayerInfo _playerInfo;
    private Vector3 _axisInput;
    private Vector3 _movement;
    private Quaternion _facingForward;
    private Quaternion _facingBackwards;
    private bool didDoubleJump = false;

    // Use this for initialization
    void Start()
    {
        if (!this.FindComponent(ref _playerInfo))
        {
            StandardMessages.MissingComponent<PlayerInfo>(this);
            StandardMessages.DisablingBehaviour(this);
        }

        _facingForward = transform.rotation;
        _facingBackwards = _facingForward * Quaternion.Euler(0, 180, 0);
    }

    void FixedUpdate()
    {
        _axisInput.x = _playerInfo.MovementInput.Forward;
        _axisInput.y = _playerInfo.MovementInput.Jump ? 1 : 0;
        // turning
        transform.rotation = _axisInput.x > 0 ? _facingForward :
                             _axisInput.x < 0 ? _facingBackwards : transform.rotation;
        // movement
        HorizontalMovement();
        // jumping / falling
        VerticalMovement();
        // physics gravity
         _movement.y -= _gravity * Time.deltaTime;
        _playerInfo.Controller.Move(_movement * Time.deltaTime);
    }

    void VerticalMovement()
    {
        if (_playerInfo.Controller.isGrounded || _playerInfo.GroundCollider.IsGrounded)
        {
            _movement.y = 0;

            if (_axisInput.y > 0)
            {
                _movement.y = _playerInfo.Character.JumpSpeed;
                _playerInfo.Animator.SetTrigger("Jump");
            }

            didDoubleJump = false;
        }
        else
        {
            _playerInfo.Animator.SetBool("Falling", true);

            // double jump
            if (_axisInput.y > 0 && _playerInfo.Animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Jumping Up") && !didDoubleJump)
            {
                _movement.y += _playerInfo.Character.JumpSpeed;
                _playerInfo.Animator.SetTrigger("Double Jump");
                didDoubleJump = true;
            }
        }
    }

    void HorizontalMovement()
    {
        if (_playerInfo.Controller.isGrounded || _playerInfo.GroundCollider.IsGrounded)
        {
            _movement.x = _playerInfo.Character.HorizontalSpeed * _axisInput.x;
            _playerInfo.Animator.SetFloat("Horizontal", _axisInput.x);
            // reset vertical states
            _playerInfo.Animator.SetBool("Falling", false);
            _playerInfo.Animator.ResetTrigger("Jump");
            _playerInfo.Animator.ResetTrigger("Double Jump");
        }
        else
        {
            _movement.x = _playerInfo.Character.AirStrafeSpeed * _axisInput.x;
        }
    }
}
