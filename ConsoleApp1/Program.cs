using System.Net;

public class Calc
{
    static void Main()
    {
        Calc calc = new Calc();
        //Console.WriteLine(calc.calculate("- + 7 2 3"));
        //Console.WriteLine(calc.calculate("- * + 7 2 3 5"));
        //Console.WriteLine(calc.calculate("- 1 + 2 3"));
    }

    public int calculate(string input)
    {
        List<String> tokens = new List<String>(input.Split(' ')); 
        Stack<int> stack = new Stack<int>();
        for (int i = 0; i<tokens.Count; i++) // tokens - операторы
        {
            if (int.TryParse(tokens[i], out int number))
            {
                // Если токен - число, помещаем его в стек
                stack.Push(number);
                tokens.RemoveAt(i--);
            }
            if (stack.Count == 2)
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
}

