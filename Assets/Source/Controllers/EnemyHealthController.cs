using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerInfo), typeof(Collider))]
public class EnemyHealthController : MonoBehaviour {

	[SerializeField] private LayerMask _damageLayers;
	private PlayerInfo _playerInfo;

	// Use this for initialization
	void Start () {

		if (!this.FindComponent(ref _playerInfo))
        {
            StandardMessages.MissingComponent<PlayerInfo>(this);
            StandardMessages.DisablingBehaviour(this);
        }
	}

	void OnTriggerEnter(Collider other)
    {
        if ((_damageLayers.value & (1 << other.gameObject.layer)) > 0)
        {
            Destroy(gameObject);
        }
	}
}
