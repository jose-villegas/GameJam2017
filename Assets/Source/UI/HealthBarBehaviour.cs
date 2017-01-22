using UnityEngine;
using UnityEngine.UI;
using System.Collections;


[RequireComponent(typeof(PlayerInfo))]
public class HealthBarBehaviour : MonoBehaviour
{

    private PlayerInfo _playerInfo;
    private PlayerHealthController _playerHealth;

    public Image healthBar;

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
        float fValue = Map(_playerHealth.HealthPoints, 0f, _playerInfo.Character.HealthPoints, 0f, 1f);
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, fValue, Time.deltaTime);
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
