using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(PlayerInfo))]
public class StaminaBarBehaviour : MonoBehaviour
{

    private PlayerInfo _playerInfo;
    private PlayerAbilitiesController _playerStamina;
    public GameObject StaminaPointPrefab;
    int maxStamina;
    public GameObject StaminaBar;
    private HorizontalLayoutGroup barLayout;
	private GameObject[] _staminaPoints;

    // Use this for initialization
    void Start()
    {

        if (!this.FindComponent(ref _playerInfo))
        {
            StandardMessages.MissingComponent<PlayerInfo>(this);
            StandardMessages.DisablingBehaviour(this);
        }

        if (!this.FindComponent(ref _playerStamina))
        {
            StandardMessages.MissingComponent<PlayerAbilitiesController>(this);
            StandardMessages.DisablingBehaviour(this);
        }

        maxStamina = _playerInfo.Character.StaminaPoints;
        barLayout = StaminaBar.GetComponent<HorizontalLayoutGroup>();
		InstantiateStaminaPoints();
    }

    void InstantiateStaminaPoints()
    {
		for(int i = 0; i <= maxStamina; i++)
		{
			var go = Instantiate(StaminaPointPrefab);
			go.transform.SetParent(barLayout.transform, false);
		}
    }

    //create or deletes a bar depending of the number of existing bars and the number of stamina points that the player has.
    /*public void CheckStamina()
    {
		int currentStamina = barLayout.transform.childCount;

		if (currentStamina > _playerStamina.StaminaPoints) 
		{
			//delete a image bar.
			//Destroy()
		}
		else if (currentStamina < _playerStamina.StaminaPoints)
		{
			//create a image bar.
			Instantiate (StaminaPoint);
		}
    }*/


    // Update is called once per frame
    /*void Update () {

		//check every frame	the number of bars
		CheckStamina();	
	}*/
}
