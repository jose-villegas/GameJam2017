using UnityEngine;
using System.Collections;

public class EnemyPatrolInfo : MonoBehaviour
{
    [SerializeField] private SidescrollingActor _character;
    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _agent;

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

    public NavMeshAgent Agent
    {
        get
        {
            return _agent;
        }
        private set
        {
            _agent = value;
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
        if (!this.FindComponent(ref _agent))
        {
            StandardMessages.MissingComponent<NavMeshAgent>(this);
            StandardMessages.DisablingBehaviour(this);
        }

        if (!this.FindComponent(ref _animator))
        {
            StandardMessages.MissingComponent<Animator>(this);
            StandardMessages.DisablingBehaviour(this);
        }

        if (!_character)
        {
            StandardMessages.MissingAsset<SidescrollingActor>(this);
            StandardMessages.DisablingBehaviour(this);
        }
    }
}
