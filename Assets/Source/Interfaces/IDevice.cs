public interface IDevice
{
    float Forward { get; }
    float Strafe { get; }
    bool Sprint { get; }
    bool Crouch { get; }
    bool Jump { get; }
}

