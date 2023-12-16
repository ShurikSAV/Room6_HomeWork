using System.Text;

namespace GuessTheNumberConsole.InterfaceUI;

//Принцип открытости/закрытости
internal class ConsoleUI_Eng : ConsoleUI
{
    virtual public string Name => "New ConsoleUI_Eng";

    override public void ShowCaption(IInterfaceUI.EnumMessageType messageType)
    {
        switch (messageType)
        {
            case IInterfaceUI.EnumMessageType.None:
                break;
            case IInterfaceUI.EnumMessageType.Warning:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Warning:");
                break;
            case IInterfaceUI.EnumMessageType.Error:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Question:");
                break;
            case IInterfaceUI.EnumMessageType.Info:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Information:");
                break;
            case IInterfaceUI.EnumMessageType.Question:
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Question:");
                break;
        }
    }

    override public IInterfaceUI.EnumMessageButton ShowButton(IInterfaceUI.EnumMessageButton button)
    {

        if (isFlag(button, IInterfaceUI.EnumMessageButton.None))
            return IInterfaceUI.EnumMessageButton.None;

        ShowText("Choose one of the options: ", ConsoleColor.DarkBlue);

        var buttons = new StringBuilder();

        if (isFlag(button, IInterfaceUI.EnumMessageButton.Close)) buttons.Append("| Exit [E] ");
        if (isFlag(button, IInterfaceUI.EnumMessageButton.Cancel)) buttons.Append("| Cancel [C] ");
        if (isFlag(button, IInterfaceUI.EnumMessageButton.No)) buttons.Append("| No [N] ");
        if (isFlag(button, IInterfaceUI.EnumMessageButton.Yes)) buttons.Append("| Yes [Y] ");

        ShowText(buttons.ToString(), ConsoleColor.DarkBlue);

        var key = Console.ReadKey().ToString();
        if (string.IsNullOrEmpty(key)) return IInterfaceUI.EnumMessageButton.None;

        return key.ToUpper() switch
        {
            "E" => IInterfaceUI.EnumMessageButton.Close,
            "C" => IInterfaceUI.EnumMessageButton.Cancel,
            "N" => IInterfaceUI.EnumMessageButton.No,
            "Y" => IInterfaceUI.EnumMessageButton.Yes,
            _ => IInterfaceUI.EnumMessageButton.None,
        };
    }
}
