using System.Text;

namespace GuessTheNumberConsole.InterfaceUI;

//Принцип открытости/закрытости

internal class ConsoleUi : IInterfaceUi
{
    /// <summary>
    /// Вывести заголовок сообщения
    /// </summary>
    /// <param name="messageType"></param>
    protected virtual void ShowCaption(IInterfaceUi.EnumMessageType messageType) 
    {
        switch (messageType)
        {
            case IInterfaceUi.EnumMessageType.None:
                break;
            case IInterfaceUi.EnumMessageType.Warning:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Предупреждение:");
                break;
            case IInterfaceUi.EnumMessageType.Error:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка:");
                break;
            case IInterfaceUi.EnumMessageType.Info:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Информация:");
                break;
            case IInterfaceUi.EnumMessageType.Question:
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Вопрос:");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(messageType), messageType, null);
        }
    }

    public virtual IInterfaceUi.EnumMessageButton ShowMessage(string text, IInterfaceUi.EnumMessageType messageType = IInterfaceUi.EnumMessageType.Info, IInterfaceUi.EnumMessageButton button = IInterfaceUi.EnumMessageButton.Cancel)
    {
        ShowCaption(messageType);

        ShowText(text);

        return ShowButton(button);
    }

    protected virtual IInterfaceUi.EnumMessageButton ShowButton(IInterfaceUi.EnumMessageButton button)
    {
        
        if (IsFlag(button, IInterfaceUi.EnumMessageButton.None)) 
            return IInterfaceUi.EnumMessageButton.None;
        
        ShowText("Выберите один из вариантов: ", ConsoleColor.DarkBlue);

        var buttons = new StringBuilder();

        if (IsFlag(button, IInterfaceUi.EnumMessageButton.Close)) buttons.Append("| Закрыть [З] ");
        if (IsFlag(button, IInterfaceUi.EnumMessageButton.Cancel)) buttons.Append("| Отменить [О] ");
        if (IsFlag(button, IInterfaceUi.EnumMessageButton.No)) buttons.Append("| Нет [Н] ");
        if (IsFlag(button, IInterfaceUi.EnumMessageButton.Yes)) buttons.Append("| Да [Д] ");

        ShowText(buttons.ToString(), ConsoleColor.DarkBlue);

        var key = Console.ReadKey().ToString();
        if (string.IsNullOrEmpty(key)) return IInterfaceUi.EnumMessageButton.None;

        return key.ToUpper() switch
        {
            "З" => IInterfaceUi.EnumMessageButton.Close,
            "О" => IInterfaceUi.EnumMessageButton.Cancel,
            "Н" => IInterfaceUi.EnumMessageButton.No,
            "Д" => IInterfaceUi.EnumMessageButton.Yes,
            _ => IInterfaceUi.EnumMessageButton.None,
        };
    }

    protected virtual bool IsFlag(IInterfaceUi.EnumMessageButton button, IInterfaceUi.EnumMessageButton close)
        => (button & close) == close;

    protected virtual void ShowText(string text, ConsoleColor colorText)
    {
        Console.ForegroundColor = colorText;
        Console.WriteLine($"\t{text}");
    }

    public virtual void ShowText(string text)
    {
        ShowText(text, ConsoleColor.Gray);
    }

    public virtual string? GetString()
        => Console.ReadLine();
}
