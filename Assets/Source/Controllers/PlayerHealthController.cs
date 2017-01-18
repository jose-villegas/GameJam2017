using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerInfo), typeof(Collider))]
public class PlayerHealthController : MonoBehaviour
{
    [TooltipAttribute("Layers from where the player would receive damage")]
    [SerializeField] private LayerMask _damageLayers;
    [SerializeField] private int _immunityTime;
    private PlayerInfo _playerInfo;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        if (!this.FindComponent(ref _playerInfo))
        {
            StandardMessages.MissingComponent<PlayerInfo>(this);
            StandardMessages.DisablingBehaviour(this);
        }
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if((_damageLayers.value & (1 << other.gameObject.layer)) > 0)
        {
            Debug.Log("Hit");
        }
    }
}
