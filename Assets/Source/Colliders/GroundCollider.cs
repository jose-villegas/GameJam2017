using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class GroundCollider : MonoBehaviour
{
    public bool IsGrounded { get; private set; }

    /// <summary>
    /// OnTriggerStay is called once per frame for every Collider other
    /// that is touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerStay(Collider other)
    {
        IsGrounded = true;
    }
    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerExit(Collider other)
    {
        IsGrounded = false;
    }
}

