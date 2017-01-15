using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private SidescrollingActor _character;
    [SerializeField] private PlayerMovementInput _movementInput;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Animator _animator;

    public SidescrollingActor Character
    {
        get
        {
            return _character;
        }
        private set
        {
            _character = value;
        }
    }

    public PlayerMovementInput MovementInput
    {
        get
        {
            return _movementInput;
        }
        private set
        {
            _movementInput = value;
        }
    }

    public CharacterController Controller
    {
        get
        {
            return _controller;
        }
        private set
        {
            _controller = value;
        }
    }

    public Animator Animator
    {
        get
        {
            return _animator;
        }
        private set
        {
            _animator = value;
        }
    }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        if (!this.FindComponent(ref _controller))
        {
            StandardMessages.MissingComponent<CharacterController>(this);
            StandardMessages.DisablingBehaviour(this);
        }

        if (!this.FindComponent(ref _animator))
        {
            StandardMessages.MissingComponent<Animator>(this);
            StandardMessages.DisablingBehaviour(this);
        }

        if (!this.FindComponent(ref _movementInput))
        {
            StandardMessages.MissingComponent<PlayerMovementInput>(this);
            StandardMessages.DisablingBehaviour(this);
        }

        if (!_character)
        {
            StandardMessages.MissingAsset<SidescrollingActor>(this);
            StandardMessages.DisablingBehaviour(this);
        }
    }
}
