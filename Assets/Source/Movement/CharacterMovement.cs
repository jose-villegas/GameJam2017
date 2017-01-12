using UnityEngine;

[RequireComponent(typeof(Animator), typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private SidescrollingActor _character;
    [SerializeField] private GroundCollider _groundCollider;

    private CharacterController _controller;
    private Animator _animator;
    private Vector3 _axisInput;
    private Quaternion _facingForward;
    private Quaternion _facingBackwards;

    // Use this for initialization
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _facingForward = transform.rotation;
        _facingBackwards = _facingForward * Quaternion.Euler(0, 180, 0);

        if(!_character)
        {
            Debug.LogError("Missing " + typeof(SidescrollingActor) + "... Disabling " + this);
            enabled = false;
        }
    }

    void FixedUpdate()
    {
        _axisInput.x = Input.GetAxis("Horizontal");
        // turning
        transform.rotation = _axisInput.x > 0 ? _facingForward :
                             _axisInput.x < 0 ? _facingBackwards : transform.rotation;

        if (_controller.isGrounded || _groundCollider.IsGrounded)
        {
            _axisInput.y = Input.GetAxisRaw("Vertical");
            // movement
            _animator.SetFloat("Horizontal", _axisInput.x);
            _animator.SetBool("Falling", false);
            // move character
            _axisInput.x *= _character.HorizontalSpeed;

            // jumped
            if (_axisInput.y > 0 && _animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Movement"))
            {
                _axisInput.y *= _character.JumpSpeed;
                _animator.SetTrigger("Jump");
            }
        }
        else
        {
            _animator.SetBool("Falling", true);
            _axisInput.x *= _character.AirStrafeSpeed;
        }

        _axisInput += Physics.gravity * Time.deltaTime;
        _controller.Move(_axisInput * Time.deltaTime);
    }
}
