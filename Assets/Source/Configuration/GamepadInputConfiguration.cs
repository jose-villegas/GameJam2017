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
    public string GamepadHorizontalInputAxis = "Axis X";
    [Header("Gamepad - Gameplay Commands")]
    public string GamepadJump = "button 2";

    public float Forward
    {
        get { return Input.GetAxis(GamepadHorizontalInputAxis); }
    }

    public bool Jump
    {
        get { return Input.GetKeyDown(GamepadGenericId + " " + GamepadJump); }
    }
}
