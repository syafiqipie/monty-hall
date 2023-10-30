Random random = new();
int ChangeAndWin = 0;
int StayAndWin = 0;
int ChangeAndLose = 0;
int StayAndLose = 0;
for(int i = 0; i < 1000; i++)
{
    (bool, bool) result = Test.Begin(random);
    switch(result)
    {
        case (true, true) : ChangeAndWin++;
        break;
        case (false, true) : StayAndWin++;
        break;
        case (true, false) : ChangeAndLose++;
        break;
        case (false, false) : StayAndLose++;
        break; 
    }
}

Console.WriteLine(nameof(ChangeAndWin) + $": {ChangeAndWin}");
Console.WriteLine(nameof(StayAndWin) + $": {StayAndWin}");
Console.WriteLine(nameof(ChangeAndLose) + $": {ChangeAndLose}");
Console.WriteLine(nameof(StayAndLose) + $": {StayAndLose}");
