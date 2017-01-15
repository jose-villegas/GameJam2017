using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerInfo), typeof(Collider))]
public class PlayerHealthController : MonoBehaviour
{
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

    
}
