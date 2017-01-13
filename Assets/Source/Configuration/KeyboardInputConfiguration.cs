using UnityEngine;

/// <summary>
/// Keyboard input layout
/// </summary>
[CreateAssetMenu(fileName = "Keyboard", menuName = "Input Configuration/Keyboard")]
[System.Serializable]
public class KeyboardInputConfiguration : ScriptableObject, IDevice
{
    [Header("Keyboard - Directional Movement")]
    public KeyCode MoveForwardKey = KeyCode.W;
    public KeyCode MoveBackKey = KeyCode.S;
    public KeyCode StrafeLeftKey = KeyCode.A;
    public KeyCode StrafeRightKey = KeyCode.D;

    [Header("Keyboard - Gameplay Commands")]
    public KeyCode SprintKey = KeyCode.LeftShift;
    public KeyCode CrouchKey = KeyCode.LeftControl;
    public KeyCode JumpKey = KeyCode.Space;

    private bool crouching;

    public float Forward
    {
        get { return Input.GetKey(MoveForwardKey) ? 1 : Input.GetKey(MoveBackKey) ? -1 : 0; }
    }

    public float Strafe
    {
        get { return Input.GetKey(StrafeRightKey) ? 1 : Input.GetKey(StrafeLeftKey) ? -1 : 0; }
    }

    public bool Sprint
    {
        get { return Input.GetKey(SprintKey); }
    }

    public bool Crouch
    {
        get { return crouching ^= Input.GetKeyUp(CrouchKey); }
    }

    public bool Jump
    {
        get { return Input.GetKeyUp(JumpKey); }
    }
}

