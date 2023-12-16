namespace GuessTheNumberConsole.GameSettings;

//Принцип единственной ответственности - Настройки

/// <summary>
/// Настройки игры
/// </summary>
internal interface IGameSettings
{
    /// <summary>
    /// Количество попыток
    /// </summary>
    int AttemptsNumber { get; }

    /// <summary>
    /// Минимально загаданное число
    /// </summary>
    int ResultMax { get; }
    /// <summary>
    /// Минимально загаданное число
    /// </summary>
    int ResultMin { get; }
}
