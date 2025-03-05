public class Calc
{
    static void Main()
    {
        Calc calc = new Calc();
        Console.WriteLine(calc.calculate("- + 7 2 5")); //4
        Console.WriteLine(calc.calculate("- 1 + 2 3")); // -4
        //Console.WriteLine(calc.calculate(" - * / 15 - 7 + 1 1 3 + 2 + 1 1")); //5
    }

    private string[] operators_const = { "+", "-", "*", "/" };

    public int calculate2(string input)
    {
        List<String> tokens = new List<String>(input.Split(' ')); 
        Stack<int> stack = new Stack<int>();
        bool waiting = false;
        for (int i = 0; i<tokens.Count; i++) // tokens - операторы
        {
            if (int.TryParse(tokens[i], out int number))
            {
                // Если токен - число, помещаем его в стек
                stack.Push(number);
                tokens.RemoveAt(i--);

                //"- 1 + 2 3"
                if (stack.Count == 1)
                    waiting = true;
                if (stack.Count == 3)
                    waiting = false;
            }
            if (stack.Count >= 2 && !waiting)
            {
                int operand2 = stack.Pop();
                int operand1 = stack.Pop();

                switch (tokens[i])
                {
                    case "+":
                        stack.Push(operand1 + operand2);
                        tokens.RemoveAt(i--);
                        break;
                    case "-":
                        stack.Push(operand1 - operand2);
                        tokens.RemoveAt(i--);
                        break;
                    case "*":
                        stack.Push(operand1 * operand2);
                        tokens.RemoveAt(i--);
                        break;
                    case "/":
                        if (operand2 == 0)
                        {
                            throw new DivideByZeroException("Деление на ноль");
                        }
                        stack.Push(operand1 / operand2);
                        tokens.RemoveAt(i--);
                        break;
                    default:
                        throw new ArgumentException("Неподдерживаемый оператор: " + tokens[i]);
                }
            }
        }

        //if (stack.Count != 1)
        //{
        //    throw new ArgumentException("Некорректное выражение");
        //}

        return stack.Pop();
    }

    public int calculate(string input)
    {
        List<String> tokens = new List<String>(input.Split(' '));
        Stack<String> operators = new Stack<string>();
        Stack<int> operands = new Stack<int>();
        bool waiting = false;

        int i = 0;
        //for (int i = 0; i < tokens.Count; i++)
        do
        {
            if (i< tokens.Count)
            {
                if (int.TryParse(tokens[i], out int number))
                {
                    // Если токен - число, помещаем его в стек
                    operands.Push(number);
                }
                else if (operators_const.Contains(tokens[i]))
                {
                    operators.Push(tokens[i]);

                    if (operands.Count == 1)
                        waiting = true;
                }
            }
            if (operands.Count >= 2 && !waiting)
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
                    case "/":
                        if (operand2 == 0)
                        {
                            throw new DivideByZeroException("Деление на ноль");
                        }
                        operands.Push(operand1 / operand2);
                        break;
                    default:
                        throw new ArgumentException("Неподдерживаемый оператор: " + tokens[i]);
                }
            }
            else if (operands.Count >= 2 && waiting)
            {
                waiting = false;   
            }
            i++;
        } while (operators.Count >=1);

        //if (stack.Count != 1)
        //{
        //    throw new ArgumentException("Некорректное выражение");
        //}

        return operands.Pop();
    }
}

