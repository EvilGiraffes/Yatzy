namespace Yatzy.Observer;
/// <summary>
/// Publisher of events.
/// </summary>
/// <typeparam name="TEventArgs">The arguments to the event.</typeparam>
public interface IPublisher<TEventArgs>
{
    /// <summary>
    /// Subscribes to the publishers event with the current callback.
    /// </summary>
    /// <param name="callback">Callback to call when the event occurs.</param>
    void Subscribe(Action<TEventArgs?> callback);
}
