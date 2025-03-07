
public class mainClass
{
    static void Main()
    {
        Calc calc = new Calc();
        Console.WriteLine(calc.calculate("- + 7 2 5")); //4
        Console.WriteLine(calc.calculate("- 1 + 2 3")); // -4
        Console.WriteLine(calc.calculate("- * / 15 - 7 + 1 1 3 + 2 + 1 1")); //5
        Console.WriteLine(calc.calculate("+ + 3 1 ^ 2 2")); //8
    }
}

interface ICalc
{
    void doOperation(ref Stack<int> operands, ref Stack<String> operators);

    int calculate(string input);
}

public class Calc : ICalc
{
    private string[] operators_const = { "+", "-", "*", "/", "^" };

    public void doOperation(ref Stack<int> operands, ref Stack<String> operators)
    {
        int operand2 = operands.Pop();
        int operand1 = operands.Pop();

        switch (operators.Pop())
        {
            case "+":
                operands.Push(operand1 + operand2);
                break;
            case "-":
                operands.Push(operand1 - operand2);
                break;
            case "*":
                operands.Push(operand1 * operand2);
                break;
            case "^":
                operands.Push(Convert.ToInt32(Math.Pow(operand1, operand2)));
                break;
            case "/":
                if (operand2 == 0)
                {
                    throw new DivideByZeroException("Деление на ноль");
                }
                operands.Push(operand1 / operand2);
                break;
            default:
                throw new ArgumentException("Неподдерживаемый оператор: ");
        }
    }

    public int calculate(string input)
    {
        List<String> tokens = new List<String>(input.Split(' '));
        Stack<String> operators = new Stack<string>();
        Stack<int> operands = new Stack<int>();
        bool count = false;

        int i = 0;
        do
        {
            if (i < tokens.Count)
            {
                if (operands.Count >= 2 && count)
                {
                    doOperation(ref operands, ref operators);
                    continue;
                }
                if (int.TryParse(tokens[i], out int number))
                {
                    // Если токен - число, помещаем его в стек
                    operands.Push(number);
                    if (!operators_const.Contains(tokens[i - 1]))
                        count = true;
                    else
                        count = false;
                }
                else if (operators_const.Contains(tokens[i]))
                {
                    operators.Push(tokens[i]);
                    count = false;
                }
            }
            if (count)
            {
                doOperation(ref operands, ref operators);
            }
            i++;
        } while (operators.Count >= 1);

        return operands.Pop();
    }
}

