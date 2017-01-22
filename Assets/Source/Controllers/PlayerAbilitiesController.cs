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
    [SerializeField] private BulletController _bulletPrefab;
    [SerializeField] private Transform _bulletOrigin;
    private int _staminaBar;
    private PlayerInfo _playerInfo;
    private ScannerEffect _scannerEffect;
    private bool _scannerReady = false;
    private float _scannerAbilityHeldTime = 0.0f;
    private bool _attackLocked = false;
    private float _attackLockedTime = 0.0f;

    public int StaminaPoints
    {
        get { return _staminaBar; }
        set { _staminaBar = Mathf.Min(value, _playerInfo.Character.StaminaPoints); }
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

        _scannerEffect = FindObjectOfType<ScannerEffect>();
        StaminaPoints = _playerInfo.Character.StaminaPoints;
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
        StaminaPoints++;
        // trigger animation
        _playerInfo.Animator.SetTrigger("Echo");
        // initiate scan 
        CoroutineUtils.DelaySeconds(() =>
        {
            if (_scannerEffect != null)
            {
                _scannerEffect.InitiateScan(transform);
            }
        }, .15f).Start();
    }

    public void UseAttack()
    {
        if(StaminaPoints <= 0) return;

        StaminaPoints--;
        // trigger animation
        _playerInfo.Animator.SetTrigger("Attack");
        // create bullet
        CoroutineUtils.DelaySeconds(() =>
        {
            var go = Instantiate(_bulletPrefab);
            go.transform.rotation = Quaternion.LookRotation(transform.forward, transform.up);
            go.transform.position = _bulletOrigin.position;
            // get bullet and fire
            var bullet = go.GetComponent<BulletController>();
            bullet.Fire(transform.right, 5, 10);
        }, 0.75f).Start();

    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        // switch mode
        if (_playerInfo.InputConfiguration.Device.Switch)
        {
            ChangeMode();
        }

        // ability trigger logic        
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
