

using System.Text;


namespace GuessTheNumberConsole.InterfaceUI;

internal class ConsoleUI : IInterfaceUI
{
    public void ShowCaption1(string caption)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Игра \"Угадай число\"\n\n");
    }

    /// <summary>
    /// Вывести заголовок сообщения
    /// </summary>
    /// <param name="messageType"></param>
    private void ShowCaption(IInterfaceUI.EnumMessageType messageType) 
    {
        switch (messageType)
        {
            case IInterfaceUI.EnumMessageType.None:
                break;
            case IInterfaceUI.EnumMessageType.Warning:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Предупреждение:");
                break;
            case IInterfaceUI.EnumMessageType.Error:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка:");
                break;
            case IInterfaceUI.EnumMessageType.Info:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Информация:");
                break;
        }
    }

    public IInterfaceUI.EnumMessageButton ShowMessage(string text, IInterfaceUI.EnumMessageType messageType = IInterfaceUI.EnumMessageType.Info, IInterfaceUI.EnumMessageButton button = IInterfaceUI.EnumMessageButton.Cancel)
    {
        ShowCaption(messageType);

        ShowText(text);

        if (button is IInterfaceUI.EnumMessageButton.None) return IInterfaceUI.EnumMessageButton.None;

        ShowText("Выберите один из вариантов: ", ConsoleColor.DarkBlue);

        StringBuilder buttons = new StringBuilder();
        
        if (button is IInterfaceUI.EnumMessageButton.Close) buttons.Append("| Закрыть [З] ");
        if (button is IInterfaceUI.EnumMessageButton.Cancel) buttons.Append("| Отменить [О] ");
        if (button is IInterfaceUI.EnumMessageButton.No) buttons.Append("| Нет [Н] ");
        if (button is IInterfaceUI.EnumMessageButton.Yes) buttons.Append("| Да [Д] ");

        ShowText(buttons.ToString(), ConsoleColor.DarkBlue);

        var key = Console.ReadKey().ToString();
        if (string.IsNullOrEmpty(key)) return IInterfaceUI.EnumMessageButton.None;

        return key.ToUpper() switch
        {
            "З" => IInterfaceUI.EnumMessageButton.Close,
            "О" => IInterfaceUI.EnumMessageButton.Cancel,
            "Н" => IInterfaceUI.EnumMessageButton.No,
            "Д" => IInterfaceUI.EnumMessageButton.Yes,
            _ => IInterfaceUI.EnumMessageButton.None,
        };
    }

    public void ShowText(string text, ConsoleColor colorText)
    {
        Console.ForegroundColor = colorText;
        Console.WriteLine($"\t{text}");
    }

    public void ShowText(string text)
    {
        ShowText(text, ConsoleColor.Gray);
    }
}
