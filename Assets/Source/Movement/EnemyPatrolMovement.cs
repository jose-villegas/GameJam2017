using UnityEngine;
using System.Collections;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent), typeof(EnemyPatrolInfo))]
public class EnemyPatrolMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
	[SerializeField] private float _minimumDistance = 0.5f;

    private EnemyPatrolInfo _enemyInfo;
	private int _targetIndex = 0;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        if (!this.FindComponent(ref _enemyInfo))
        {
            StandardMessages.MissingComponent<EnemyPatrolInfo>(this);
            StandardMessages.DisablingBehaviour(this);
        }
    }

    private void Update()
    {
        if (!_enemyInfo.Agent) { return; }

		if(_enemyInfo.Agent.remainingDistance <= _minimumDistance)
		{
			GoToNextPoint();
            _enemyInfo.Animator.SetBool("Walk", true);
		}
    }

	private void GoToNextPoint()
	{
		if(_points == null || _points.Length == 0)
		{
			 return;
		}

		_enemyInfo.Agent.SetDestination(_points[_targetIndex].position);

		_targetIndex = (_targetIndex + 1) % _points.Length;
	}
}
