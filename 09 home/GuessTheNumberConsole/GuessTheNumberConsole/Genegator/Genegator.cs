namespace GuessTheNumberConsole.Genegator;

internal class Genegator : IGenegator
{
    public int GenegatorInt(int min, int max)
        => new Random().Next(min, max);
}
