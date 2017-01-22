using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerPresenter : MonoBehaviour
{
    [HeaderAttribute("Player Setup")]
    [SerializeField]
    private PlayerInfo _player1Prefab;
    [SerializeField] private PlayerInfo _player2Prefab;
    [SerializeField] private Transform _playersParent;
    public PlayerInfo[] Players { get; private set; }

    [HeaderAttribute("Input Configurations")]
    [SerializeField]
    private InputConfiguration _player1Input;
    [SerializeField] private InputConfiguration _player2Input;
    [HeaderAttribute("UI Objects")]
    [SerializeField] private Image _healthBar1;
    [SerializeField] private GameObject _staminaBar1;
    [SerializeField] private Image _healthBar2;
    [SerializeField] private GameObject _staminaBar2;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Awake()
    {
        CreatePlayers();
    }

    void CreatePlayers()
    {
        Players = new PlayerInfo[2];

        for (int i = 0; i < 2; i++)
        {
            Players[i] = Instantiate(i == 0 ? _player1Prefab : _player2Prefab);

            // assign input Configurations
            Players[i].InputConfiguration = i == 0 ? _player1Input : _player2Input;
            Players[i].transform.SetParent(_playersParent, false);
            Players[i].transform.Translate(Vector3.right * i);
            Players[i].name = "Player " + (i + 1);
            // pass ui references
            var healthUI = Players[i].GetComponent<HealthBarBehaviour>();
            healthUI.healthBar = i == 0 ? _healthBar1 : _healthBar2;
            var staminaUI = Players[i].GetComponent<StaminaBarBehaviour>();
            staminaUI.StaminaBar = i == 0 ? _staminaBar1 : _staminaBar2;
        }
    }
}
