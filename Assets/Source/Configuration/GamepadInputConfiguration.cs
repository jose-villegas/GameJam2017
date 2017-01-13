using UnityEngine;

/// <summary>
/// Gamepad input layout
/// </summary>
[CreateAssetMenu(fileName = "Gamepad", menuName = "Input Configuration/Gamepad")]
[System.Serializable]
public class GamepadInputConfiguration : ScriptableObject, IDevice
{
    [Header("Gamepad")]
    [Tooltip("Joystic id in Project Settings -> Input")]
    public string GamepadGenericId = "joystick";

    [Header("Gamepad - Directional Movement")]
    public string GamepadHorizontalInput = "Axis X";
    public string GamepadVerticalInput = "Axis Y";

    [Header("Gamepad - Gameplay Commands")]
    public string GamepadSprint = "button 0";
    public string GamepadCrouch = "button 1";
    public string GamepadJump = "button 2";

    private bool crouching;

    public float Forward
    {
        get { return Input.GetAxisRaw(GamepadVerticalInput); }
    }

    public float Strafe
    {
        get { return Input.GetAxisRaw(GamepadHorizontalInput); }
    }

    public bool Sprint
    {
        get { return Input.GetKey(GamepadSprint); }
    }

    public bool Crouch
    {
        get { return crouching ^= Input.GetKeyUp(GamepadCrouch); }
    }

    public bool Jump
    {
        get { return Input.GetKeyUp(GamepadJump); }
    }
}
