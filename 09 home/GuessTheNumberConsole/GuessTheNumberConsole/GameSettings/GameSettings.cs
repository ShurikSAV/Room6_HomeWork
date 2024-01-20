namespace GuessTheNumberConsole.GameSettings;

internal class GameSettings : IGameSettings
{
    public int AttemptsNumber { get; init; }

    public int ResultMax { get; init; }

    public int ResultMin { get; init; }
}
