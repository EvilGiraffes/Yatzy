namespace Yatzy.Errors;
public class PointsOutOfRange : Exception
{
    public PointsOutOfRange()
    {
    }

    public PointsOutOfRange(string? message) : base(message)
    {
    }

    public PointsOutOfRange(string? message, Exception? inner) : base(message, inner)
    {
    }
}
