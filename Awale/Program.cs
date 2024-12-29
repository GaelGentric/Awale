// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;
using Awale;

Console.WriteLine("Give me the first argument ('S' or 'N')");
string arg1 = Console.ReadLine();
Console.WriteLine("Give me the second argument (int between 1 and 9 include)");
string arg2 = Console.ReadLine();
Console.WriteLine("Give me the path ");
string arg3 = Console.ReadLine();


//Stopwatch stopwatch = Stopwatch.StartNew();
if (arg1 == "S")
{
    //int nbrturn = 1;
    int[] awaleboard = Rules.InitializeBoard();
    //Rules.BoardDisplayer(awaleboard);
    while (true)
    {
        int move = IA.BestMoveDeepN(awaleboard, arg2);
        //Rules.Move(awaleboard,move );
        Play.Writer('S',move,arg3);
        //Console.WriteLine($"Turn number {nbrturn}");
        //Rules.BoardDisplayer(awaleboard);
        Play.Reader(awaleboard,'S',arg3);
        //nbrturn++;
        //Console.WriteLine($"Temps écoulé : {stopwatch.Elapsed.Milliseconds} milisecondes");
    }
}
if (arg1 == "N")
{
    //int nbrturn = 0;
    int[] awaleboard = Rules.InitializeBoard();
    Play.Reader(awaleboard,'N',arg3);
    //Rules.BoardDisplayer(awaleboard);
    while (true)
    {
        Rules.ReturnBoard(awaleboard);
        int move = IA.BestMoveDeepN(awaleboard,arg2);
        //Rules.Move(awaleboard,move );
        Play.Writer('N',move + 5,arg3);
        //Console.WriteLine($"Turn number {nbrturn}");
        //Rules.BoardDisplayer(awaleboard);
        Play.Reader(awaleboard,'N',arg3);
        //nbrturn++;
        //Console.WriteLine($"Temps écoulé : {stopwatch.Elapsed.Milliseconds} milisecondes");
    }
}
/*static void PlayWithMe(string deep,bool selected,ref int winteam1,ref int winteam2)
{
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    int nbrturn = 0;
    int[] awaleboard = Rules.InitializeBoard();
    //Rules.BoardDisplayer(awaleboard);
    List<int> available = Rules.AvailableMoves(awaleboard);
    while (available.Count > 0 && awaleboard[12] < 24)
    {
        int move = IA.BestMoveDeepN(awaleboard, deep,selected);
        Rules.Move(awaleboard,move);
        //Console.WriteLine($"Turn number {nbrturn + 1}");
        //Rules.BoardDisplayer(awaleboard);
        nbrturn++;
        //Console.WriteLine($"Temps écoulé : {stopwatch.Elapsed.Milliseconds} milisecondes");
        Rules.ReturnBoard(awaleboard);
        available = Rules.AvailableMoves(awaleboard);
    }

    if (nbrturn % 2 == 1)
    {
        winteam1++;
    }
    else
    {
        winteam2++;
    }
    Console.WriteLine($"le temps moyen d'un coup à {deep} de profondeur est de : {(double)(stopwatch.ElapsedMilliseconds/nbrturn)} ticks et a duréé {nbrturn} tours pendant {stopwatch.ElapsedMilliseconds} miliseconds");
}

int winteam1 = 0;
int winteam2 = 0;
for (int i = 1; i < 1000; i++)
{
    PlayWithMe($"{1}",true,ref winteam1,ref winteam2);
    Console.WriteLine($"profondeur {1} selected terminé");
}
Console.WriteLine($"nombre de victoire team 1 : {winteam1}");
Console.WriteLine($"nombre de victoire team 2 : {winteam2}");

/*Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
winteam1 = 0;
winteam2 = 0;
for (int i = 1; i < 11; i++)
{
    PlayWithMe($"{6}",false,ref winteam1,ref winteam2);
    Console.WriteLine($"profondeur {6} non-selected terminé");
}
Console.WriteLine($"nombre de victoire team 1 : {winteam1}");
Console.WriteLine($"nombre de victoire team 2 : {winteam2}");*/



