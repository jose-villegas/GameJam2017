using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class ColliderEvents : MonoBehaviour
{
    [SerializeField] private UnityEvent _onTriggerEnter;
    [SerializeField] private UnityEvent _onTriggerStay;
    [SerializeField] private UnityEvent _OnTriggerExit;
    [SerializeField] private UnityEvent _onCollisionEnter;
    [SerializeField] private UnityEvent _onCollisionStay;
    [SerializeField] private UnityEvent _OnCollisionExit;
    private Collider _collider;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        if (!this.FindComponent(ref _collider))
        {
            StandardMessages.MissingComponent<Collider>(this);
            StandardMessages.DisablingBehaviour(this);
        }
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        if (_onCollisionEnter != null)
        {
            _onCollisionEnter.Invoke();
        }
    }

    /// <summary>
    /// OnCollisionStay is called once per frame for every collider/rigidbody
    /// that is touching rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionStay(Collision other)
    {
        if (_onCollisionStay != null)
        {
            _onCollisionStay.Invoke();
        }
    }

    /// <summary>
    /// OnCollisionExit is called when this collider/rigidbody has
    /// stopped touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionExit(Collision other)
    {
        if (_OnCollisionExit != null)
        {
            _OnCollisionExit.Invoke();
        }
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (_onTriggerEnter != null)
        {
            _onTriggerEnter.Invoke();
        }
    }

    /// <summary>
    /// OnTriggerStay is called once per frame for every Collider other
    /// that is touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerStay(Collider other)
    {
        if (_onTriggerStay != null)
        {
            _onTriggerStay.Invoke();
        }
    }

    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerExit(Collider other)
    {
        if (_OnTriggerExit != null)
        {
            _OnTriggerExit.Invoke();
        }
    }
}
