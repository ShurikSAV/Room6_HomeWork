using System.Text;

namespace GuessTheNumberConsole.InterfaceUI;

//Принцип открытости/закрытости
internal sealed class ConsoleUiEng : ConsoleUi
{
    protected override void ShowCaption(IInterfaceUi.EnumMessageType messageType)
    {
        switch (messageType)
        {
            case IInterfaceUi.EnumMessageType.None:
                break;
            case IInterfaceUi.EnumMessageType.Warning:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Warning:");
                break;
            case IInterfaceUi.EnumMessageType.Error:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Question:");
                break;
            case IInterfaceUi.EnumMessageType.Info:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Information:");
                break;
            case IInterfaceUi.EnumMessageType.Question:
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Question:");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(messageType), messageType, null);
        }
    }

    protected override IInterfaceUi.EnumMessageButton ShowButton(IInterfaceUi.EnumMessageButton button)
    {

        if (IsFlag(button, IInterfaceUi.EnumMessageButton.None))
            return IInterfaceUi.EnumMessageButton.None;

        ShowText("Choose one of the options: ", ConsoleColor.DarkBlue);

        var buttons = new StringBuilder();

        if (IsFlag(button, IInterfaceUi.EnumMessageButton.Close)) buttons.Append("| Exit [E] ");
        if (IsFlag(button, IInterfaceUi.EnumMessageButton.Cancel)) buttons.Append("| Cancel [C] ");
        if (IsFlag(button, IInterfaceUi.EnumMessageButton.No)) buttons.Append("| No [N] ");
        if (IsFlag(button, IInterfaceUi.EnumMessageButton.Yes)) buttons.Append("| Yes [Y] ");

        ShowText(buttons.ToString(), ConsoleColor.DarkBlue);

        var key = Console.ReadKey().ToString();
        if (string.IsNullOrEmpty(key)) return IInterfaceUi.EnumMessageButton.None;

        return key.ToUpper() switch
        {
            "E" => IInterfaceUi.EnumMessageButton.Close,
            "C" => IInterfaceUi.EnumMessageButton.Cancel,
            "N" => IInterfaceUi.EnumMessageButton.No,
            "Y" => IInterfaceUi.EnumMessageButton.Yes,
            _ => IInterfaceUi.EnumMessageButton.None,
        };
    }
}
