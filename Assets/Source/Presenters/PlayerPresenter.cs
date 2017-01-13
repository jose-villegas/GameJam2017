using UnityEngine;
using System.Collections;

public class PlayerPresenter : MonoBehaviour
{
    [HeaderAttribute("Player Setup")]
    [SerializeField]
    private GameObject _playerPrefab;
    [SerializeField] private Transform _playersParent;
    public GameObject[] Players { get; private set; }

    [HeaderAttribute("Input Configurations")]
    [SerializeField] private InputConfiguration _player1;
    [SerializeField] private InputConfiguration _player2;

	private int numberOfPlayers = 2;

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
		Players = new GameObject[numberOfPlayers];

		for(int i = 0; i < numberOfPlayers; i++)
		{
			Players[i] = Instantiate(_playerPrefab);
			Players[i].transform.SetParent(_playersParent);
			Players[i].name = "Player " + (i + 1);
			// assign input Configurations
			var movementInput = Players[i].GetComponent<PlayerMovementInput>();

			if(null != movementInput)
			{
				switch (i)
				{
					case 0:
						movementInput.Configuration = _player1; break;
					case 1:
						movementInput.Configuration = _player2; break;
				}
			}
		}
	}
}
