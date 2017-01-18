using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _playersParent;
    [SerializeField] private Vector3 _distance = Vector3.forward;
    [SerializeField] private Vector3 _targetTranslate = Vector3.zero;
    [SerializeField] private float _smoothTime;
    private Vector3 _velocity = Vector3.zero;

    private Transform _target;
    private Transform[] _players;
    private Transform[] Players
    {
        get
        {
            if (_players == null || _players.Length == 0)
            {
                _players = new Transform[_playersParent.childCount];

                for(int i = 0; i < _playersParent.childCount; i++)
                {
                    _players[i] = _playersParent.GetChild(i);
                }
            }

            return _players;
        }
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        _target = new GameObject("Camera Target").transform;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        // target will be in the middle of players -- assume two players
        if (Players.Length == 2)
        {
            _target.position = (Players[0].position + Players[1].position) / 2.0f;
            _target.position += _targetTranslate;
        }

        // look at camera position and rotation
        Vector3 targetPosition = _target.position + _distance;
        Quaternion targetRotation = Quaternion.LookRotation(_target.position - transform.position, Vector3.up);
        // adapt camera to targets
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 2.0f * _smoothTime * Time.deltaTime);
    }
}
