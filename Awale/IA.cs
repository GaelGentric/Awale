using System.Data;

namespace Awale;

public class IA
{
    public static double CostFunction(int[] board)
    {
        if (board[12] > 24)
        {
            return 999999;
        }
        else
        {
            Random _random = new Random();
            return board[12] - board[13] + _random.NextDouble() * 0.10;
        }
    }

    public static int BestMoveDeepN(int[] board, string n)// bool selected)
    {
        if (n == "1")
        {
            return BestMoveDeep1(board);
        }
        if (n == "2")
        {
            return BestMoveDeep2(board);
        }
        if (n == "3")
        {
            return BestMoveDeep3(board);            
        }
        if (n == "4")
        {
            return BestMoveDeep4(board);
        }
        if (n == "5")
        {
            return BestMoveDeep5(board);
        }
        if (n == "6")
        { 
            return BestMoveDeep6(board);
        }
        if (n == "7")
        {
            return BestMoveDeep7(board);
        }
        if (n == "8")
        {
            return BestMoveDeep8(board);
        }
        else
        {
            return BestMoveDeep9(board);
        }
    }

    public static int BestMoveDeep1(int[] board)
    {
        List<int> moves = Rules.AvailableMoves(board);
        int bestmove = moves[0];
        int[] tryboard = (int[])board.Clone();
        Rules.Move(tryboard,bestmove);
        double highervalue = CostFunction(tryboard);
        for (int i = 1; i < moves.Count; i++)
        {
            tryboard = (int[])board.Clone();
            Rules.Move(tryboard,moves[i]);
            if (CostFunction(tryboard) > highervalue)
            {
                bestmove = moves[i];
                highervalue = CostFunction(tryboard);
            }
        }

        return bestmove;
    }
    

    public static int BestMoveDeep2(int[] board)
    {
        List<int> moves = Rules.AvailableMoves(board);
        int bestmove = moves[0];
        int[] tryboard = (int[])board.Clone();
        Rules.Move(tryboard,bestmove);
        double highervalue = CostFunction(tryboard);
        for (int i = 0; i < moves.Count; i++)
        {
            tryboard = (int[])board.Clone();
            Rules.Move(tryboard,moves[i]);
            Rules.ReturnBoard(tryboard);
            List<int> opponentmoves = Rules.AvailableMoves(tryboard);
            if (opponentmoves.Count == 0)
            {
                continue;
            }
            Rules.Move(tryboard,BestMoveDeep1(tryboard));
            Rules.ReturnBoard(tryboard);
            List<int> deepermoves = Rules.AvailableMoves(tryboard);
            if (deepermoves.Count == 0)
            {
                continue;
            }
            Rules.Move(tryboard,BestMoveDeep1(tryboard));
            if (CostFunction(tryboard) > highervalue)
            {
                bestmove = moves[i];
                highervalue = CostFunction(tryboard);
            }
        }
        return bestmove;
    }
    public static int BestMoveDeep3(int[] board)
    {
        List<int> moves = Rules.AvailableMoves(board);
        int bestmove = moves[0];
        int[] tryboard = (int[])board.Clone();
        Rules.Move(tryboard,bestmove);
        double highervalue = CostFunction(tryboard);
        for (int i = 0; i < moves.Count; i++)
        {
            tryboard = (int[])board.Clone();
            Rules.Move(tryboard,moves[i]);
            Rules.ReturnBoard(tryboard);
            List<int> opponentmoves = Rules.AvailableMoves(tryboard);
            if (opponentmoves.Count == 0)
            {
                continue;
            }
            Rules.Move(tryboard,BestMoveDeep2(tryboard));
            Rules.ReturnBoard(tryboard);
            List<int> deepermoves = Rules.AvailableMoves(tryboard);
            if (deepermoves.Count == 0)
            {
                continue;
            }
            Rules.Move(tryboard,BestMoveDeep2(tryboard));
            if (CostFunction(tryboard) > highervalue)
            {
                bestmove = moves[i];
                highervalue = CostFunction(tryboard);
            }
        }
        return bestmove;
    }
    
    public static int BestMoveDeep3Selected(int[] board)
    {
        List<int> moves = Rules.AvailableMoves(board);
        int bestmove = moves[0];
        int[] tryboard = (int[])board.Clone();
        Rules.Move(tryboard,bestmove);
        double highervalue = CostFunction(tryboard);
        for (int i = 0; i < moves.Count; i++)
        {
            tryboard = (int[])board.Clone();
            Rules.Move(tryboard,moves[i]);
            Rules.ReturnBoard(tryboard);
            List<int> opponentmoves = Rules.AvailableMoves(tryboard);
            if (opponentmoves.Count == 0)
            {
                continue;
            }
            Rules.Move(tryboard,BestMoveDeep2(tryboard));
            Rules.ReturnBoard(tryboard);
            if (CostFunction(board) < 0)
            {
                continue;   
            }
            List<int> deepermoves = Rules.AvailableMoves(tryboard);
            if (deepermoves.Count == 0)
            {
                continue;
            }
            Rules.Move(tryboard,BestMoveDeep2(tryboard));
            if (CostFunction(tryboard) > highervalue)
            {
                bestmove = moves[i];
                highervalue = CostFunction(tryboard);
            }
        }
        return bestmove;
    }
    
    public static int BestMoveDeep4(int[] board)
    {
        List<int> moves = Rules.AvailableMoves(board);
        int bestmove = moves[0];
        int[] tryboard = (int[])board.Clone();
        Rules.Move(tryboard,bestmove);
        double highervalue = CostFunction(tryboard);
        for (int i = 0; i < moves.Count; i++)
        {
            tryboard = (int[])board.Clone();
            Rules.Move(tryboard,moves[i]);
            Rules.ReturnBoard(tryboard);
            List<int> opponentmoves = Rules.AvailableMoves(tryboard);
            if (opponentmoves.Count == 0)
            {
                continue;
            }
            Rules.Move(tryboard,BestMoveDeep3(tryboard));
            Rules.ReturnBoard(tryboard);
            List<int> deepermoves = Rules.AvailableMoves(tryboard);
            if (deepermoves.Count == 0)
            {
                continue;
            }
            Rules.Move(tryboard,BestMoveDeep3(tryboard));
            if (CostFunction(tryboard) > highervalue)
            {
                bestmove = moves[i];
                highervalue = CostFunction(tryboard);
            }
        }
        return bestmove;
    }
    
    public static int BestMoveDeep5(int[] board)
    {
        List<int> moves = Rules.AvailableMoves(board);
        int bestmove = moves[0];
        int[] tryboard = (int[])board.Clone();
        Rules.Move(tryboard,bestmove);
        double highervalue = CostFunction(tryboard);
        for (int i = 0; i < moves.Count; i++)
        {
            tryboard = (int[])board.Clone();
            Rules.Move(tryboard,moves[i]);
            Rules.ReturnBoard(tryboard);
            List<int> opponentmoves = Rules.AvailableMoves(tryboard);
            if (opponentmoves.Count == 0)
            {
                continue;
            }
            Rules.Move(tryboard,BestMoveDeep4(tryboard));
            Rules.ReturnBoard(tryboard);
            List<int> deepermoves = Rules.AvailableMoves(tryboard);
            if (deepermoves.Count == 0)
            {
                continue;
            }
            Rules.Move(tryboard,BestMoveDeep4(tryboard));
            if (CostFunction(tryboard) > highervalue)
            {
                bestmove = moves[i];
                highervalue = CostFunction(tryboard);
            }
        }
        return bestmove;
    }
    public static int BestMoveDeep5Selected(int[] board)
    {
        List<int> moves = Rules.AvailableMoves(board);
        int bestmove = moves[0];
        int[] tryboard = (int[])board.Clone();
        Rules.Move(tryboard,bestmove);
        double highervalue = CostFunction(tryboard);
        for (int i = 0; i < moves.Count; i++)
        {
            tryboard = (int[])board.Clone();
            Rules.Move(tryboard,moves[i]);
            Rules.ReturnBoard(tryboard);
            List<int> opponentmoves = Rules.AvailableMoves(tryboard);
            if (opponentmoves.Count == 0)
            {
                continue;
            }
            Rules.Move(tryboard,BestMoveDeep4(tryboard));
            Rules.ReturnBoard(tryboard);
            List<int> deepermoves = Rules.AvailableMoves(tryboard);
            if (deepermoves.Count == 0)
            {
                continue;
            }
            Rules.Move(tryboard,BestMoveDeep4(tryboard));
            if (CostFunction(tryboard) > highervalue)
            {
                bestmove = moves[i];
                highervalue = CostFunction(tryboard);
            }
        }
        return bestmove;
    }
    
    public static int BestMoveDeep6(int[] board)
    {
        List<int> moves = Rules.AvailableMoves(board);
        int bestmove = moves[0];
        int[] tryboard = (int[])board.Clone();
        Rules.Move(tryboard,bestmove);
        double highervalue = CostFunction(tryboard);
        for (int i = 0; i < moves.Count; i++)
        {
            tryboard = (int[])board.Clone();
            Rules.Move(tryboard,moves[i]);
            Rules.ReturnBoard(tryboard);
            List<int> opponentmoves = Rules.AvailableMoves(tryboard);
            if (opponentmoves.Count == 0)
            {
                continue;
            }
            Rules.Move(tryboard,BestMoveDeep5(tryboard));
            Rules.ReturnBoard(tryboard);
            if (CostFunction(board) < 0)
            {
                continue;   
            }
            List<int> deepermoves = Rules.AvailableMoves(tryboard);
            if (deepermoves.Count == 0)
            {
                continue;
            }
            Rules.Move(tryboard,BestMoveDeep5(tryboard));
            if (CostFunction(tryboard) > highervalue)
            {
                bestmove = moves[i];
                highervalue = CostFunction(tryboard);
            }
        }
        return bestmove;
    }
    
    public static int BestMoveDeep6Selected(int[] board)
    {
        List<int> moves = Rules.AvailableMoves(board);
        int bestmove = moves[0];
        int[] tryboard = (int[])board.Clone();
        Rules.Move(tryboard,bestmove);
        double highervalue = CostFunction(tryboard);
        for (int i = 0; i < moves.Count; i++)
        {
            tryboard = (int[])board.Clone();
            Rules.Move(tryboard,moves[i]);
            Rules.ReturnBoard(tryboard);
            List<int> opponentmoves = Rules.AvailableMoves(tryboard);
            if (opponentmoves.Count == 0)
            {
                continue;
            }
            Rules.Move(tryboard,BestMoveDeep5(tryboard));
            Rules.ReturnBoard(tryboard);
            if (CostFunction(board) < 0)
            {
                continue;   
            }
            List<int> deepermoves = Rules.AvailableMoves(tryboard);
            if (deepermoves.Count == 0)
            {
                continue;
            }
            Rules.Move(tryboard,BestMoveDeep5(tryboard));
            if (CostFunction(tryboard) > highervalue)
            {
                bestmove = moves[i];
                highervalue = CostFunction(tryboard);
            }
        }
        return bestmove;
    }
    public static int BestMoveDeep7(int[] board)
    {
        List<int> moves = Rules.AvailableMoves(board);
        int bestmove = moves[0];
        int[] tryboard = (int[])board.Clone();
        Rules.Move(tryboard,bestmove);
        double highervalue = CostFunction(tryboard);
        for (int i = 0; i < moves.Count; i++)
        {
            tryboard = (int[])board.Clone();
            Rules.Move(tryboard,moves[i]);
            Rules.ReturnBoard(tryboard);
            List<int> opponentmoves = Rules.AvailableMoves(tryboard);
            if (opponentmoves.Count == 0)
            {
                continue;
            }
            Rules.Move(tryboard,BestMoveDeep6(tryboard));
            Rules.ReturnBoard(tryboard);
            List<int> deepermoves = Rules.AvailableMoves(tryboard);
            if (deepermoves.Count == 0)
            {
                continue;
            }
            Rules.Move(tryboard,BestMoveDeep6(tryboard));
            if (CostFunction(tryboard) > highervalue)
            {
                bestmove = moves[i];
                highervalue = CostFunction(tryboard);
            }
        }
        return bestmove;
    }
    
    public static int BestMoveDeep8(int[] board)
    {
        List<int> moves = Rules.AvailableMoves(board);
        int bestmove = moves[0];
        int[] tryboard = (int[])board.Clone();
        Rules.Move(tryboard,bestmove);
        double highervalue = CostFunction(tryboard);
        for (int i = 0; i < moves.Count; i++)
        {
            tryboard = (int[])board.Clone();
            Rules.Move(tryboard,moves[i]);
            Rules.ReturnBoard(tryboard);
            List<int> opponentmoves = Rules.AvailableMoves(tryboard);
            if (opponentmoves.Count == 0)
            {
                continue;
            }
            Rules.Move(tryboard,BestMoveDeep7(tryboard));
            Rules.ReturnBoard(tryboard);
            List<int> deepermoves = Rules.AvailableMoves(tryboard);
            if (deepermoves.Count == 0)
            {
                continue;
            }
            Rules.Move(tryboard,BestMoveDeep7(tryboard));
            if (CostFunction(tryboard) > highervalue)
            {
                bestmove = moves[i];
                highervalue = CostFunction(tryboard);
            }
        }
        return bestmove;
    }
    
    public static int BestMoveDeep9(int[] board)
    {
        List<int> moves = Rules.AvailableMoves(board);
        int bestmove = moves[0];
        int[] tryboard = (int[])board.Clone();
        Rules.Move(tryboard,bestmove);
        double highervalue = CostFunction(tryboard);
        for (int i = 0; i < moves.Count; i++)
        {
            tryboard = (int[])board.Clone();
            Rules.Move(tryboard,moves[i]);
            Rules.ReturnBoard(tryboard);
            List<int> opponentmoves = Rules.AvailableMoves(tryboard);
            if (opponentmoves.Count == 0)
            {
                continue;
            }
            Rules.Move(tryboard,BestMoveDeep8(tryboard));
            Rules.ReturnBoard(tryboard);
            List<int> deepermoves = Rules.AvailableMoves(tryboard);
            if (deepermoves.Count == 0)
            {
                continue;
            }
            Rules.Move(tryboard,BestMoveDeep8(tryboard));
            if (CostFunction(tryboard) > highervalue)
            {
                bestmove = moves[i];
                highervalue = CostFunction(tryboard);
            }
        }
        return bestmove;
    }
}