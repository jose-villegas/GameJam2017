using UnityEngine;

/// <summary>
/// Keyboard input layout
/// </summary>
[CreateAssetMenu(fileName = "Keyboard", menuName = "Input Configuration/Keyboard")]
[System.Serializable]
public class KeyboardInputConfiguration : ScriptableObject, IDevice
{
    [Header("Keyboard - Directional Movement")]
    public KeyCode MoveForwardKey = KeyCode.D;
    public KeyCode MoveBackKey = KeyCode.A;
    [Header("Keyboard - Gameplay Commands")]
    public KeyCode JumpKey = KeyCode.Space;
    public KeyCode SprintKey = KeyCode.LeftShift;
    public KeyCode AbilityKey = KeyCode.F;

    public float Forward
    {
        get { return Input.GetKey(MoveForwardKey) ? 1 : Input.GetKey(MoveBackKey) ? -1 : 0; }
    }

    public bool Jump
    {
        get { return Input.GetKeyDown(JumpKey); }
    }

    public bool Sprint
    {
        get { return Input.GetKeyDown(SprintKey); }
    }

    public bool Ability
    {
        get { return Input.GetKey(AbilityKey); }
    }
}

