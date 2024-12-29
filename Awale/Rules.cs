namespace Awale;

public class Rules
{
    public static int[] InitializeBoard()
    {
        int[] board = { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 0, 0 };
        return board;
    }

    public static void Move(int[] board, int move)
    {
        bool eat = false;
        int seeds = board[move];
        board[move] = 0;
        int hole = move;
        while (seeds > 0)
        {
            hole++;
            hole %= 12;
            if (hole == move)
            {
                hole++;
            }

            seeds--;
            board[hole] += 1;
        }

        while (hole >= 6 && hole < 12 && (board[hole] == 2 || board[hole] == 3))
        {
            eat = true;
            board[12] += board[hole];
            board[hole] = 0;
            hole--;
        }

        if (eat)
        {
            int[] returnedboard = (int[])board.Clone();
            ReturnBoard(returnedboard);
            List<int> returnedmoves = AvailableMoves(returnedboard);
            if (returnedmoves.Count == 0)
            {
                for (int i = 0; i < 6; i++)
                {
                    board[12] += board[i];
                }
            }
        }
    }

    public static void ReturnBoard(int[] board)
    {
        int value0 = board[0];
        int value1 = board[1];
        int value2 = board[2];
        int value3 = board[3];
        int value4 = board[4];
        int value5 = board[5];
        int value6 = board[6];
        int value7 = board[7];
        int value8 = board[8];
        int value9 = board[9];
        int value10 = board[10];
        int value11 = board[11];
        int value12 = board[12];
        int value13 = board[13];
        board[0] = value6;
        board[1] = value7;
        board[2] = value8;
        board[3] = value9;
        board[4] = value10;
        board[5] = value11;
        board[6] = value0;
        board[7] = value1;
        board[8] = value2;
        board[9] = value3;
        board[10] = value4;
        board[11] = value5;
        board[12] = value13;
        board[13] = value12;
    }

    public static void BoardDisplayer(int[] board)
    {
        Console.WriteLine($"| {board[11]} | {board[10]} | {board[9]} | {board[8]} | {board[7]} | {board[6]} |");
        Console.WriteLine($"| {board[0]} | {board[1]} | {board[2]} | {board[3]} | {board[4]} | {board[5]} |");
        Console.WriteLine($"my score : {board[12]}");
        Console.WriteLine($"opposent score : {board[13]}");
    }

    public static List<int> AvailableMoves(int[] board)
    {
        List<int> result = new List<int>();
        for (int i = 0; i < 6; i++)
        {
            if (board[i] > 0 && DontEatAllSeed(board,i))
            {
                result.Add(i);
            }
        }

        return result;
    }

    public static bool DontEatAllSeed(int[] board, int move)
    {
        bool eat = false;
        int arrivehole = (move + board[move]) % 12;
        if (arrivehole == move)
            arrivehole++;
        if (board[arrivehole] == 1 || board[arrivehole] == 2)
        {
            eat = true;
        }
        bool allholeempty = true;
        if (eat)
        {
            int[] tryboard = (int[])board.Clone();
            Move(tryboard, move);
            for (int i = 6; i < 12; i++)
            {
                if (tryboard[i] > 0)
                {
                    allholeempty = false;
                }
            }
        }

        return !(allholeempty && eat);
    }

    public static void PlayerTurn(int[] board)
    {
        Console.WriteLine("What is your move ?");
        string input = Console.ReadLine();
        int inputvalue = -1;
        while (!Int32.TryParse(input,out int inputavalue) && inputavalue < 0 && inputavalue > 5)
        {
            Console.WriteLine("What is your move ?");
            input = Console.ReadLine();
        }
        Move(board,inputvalue);
    }
    
}