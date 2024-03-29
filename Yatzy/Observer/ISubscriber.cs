﻿namespace Yatzy.Observer;
/// <summary>
/// Subscriber to events by a <see cref="IPublisher{TEventArgs}"/>.
/// </summary>
/// <typeparam name="TEventArgs">Arguments that should be passed to the callback.</typeparam>
public interface ISubscriber<TEventArgs>
{
    /// <summary>
    /// Gets the current callback to subscribe with.
    /// </summary>
    void EventCallback(TEventArgs? args);
}

