using UnityEngine;
using System.Collections;

public class PlayerPresenter : MonoBehaviour
{
    [HeaderAttribute("Player Setup")]
    [SerializeField] private PlayerInfo _player1Prefab;
	[SerializeField] private PlayerInfo _player2Prefab;
    [SerializeField] private Transform _playersParent;
    public PlayerInfo[] Players { get; private set; }

    [HeaderAttribute("Input Configurations")]
    [SerializeField] private InputConfiguration _player1Input;
    [SerializeField] private InputConfiguration _player2Input;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		CreatePlayers();
	}
	
	void CreatePlayers()
	{
		Players = new PlayerInfo[2];

		for(int i = 0; i < 2; i++)
		{
			Players[i] = Instantiate(i == 0 ? _player1Prefab : _player2Prefab);
			
			// assign input Configurations
			var movementInput = Players[i].MovementInput;

			if(null != movementInput)
			{
				movementInput.Configuration = i == 0 ? _player1Input : _player2Input;
			}

			Players[i].transform.SetParent(_playersParent, false);
			Players[i].transform.Translate(Vector3.forward * i);
			Players[i].name = "Player " + (i + 1);
		}
	}
}
