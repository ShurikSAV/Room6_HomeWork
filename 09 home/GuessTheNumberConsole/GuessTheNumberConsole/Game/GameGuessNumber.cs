using GuessTheNumberConsole.GameSettings;
using GuessTheNumberConsole.Genegator;
using GuessTheNumberConsole.InterfaceUI;

namespace GuessTheNumberConsole.Game;

internal class GameGuessNumber(IGameSettings settings, IInterfaceUi ui, IGenegator gen) : IGame
{
    //Принцип инверсии зависимостей

    public string Name => "Угадай число";

    public void Start()
    {
        ui.ShowText("Правила игры:\n" +
            "");
        ui.ShowText($"Программа рандомно генерирует число от {settings.ResultMin} до {settings.ResultMax}, пользователь должен угадать это число за {settings.AttemptsNumber} попыток. При каждом вводе числа программа пишет больше или меньше отгадываемого.");

        GameStart();
    }

    private void GameStart()
    {
        var number = gen.GenegatorInt(settings.ResultMin, settings.ResultMax);

        var max = settings.ResultMax;
        var min = settings.ResultMin;

        for (int i = settings.AttemptsNumber - 1; i > 0; i--)
        {
            ui.ShowMessage(
                $"Угадайте число от {min} до {max} ?", 
                IInterfaceUi.EnumMessageType.Question
                );

            var answer = GetUserAnswer();

            if ( answer == number) {
                ui.ShowMessage("Поздравляю, вы выйграли!", IInterfaceUi.EnumMessageType.Info, IInterfaceUi.EnumMessageButton.Close);
                return;
            }

            if (answer > number)
            {
                ui.ShowText("Меньше");
                max = answer;
            }
            else {
                ui.ShowText("Больше");
                min = answer;
            }
            ui.ShowText($"Осталось {i} попыток");
        }

        ui.ShowMessage($"Вы не угадали, я загадал {number}", IInterfaceUi.EnumMessageType.Warning, IInterfaceUi.EnumMessageButton.Close);
    }

    private int GetUserAnswer()
    {
        var result = ui.GetString();

        try
        {
            return Convert.ToInt32(result);
        }
        catch
        {
            ui.ShowText("Введите число:");
            return GetUserAnswer();
        }
    }
}
