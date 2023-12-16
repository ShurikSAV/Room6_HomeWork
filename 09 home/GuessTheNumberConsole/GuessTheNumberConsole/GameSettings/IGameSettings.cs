namespace GuessTheNumberConsole.GameSettings;

//TODO: Кол-во попыток отгадывания и диапазон чисел должен задаваться из настроек.

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
