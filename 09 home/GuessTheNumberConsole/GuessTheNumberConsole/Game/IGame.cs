namespace GuessTheNumberConsole.Game;

/// <summary>
/// Принцип SRP
/// Реализация игры
/// </summary>
internal interface IGame
{
    string Name { get; }
    void Start();
}

