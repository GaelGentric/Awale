namespace Awale;

public class Play
{
    public static void Reader(int[] board,char side, string path)
    {
        if (side == 'S')
        {
            bool find = File.Exists($"{path}sud.txt");
            while (!find)
            {
                find = File.Exists($"{path}sud.txt");
                Console.WriteLine("j'attend de trouver le fichier : zzzzz ");
                Thread.Sleep(10);
            }
            using (StreamReader _reader = new StreamReader($"{path}sud.txt"))
            {
                string input = _reader.ReadToEnd();
                string[] lines = input.Split('\r');
                for (int i = 0; i < 14; i++)
                {
                    string inputvalue = lines[i];
                    string inputvaluenumbers = "";
                    foreach (var c in inputvalue)
                    {
                        if (char.IsDigit(c))
                        {
                            inputvaluenumbers = inputvaluenumbers + c;
                        }
                    }
                    Console.WriteLine($"inputvalue vaut : {inputvalue} et inputvaluenumbers vaut :{inputvaluenumbers}");
                    board[i] = int.Parse(inputvaluenumbers);
                }
            }
            File.Delete($"{path}sud.txt");
        }
        if (side == 'N')
        {
            while (!File.Exists($"{path}nord.txt"))
            {
                Thread.Sleep(10);
            }
            using (StreamReader _reader = new StreamReader($"{path}nord.txt"))
            {
                string input = _reader.ReadToEnd();
                string[] lines = input.Split('\r');
                for (int i = 0; i < lines.Length; i++)
                {
                    board[i] = int.Parse(lines[i]);
                }
            }
            File.Delete($"{path}nord.txt");
        }
    }

    public static void Writer(char side, int move, string path)
    {
        if (side == 'S')
        {
            using (StreamWriter sw = new StreamWriter($"{path}reponse_sud.txt"))
            {
                sw.Write(move);
            }
        }
        if (side == 'N')
        {
            using (StreamWriter sw = new StreamWriter($"{path}reponse_nord.txt"))
            {
                sw.Write(move);
            }
        }
    }
}