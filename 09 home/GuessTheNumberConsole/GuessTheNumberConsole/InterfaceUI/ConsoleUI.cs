using System.Text;

namespace GuessTheNumberConsole.InterfaceUI;

//Принцип открытости/закрытости

internal class ConsoleUI : IInterfaceUI
{
    /// <summary>
    /// Вывести заголовок сообщения
    /// </summary>
    /// <param name="messageType"></param>
    virtual public void ShowCaption(IInterfaceUI.EnumMessageType messageType) 
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
            case IInterfaceUI.EnumMessageType.Question:
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Вопрос:");
                break;
        }
    }

    virtual public IInterfaceUI.EnumMessageButton ShowMessage(string text, IInterfaceUI.EnumMessageType messageType = IInterfaceUI.EnumMessageType.Info, IInterfaceUI.EnumMessageButton button = IInterfaceUI.EnumMessageButton.Cancel)
    {
        ShowCaption(messageType);

        ShowText(text);

        return ShowButton(button);
    }

    virtual public IInterfaceUI.EnumMessageButton ShowButton(IInterfaceUI.EnumMessageButton button)
    {
        
        if (isFlag(button, IInterfaceUI.EnumMessageButton.None)) 
            return IInterfaceUI.EnumMessageButton.None;
        
        ShowText("Выберите один из вариантов: ", ConsoleColor.DarkBlue);

        var buttons = new StringBuilder();

        if (isFlag(button, IInterfaceUI.EnumMessageButton.Close)) buttons.Append("| Закрыть [З] ");
        if (isFlag(button, IInterfaceUI.EnumMessageButton.Cancel)) buttons.Append("| Отменить [О] ");
        if (isFlag(button, IInterfaceUI.EnumMessageButton.No)) buttons.Append("| Нет [Н] ");
        if (isFlag(button, IInterfaceUI.EnumMessageButton.Yes)) buttons.Append("| Да [Д] ");

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

    virtual public bool isFlag(IInterfaceUI.EnumMessageButton button, IInterfaceUI.EnumMessageButton close)
        => (button & close) == close;

    virtual public void ShowText(string text, ConsoleColor colorText)
    {
        Console.ForegroundColor = colorText;
        Console.WriteLine($"\t{text}");
    }

    virtual public void ShowText(string text)
    {
        ShowText(text, ConsoleColor.Gray);
    }

    virtual public string? GetString()
        => Console.ReadLine();
}
