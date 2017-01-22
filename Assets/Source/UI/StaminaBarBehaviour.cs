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
	private Image[] _staminaPoints;

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
		_staminaPoints = new Image[maxStamina];

		for(int i = 0; i < maxStamina; i++)
		{
			var go = Instantiate(StaminaPointPrefab);
			go.transform.SetParent(barLayout.transform, false);
			_staminaPoints[i] = go.GetComponent<Image>();
		}
    }

    public void CheckStamina()
    {
		int currentStamina = _playerStamina.StaminaPoints;

		for(int i = 0; i < _staminaPoints.Length; i++)
		{
			if(_staminaPoints[i].color.a < .5f && i < currentStamina)
			{
				CommonCoroutines.ImageAlphaToValue(_staminaPoints[i], .25f, 1.0f).Start();
			}

			if(_staminaPoints[i].color.a > .5f && i >= currentStamina)
			{
				CommonCoroutines.ImageAlphaToValue(_staminaPoints[i], .25f, 0.0f).Start();
			}
		}
    }

    // Update is called once per frame
    void Update () {

		//check every frame	the number of bars
		CheckStamina();	
	}
}
