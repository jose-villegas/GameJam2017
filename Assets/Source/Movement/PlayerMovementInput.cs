using System;
using UnityEngine;

[System.Serializable]
public class PlayerMovementInput : MonoBehaviour
{
    [Tooltip("Input configuration behavior, if none is given GetComponent is used")]
    [SerializeField]
    private InputConfiguration _configuration;
    [Tooltip("Controls if input is slowly interpolated or use raw values")]
    [SerializeField]
    private bool _enableSmoothing = true;
    [Tooltip("Controls how fast Forward and Strafe softly interpolate towards the given input")]
    [SerializeField]
    [ShowIf("_enableSmoothing")]
    private float _inputSmoothing = 6.0f;

    public float Forward { get; private set; }
    public bool Jump { get; private set; }

    public float InputSmoothing
    {
        get { return _inputSmoothing; }
        set { _inputSmoothing = Mathf.Max(0.0f, value); }
    }
    public bool EnableSmoothing
    {
        get { return _enableSmoothing; }
        set { _enableSmoothing = value; }
    }
    public InputConfiguration Configuration
    {
        get { return _configuration; }
        set { _configuration = value; }
    }

    private void Start()
    {
        // obtain required components if they aren't given through the editor
        if (!this.FindComponent(ref _configuration))
        {
            StandardMessages.MissingComponent<InputConfiguration>(this);
            StandardMessages.DisablingBehaviour(this);
        }
    }

    public void Update()
    {
        // axis for movement
        float forward = _configuration.InputDevice.Forward;
        // actions
        Jump = _configuration.InputDevice.Jump;
        // smooth movement input
        Forward = EnableSmoothing ? Mathf.Lerp(Forward, forward, Time.deltaTime * InputSmoothing) : forward;
    }
}
