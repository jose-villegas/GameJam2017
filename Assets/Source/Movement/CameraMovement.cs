using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Vector3 _distance = Vector3.forward;
    [SerializeField] private Vector3 _targetTranslate = Vector3.zero;
    [SerializeField] private float _smoothTime;
    private Vector3 _velocity = Vector3.zero;

    private Transform _target;
    private GameObject[] _players;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        _target = new GameObject("Camera Target").transform;
        // look for players
        _players = GameObject.FindGameObjectsWithTag("Player");
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        // target will be in the middle of players -- assume two players
        if(_players.Length == 2)
        {
            _target.position = (_players[0].transform.position + _players[1].transform.position) / 2.0f;
            _target.position += _targetTranslate;
        }
        // look at camera position and rotation
        Vector3 targetPosition = _target.position + _distance;
        Quaternion targetRotation = Quaternion.LookRotation(_target.position - transform.position, Vector3.up);
        // adapt camera to targets
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _smoothTime * Time.deltaTime);
    }
}
