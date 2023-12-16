using GuessTheNumberConsole.GameSettings;
using GuessTheNumberConsole.Genegator;
using GuessTheNumberConsole.InterfaceUI;
using System.Reflection.Emit;

namespace GuessTheNumberConsole.Game;

internal class GameGuessNumber : IGame
{
    private readonly IInterfaceUI _ui;
    private readonly IGameSettings _settings;
    private readonly IGenegator _gen;

    //Принцип инверсии зависимостей

    public GameGuessNumber(IGameSettings settings, IInterfaceUI ui, IGenegator gen)
    {
        _ui = ui;
        _settings = settings;
        _gen = gen;
    }

    public string Name => "Угадай число";

    public void Start()
    {
        _ui.ShowText("Правила игры:\n" +
            "");
        _ui.ShowText($"Программа рандомно генерирует число от {_settings.ResultMin} до {_settings.ResultMax}, пользователь должен угадать это число за {_settings.AttemptsNumber} попыток. При каждом вводе числа программа пишет больше или меньше отгадываемого.");

        GameStart();
    }

    private void GameStart()
    {
        var number = _gen.GenegatorInt(_settings.ResultMin, _settings.ResultMax);

        var max = _settings.ResultMax;
        var min = _settings.ResultMin;

        for (int i = _settings.AttemptsNumber - 1; i > 0; i--)
        {
            _ui.ShowMessage(
                $"Угадайте число от {min} до {max} ?", 
                IInterfaceUI.EnumMessageType.Question
                );

            var answer = GetUserAnswer();

            if ( answer == number) {
                _ui.ShowMessage("Поздравляю, вы выйграли!", IInterfaceUI.EnumMessageType.Info, IInterfaceUI.EnumMessageButton.Close);
                return;
            }

            if (answer > number)
            {
                _ui.ShowText("Меньше");
                max = answer;
            }
            else {
                _ui.ShowText("Больше");
                min = answer;
            }
            _ui.ShowText($"Осталось {i} попыток");
        }

        _ui.ShowMessage($"Вы не угадали, я загадал {number}", IInterfaceUI.EnumMessageType.Warning, IInterfaceUI.EnumMessageButton.Close);
    }

    private int GetUserAnswer()
    {
        var result = _ui.GetString();

        try
        {
            return Convert.ToInt32(result);
        }
        catch
        {
            _ui.ShowText("Введите число:");
            return GetUserAnswer();
        }
    }
}
