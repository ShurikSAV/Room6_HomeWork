using GuessTheNumberConsole.Game;
using GuessTheNumberConsole.GameSettings;
using GuessTheNumberConsole.Genegator;
using GuessTheNumberConsole.InterfaceUI;
using System.ComponentModel;


/*
 На примере реализации игры «Угадай число» продемонстрировать практическое применение SOLID принципов.
Программа рандомно генерирует число, пользователь должен угадать это число. При каждом вводе числа программа пишет больше или меньше отгадываемого. Кол-во попыток отгадывания и диапазон чисел должен задаваться из настроек.
В отчёте написать, что именно сделано по каждому принципу.
Приложить ссылку на проект и написать, сколько времени ушло на выполнение задачи.
 */

/*
 //NOTE: SRP  Принцип единственной ответственности
    IInterfaceUI    Отвечает за взаимодействие с пользователем
    IGame           Отвечает за жизненный цикл игры   


 */


//IInterfaceUI ui = new ConsoleUI();
IInterfaceUI ui = new ConsoleUI_Eng(); //Принцип подстановки Барбары Лисков

IGame game = new GameGuessNumber(
    new GameSettings() { 
        AttemptsNumber = 10,
        ResultMin = 0,
        ResultMax = 50,
    },
    ui,
    new Genegator()
    );

ui.ShowMessage(
    $"Игра '{game.Name}' началась...");

game.Start();

ui.ShowMessage("Игра закончена\nНажмите любую клавишу для выхода",IInterfaceUI.EnumMessageType.Info, IInterfaceUI.EnumMessageButton.Close);