namespace Yatzy.UserInterface;
/// <summary>
/// Represents a user interface to interact with the user.
/// </summary>
/// <typeparam name="T">The of entry it uses.</typeparam>
public interface IUserInterface<T>
{
    /// <summary>
    /// Displays the entry to the screen.
    /// </summary>
    /// <param name="entry">The entry to display.</param>
    void Display(T entry);
    /// <summary>
    /// Gets an input from the user.
    /// </summary>
    /// <returns>A string of the entry the user inputted or null if nothing was recieved.</returns>
    string? Input();
}
