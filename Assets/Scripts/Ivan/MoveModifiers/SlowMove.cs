namespace Ivan.MoveModifiers
{
    /// <summary>
    /// Player movement modifier SlowMove
    /// </summary>
    public class SlowMove : BaseMove
    {
        public SlowMove() : base(new BaseParameters(0.3f)) { }
    }
}
