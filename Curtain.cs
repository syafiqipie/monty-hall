internal struct Curtain
{
    public int Number {get; set;}
    public Prize Prize {get;set;}
    public Curtain(int number, Prize prize)
    {
        Number = number;
        Prize = prize;
    }
}

internal enum Prize
{
    Zonk,
    Money,
}