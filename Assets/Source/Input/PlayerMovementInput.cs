using System;
using UnityEngine;

[RequireComponent(typeof(PlayerInfo))]
public class PlayerMovementInput : MonoBehaviour
{
    private PlayerInfo _playerInfo;
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

    private void Start()
    {
        // obtain required components if they aren't given through the editor
        if (!this.FindComponent(ref _playerInfo))
        {
            StandardMessages.MissingComponent<PlayerInfo>(this);
            StandardMessages.DisablingBehaviour(this);
        }
    }

    public void Update()
    {
        // axis for movement
        float forward = _playerInfo.InputConfiguration.Device.Forward;
        // actions
        Jump = _playerInfo.InputConfiguration.Device.Jump;
        // smooth movement input
        Forward = EnableSmoothing ? Mathf.Lerp(Forward, forward, Time.deltaTime * InputSmoothing) : forward;
    }
}
