using UnityEngine;
using System.Collections;

public enum AbilityMode
{
    Scanner,
    Attacker
}

[RequireComponent(typeof(PlayerInfo))]
public class PlayerAbilitiesController : MonoBehaviour
{
    [SerializeField] private float _scannerHoldTime = 1f;
    [SerializeField] private float _attackLockTime = 0.5f;
    [SerializeField] private AbilityMode _currentMode;
    private int _staminaBar;
    private PlayerInfo _playerInfo;

    private bool _scannerReady = false;
    private float _scannerAbilityHeldTime = 0.0f;
    private bool _attackLocked = false;
    private float _attackLockedTime = 0.0f;

    public int StaminaPoints
    {
        get { return _staminaBar; }
        set { _staminaBar = value; }
    }


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

        _staminaBar = _playerInfo.Character.StaminaPoints;
    }

    public void ChangeMode()
    {
        if (_currentMode == AbilityMode.Scanner)
        {
            _currentMode = AbilityMode.Attacker;
        }
        else
        {
            _currentMode = AbilityMode.Scanner;
        }
    }

    public void UseScanner()
    {
		_staminaBar++;
        Debug.Log("Scanner");
    }

    public void UseAttack()
    {
		_staminaBar--;
        Debug.Log("Attack");
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (_currentMode == AbilityMode.Attacker)
        {
            if (_playerInfo.InputConfiguration.Device.Ability && !_attackLocked)
            {
                UseAttack();
                _attackLocked = true;
                _attackLockedTime = 0.0f;
            } 
			else if (_attackLocked)
            {
                _attackLockedTime += Time.deltaTime;
            }

            if (_attackLockedTime >= _attackLockTime)
            {
                _attackLocked = false;
                _attackLockedTime = 0.0f;
            }
        }
        else
        {
            if (_playerInfo.InputConfiguration.Device.Ability && !_scannerReady)
            {
                _scannerAbilityHeldTime += Time.deltaTime;

                if (_scannerAbilityHeldTime >= _scannerHoldTime)
                {
                    _scannerReady = true;
                }
            }
            else
            {
                // reset timers
                _scannerReady = false;
                _scannerAbilityHeldTime = 0.0f;
            }

            if (_scannerReady)
            {
                UseScanner();
                // reset timers
                _scannerReady = false;
                _scannerAbilityHeldTime = 0.0f;
            }
        }
    }
}
