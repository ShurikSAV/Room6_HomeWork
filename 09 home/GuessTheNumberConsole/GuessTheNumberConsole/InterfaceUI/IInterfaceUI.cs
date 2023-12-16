namespace GuessTheNumberConsole.InterfaceUI;

/// <summary>
/// Интерфейс приложения
/// </summary>
internal interface IInterfaceUI
{
    public enum EnumMessageType 
    { 
        None,
        /// <summary>
        /// Информационное
        /// </summary>
        Info,
        /// <summary>
        /// Предупреждение
        /// </summary>
        Warning,
        /// <summary>
        /// Ошибка
        /// </summary>
        Error,
    }
    [Flags]
    public enum EnumMessageButton
    {
        None = 0,  // 0
        Yes = 1,
        No = Yes >> 1,
        Cancel = No >> 1,
        Close = Cancel >> 1,
    }

    /// <summary>
    /// Обобразить сообщение
    /// </summary>
    /// <param name="text"></param>
    /// <param name="messageType"></param>
    /// <param name="button"></param>
    EnumMessageButton ShowMessage(string text, EnumMessageType messageType = EnumMessageType.Info, EnumMessageButton button = EnumMessageButton.None);

    void ShowText(string text);
}