using Yatzy.Utils;

namespace Yatzy.Observer;
/// <summary>
/// An extention method container for an instance of <see cref="IPublisher{TEventArgs}"/>.
/// </summary>
public static class PublisherExt
{
    /// <summary>
    /// Subscribes the subscriber to a publisher.
    /// </summary>
    /// <typeparam name="TEventArgs">The event argument type the publisher uses.</typeparam>
    /// <param name="publisher">The publisher to subscribe to.</param>
    /// <param name="subscriber">The subscriber who will subscribe to the publisher.</param>
    public static void Subscribe<TEventArgs>(this IPublisher<TEventArgs> publisher, ISubscriber<TEventArgs> subscriber)
        where TEventArgs : EventArgs
        => publisher.Subscribe(subscriber.SubscriberCallback);
    /// <summary>
    /// Subscribes multiple subscriber instances to a publisher.
    /// </summary>
    /// <typeparam name="TEventArgs"><inheritdoc cref="Subscribe{TEventArgs}(IPublisher{TEventArgs}, ISubscriber{TEventArgs})" path="/typeparam[@name='TEventArgs']"/></typeparam>
    /// <param name="publisher"><inheritdoc cref="Subscribe{TEventArgs}(IPublisher{TEventArgs}, ISubscriber{TEventArgs})" path="/param[@name='publisher']"/></param>
    /// <param name="subscribers">The subscribers which will subscribe to the publisher.</param>
    public static void SubscribeAll<TEventArgs>(this IPublisher<TEventArgs> publisher, IEnumerable<ISubscriber<TEventArgs>> subscribers)
        where TEventArgs : EventArgs
        => subscribers.Call(subscriber => publisher.Subscribe(subscriber));
    /// <inheritdoc cref="SubscribeAll{TEventArgs}(IPublisher{TEventArgs}, IEnumerable{ISubscriber{TEventArgs}})"/>
    public static void SubscribeAll<TEventArgs>(this IPublisher<TEventArgs> publisher, params ISubscriber<TEventArgs>[] subscribers)
        where TEventArgs : EventArgs
        => publisher.SubscribeAll(subscribers.AsEnumerable());
}
