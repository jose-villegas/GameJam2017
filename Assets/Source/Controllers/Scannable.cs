using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class Scannable : MonoBehaviour
{
    private Animator _animator;
    bool _isVisible = false;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        if (!this.FindComponent(ref _animator))
        {
            StandardMessages.MissingComponent<Animator>(this);
            StandardMessages.DisablingBehaviour(this);
        }
    }

    public void Ping()
    {
        if (_animator != null && !_isVisible)
        {
            _animator.SetBool("Appear", true);
            _isVisible = true;
			// return to default
            CoroutineUtils.DelaySeconds(() =>
            {
                _animator.SetBool("Appear", false);
                _isVisible = false;
            }, 1.0f).Start();
        }

        Debug.Log("Scannable Hit");
    }
}
