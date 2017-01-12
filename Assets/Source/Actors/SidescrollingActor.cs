using UnityEngine;

[CreateAssetMenu(fileName = "SidescrollingActor", menuName = "Actors/Sidescrolling Actor", order = 1)]
public class SidescrollingActor : ScriptableObject
{
    public float HorizontalSpeed = 3f;
    public float JumpSpeed = 5f;
    public float AirStrafeSpeed = 2f;
}
