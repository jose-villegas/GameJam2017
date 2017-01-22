using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(PlayerInfo), typeof(Collider))]
public class PlayerHealthController : MonoBehaviour, IHittable
{
    [TooltipAttribute("Layers from where the player would receive damage")]
    [SerializeField]
    private LayerMask _damageLayers;
    [SerializeField] private LayerMask _fallLayer;
    [HeaderAttribute("Immunity")]
    [SerializeField]
    private int _immunityTime;
    private PlayerInfo _playerInfo;
    private int _healthPoints;
    private bool _isImmune;
    private Image content;
    private Transform _otherPlayer;

    public int HealthPoints
    {
        get { return _healthPoints; }
        set { _healthPoints = Mathf.Min(value, _playerInfo.Character.HealthPoints); }
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

        HealthPoints = _playerInfo.Character.HealthPoints;
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (!_isImmune && (_damageLayers.value & (1 << other.gameObject.layer)) > 0)
        {
            TemporalImmunity(other.gameObject).Start();
            Hit();
            Knockback(0.5f).Start();
        }

        if ((_fallLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            if(!_otherPlayer)
            {
                var _players = GameObject.FindGameObjectsWithTag("Player");

                for (int i = 0; i < _players.Length; i++)
                {
                    if(_players[i].transform != transform) _otherPlayer = _players[i].transform;
                }
            }

            Hit();
            transform.position = _otherPlayer.position;
        }
    }

    private IEnumerator TemporalImmunity(GameObject other)
    {
        _isImmune = true;
        // disable collision
        var eCollider = other.transform.parent.GetComponent<Collider>();
        yield return new WaitForSeconds(0.25f);
        Physics.IgnoreCollision(eCollider, _playerInfo.Controller, true);
        // wait immunity time
        yield return new WaitForSeconds(_immunityTime);
        // enable collision
        Physics.IgnoreCollision(eCollider, _playerInfo.Controller, false);
        // restore from immunity
        _isImmune = false;
    }

    private IEnumerator Knockback(float time)
    {
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / time)
        {
            _playerInfo.Controller.Move(-Vector3.right * t);
            yield return null;
        }
    }

    public void Hit()
    {
        _healthPoints--;

        if (_healthPoints <= 0)
        {
            EventManager.TriggerEvent("PlayerDied");
            Debug.Log("Died");
        }

        Debug.Log("Hit");
    }
}