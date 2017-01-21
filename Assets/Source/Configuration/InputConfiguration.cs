using UnityEngine;

/// <summary>
/// Embedded default configuration for the player input.
/// </summary>
public class InputConfiguration : MonoBehaviour
{
    public enum ControlType
    {
        Gamepad,
        Keyboard
    }

    [Tooltip("Determines which control scheme to use")]
    public ControlType ActiveControlType = ControlType.Gamepad;
    [Tooltip("Default Keyboard Configuration")]
    public KeyboardInputConfiguration KeyboardConfiguration;
    [Tooltip("Default Gamepad Configuration")]
    public GamepadInputConfiguration GamepadConfiguration;

    public IDevice Device
    {
        get
        {
            if (ActiveControlType == ControlType.Gamepad)
            {
                return GamepadConfiguration;
            }

            return KeyboardConfiguration;
        }
    }
}
