internal static class Test
{
    public static (bool, bool) Begin(Random random)
    {
        IList<Curtain> curtains = new List<Curtain>()
        {
            new(1, Prize.Zonk),
            new(2, Prize.Zonk),
            new(3, Prize.Money),
        };

        Curtain firstChoice = GetRandomChoice(random, curtains);

        IList<Curtain> remainingCurtains = curtains.CreateNewExcept(firstChoice);

        Curtain hostReveal = remainingCurtains.Count(c => c.Prize == Prize.Zonk) == 1
            ? remainingCurtains.First(c => c.Prize == Prize.Zonk)
            : GetRandomChoice(random, remainingCurtains);
        
        bool isChanged = Convert.ToBoolean((int)( random.NextDouble() * 2 ));
        Curtain secondChoice = isChanged
            ? curtains.CreateNewExcept(firstChoice).CreateNewExcept(hostReveal).First()
            : firstChoice;
        
        bool isWinning = secondChoice.Prize is Prize.Money;

        return (isChanged, isWinning);
    }

    static Curtain GetRandomChoice(Random random, IList<Curtain> curtains)
    {
        int index = (int)( random.NextDouble() * curtains.Count );
        return curtains[index];
    }

    static IList<Curtain> CreateNewExcept(this IList<Curtain> curtains, Curtain curtain)
    {
        IList<Curtain> subtracted = new List<Curtain>(curtains);
        subtracted.Remove(curtain); 
        return subtracted;

    } 
}