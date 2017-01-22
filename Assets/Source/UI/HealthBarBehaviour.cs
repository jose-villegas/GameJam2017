using UnityEngine;
using UnityEngine.UI;
using System.Collections;


[RequireComponent(typeof(PlayerInfo))]
public class HealthBarBehaviour : MonoBehaviour
{

    private PlayerInfo _playerInfo;
    private PlayerHealthController _playerHealth;

    [SerializeField]
    private Image healthBar;

    int maxHealth;

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

        maxHealth = _playerInfo.Character.HealthPoints;

    }

    //Obtains the current health value and calculates the corresponding value for the bar
    public void CheckHealth()
    {
        Debug.Log("antes: " + healthBar.fillAmount + ", " + _playerHealth.HealthPoints + ", " + _playerInfo.Character.HealthPoints);
        healthBar.fillAmount = Map((float)_playerHealth.HealthPoints, 0, (float)_playerInfo.Character.HealthPoints, 0, 1);
        Debug.Log("antes: " + healthBar.fillAmount + ", " + _playerHealth.HealthPoints + ", " + _playerInfo.Character.HealthPoints);
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {

        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }


    // Update is called once per frame
    void Update()
    {
        //updates every frame the health bar
        CheckHealth();
    }

}
