using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EnemyPatrolInfo), typeof(Collider))]
public class EnemyHealthController : MonoBehaviour {

	[SerializeField] private LayerMask _damageLayers;
	private EnemyPatrolInfo _enemyInfo;

	// Use this for initialization
	void Start () {

		if (!this.FindComponent(ref _enemyInfo))
        {
            StandardMessages.MissingComponent<EnemyPatrolInfo>(this);
            StandardMessages.DisablingBehaviour(this);
        }
	}

	void OnTriggerEnter(Collider other)
    {
        if ((_damageLayers.value & (1 << other.gameObject.layer)) > 0)
        {
            CommonCoroutines.ScaleToZero(transform, .25f, true).Start();
        }
	}
}
