namespace GuessTheNumberConsole.Genegator;

internal interface IGenegator
{
    /// <summary>
    /// Генератор числа
    /// </summary>
    /// <param name="min">минимальное</param>
    /// <param name="max">максимальное</param>
    /// <returns></returns>
    int GenegatorInt(int min, int max);
}
