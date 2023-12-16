namespace GuessTheNumberConsole.InterfaceUI
{
    //Принцип открытости/закрытости
    internal class ConsoleUI_Eng : ConsoleUI
    {
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

    }
}
