using Yatzy.Observer;

namespace Yatzy;
public sealed class Game : IPublisher<YatzyEventArgs>
{
    event Action<YatzyEventArgs?>? RecievedPoints;
    public void Subscribe(Action<YatzyEventArgs?> callback)
        => RecievedPoints += callback;
}
