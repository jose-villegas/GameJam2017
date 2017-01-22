using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class BulletController : MonoBehaviour
{
    Rigidbody _rigidBody;

    public void Fire(Vector3 direction, float speed, float duration)
    {
        gameObject.GetComponent<Rigidbody>().velocity = direction * speed;
        Destroy(gameObject, duration);
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
		GetComponent<Collider>().enabled = false;
        CommonCoroutines.ScaleToZero(transform, .25f, true).Start();
    }

    /// <summary>
    /// OnBecameInvisible is called when the renderer is no longer visible by any camera.
    /// </summary>
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}