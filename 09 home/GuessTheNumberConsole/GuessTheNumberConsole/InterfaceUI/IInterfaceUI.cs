namespace GuessTheNumberConsole.InterfaceUI;

//Принцип единственной ответственности
//Принцип разделения интерфейса

/// <summary>
/// Интерфейс приложения
/// </summary>
internal interface IInterfaceUi
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
        /// <summary>
        /// Вопрос
        /// </summary>
        Question,
    }
    [Flags]
    public enum EnumMessageButton
    {
        None = 0,  // 0
        Yes = 0b1,
        No = Yes << 1,
        Cancel = No << 1,
        Close = Cancel << 1,
    }

    /// <summary>
    /// Обобразить сообщение
    /// </summary>
    /// <param name="text"></param>
    /// <param name="messageType"></param>
    /// <param name="button"></param>
    EnumMessageButton ShowMessage(string text, EnumMessageType messageType = EnumMessageType.Info, EnumMessageButton button = EnumMessageButton.None);
    /// <summary>
    /// Вывести текст
    /// </summary>
    /// <param name="text"></param>
    void ShowText(string text);
    /// <summary>
    /// Пользовательский ввод
    /// </summary>
    /// <returns></returns>
    string? GetString();
}