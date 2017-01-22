using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EnemyPatrolInfo), typeof(Collider))]
public class EnemyHealthController : MonoBehaviour
{

    [SerializeField] private LayerMask _damageLayers;
    [SerializeField] private ParticleSystem _deathFX;
    private EnemyPatrolInfo _enemyInfo;

    // Use this for initialization
    void Start()
    {

        if (!this.FindComponent(ref _enemyInfo))
        {
            StandardMessages.MissingComponent<EnemyPatrolInfo>(this);
            StandardMessages.DisablingBehaviour(this);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // received damage
        if ((_damageLayers.value & (1 << other.gameObject.layer)) > 0)
        {
            if (_deathFX)
            {
                _deathFX.Play();
            }
            
            CommonCoroutines.ScaleToZero(transform, .25f, true).Start();
        }
    }
}
