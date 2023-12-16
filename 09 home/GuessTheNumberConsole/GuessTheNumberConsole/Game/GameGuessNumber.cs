using GuessTheNumberConsole.InterfaceUI;

namespace GuessTheNumberConsole.Game;

internal class GameGuessNumber : IGame
{
    private readonly IInterfaceUI ui;

    public GameGuessNumber(IInterfaceUI ui)
    {
        this.ui = ui;
    }

    public string Name => "Угадай число";

    public void Start()
    {
        ui.ShowText("Правила игры:\n" +
            "");
        ui.ShowText("");
    }
}
