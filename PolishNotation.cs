public class PolishNotation
{
    private string expression;

    public PolishNotation(string expression)
    {
        this.expression = expression;
    }

    public double Evaluate()
    {
        return Evaluate(expression);
    }

    public double Evaluate(string expression)
    {
        var tokens = expression.Split(" ");
        var validOperators = new string[] { "-", "+", "*", "/", "^" };
        var operators = new Stack<string>();
        var operands = new Stack<double>();

        foreach (var token in tokens)
        {
            Console.WriteLine($"token = {token}");
            if (validOperators.Contains(token))
            {
                operators.Push(token);
            }
            else
            {
                double operand = 0;
                try
                {
                    operand = double.Parse(token);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Invalid expression format at token {token}.\nException = {e.Message}");
                    throw;
                }

                operands.Push(operand);
            }
        }

        while (operators.Count > 0)
        {
            string op = operators.Pop();
            var right = operands.Pop();
            var left = operands.Pop();

            switch (op)
            {
                case "+":
                    operands.Push(left + right);
                    break;
                case "-":
                    operands.Push(left - right);
                    break;
                case "*":
                    operands.Push(left * right);
                    break;
                case "/":
                    operands.Push(left / right);
                    break;
                case "^":
                    operands.Push(Math.Pow(left, right));
                    break;
            }
        }

        if (operands.Count != 1)
        {
            throw new Exception("Invalid expression");
        }

        return operands.Pop();
    }
}
