/// <summary>
/// interface for all move modifications
/// </summary>
public interface IMovable
{
    /// <summary>
    /// Influence player movement
    /// </summary>
    /// <param name="playerController">PlayerController class</param>
    void Move(PlayerController playerController);
}
