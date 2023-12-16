namespace GuessTheNumberConsole.GameSettings;

internal class GameSettings : IGameSettings
{
    public int AttemptsNumber { get; set; }

    public int ResultMax { get; set; }

    public int ResultMin { get; set; }
}
