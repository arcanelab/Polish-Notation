
public class Program
{
    public static void Main(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine("Enter an expression in the arguments in Polish notation.");
            Console.WriteLine("For example: <prog> - 3 2");
            return;
        }

        string expression = "";
        for (int i = 0; i < args.Length; i++)
            expression += args[i] + (i == args.Length - 1 ? "" : " ");

        var polishNotation = new PolishNotation(expression);
        try
        {
            Console.WriteLine($"{expression} = {polishNotation.Evaluate()}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
