using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerInfo), typeof(Collider))]
public class ItemController : MonoBehaviour
{

    [SerializeField] private LayerMask _itemLayer;
    private PlayerInfo _playerInfo;
    private PlayerHealthController _playerHealth;
    private PlayerAbilitiesController _playerStamina;

    int maxHealth;
    int maxStamina;
    // Use this for initialization
    void Start()
    {

        if (!this.FindComponent(ref _playerInfo))
        {
            StandardMessages.MissingComponent<PlayerInfo>(this);
            StandardMessages.DisablingBehaviour(this);
        }

        if (!this.FindComponent(ref _playerHealth))
        {
            StandardMessages.MissingComponent<PlayerHealthController>(this);
            StandardMessages.DisablingBehaviour(this);
        }

        if (!this.FindComponent(ref _playerStamina))
        {
            StandardMessages.MissingComponent<PlayerAbilitiesController>(this);
            StandardMessages.DisablingBehaviour(this);
        }

        maxHealth = _playerInfo.Character.HealthPoints;
        maxStamina = _playerInfo.Character.StaminaPoints;
    }

    void OnTriggerEnter(Collider other)
    {

        if ((_itemLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            //validates the name of the object that collided  with the player
            if (other.tag == "HealthPack")
            {
                _playerHealth.HealthPoints++;

                if (_playerHealth.HealthPoints > maxHealth)
                {
                    _playerHealth.HealthPoints = maxHealth;
                }

            }
            else
            {
                _playerStamina.StaminaPoints++;

                if (_playerStamina.StaminaPoints > maxStamina)
                {
                    _playerStamina.StaminaPoints = maxStamina;
                }
            }
            Destroy(other.gameObject);
        }
    }
}
