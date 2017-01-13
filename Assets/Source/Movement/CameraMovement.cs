using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
	[SerializeField] private Transform target;
    [SerializeField] private Vector3 _distance = Vector3.forward;
    [SerializeField] private float _smoothTime;
    private Vector3 _velocity = Vector3.zero;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        if (!target)
        {
            enabled = false;
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(target.position - transform.position, Vector3.up);
        }
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        Vector3 targetPosition = target.position + _distance;
		Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position, Vector3.up);
		// adapt camera to targets
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime * Time.deltaTime);
		transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _smoothTime * Time.deltaTime);
    }
}
