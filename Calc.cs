namespace CalculatorQuest
{
    public class Calc
    {
        private string[] _signs = new string[] { "+", "-", "x", "/", "%" };

        public Calc() { }

        public string Operator(string operation)
        {
            if (string.IsNullOrEmpty(operation))
                return "Please enter an operation";

            int operatorCount = 0;
            foreach (string sign in _signs)
            {
                if (operation.Contains(sign))
                    operatorCount++;
            }

            if (operatorCount > 1)
                return "Only one operation please";

            string result = "";
            foreach (string sign in _signs)
            {
                if (operation.Contains(sign))
                {
                    string[] operands = operation.Split(sign);
                    double operand1 = double.Parse(operands[0]);
                    double operand2 = double.Parse(operands[1]);

                    switch (sign)
                    {
                        case "+":
                            result = (operand1 + operand2).ToString();
                            break;
                        case "-":
                            result = (operand1 - operand2).ToString();
                            break;
                        case "x":
                            result = (operand1 * operand2).ToString();
                            break;
                        case "/":
                            if (operand2 != 0)
                                result = (operand1 / operand2).ToString();
                            else
                                result = "Division by 0 is IMPOSSIBLE";
                            break;
                        case "%":
                            if (operand2 != 0)
                                result = (operand1 % operand2).ToString();
                            else
                                result = "Erreur : Modulo par zéro";
                            break;
                    }
                    break;
                }
            }
            return result;
        }
    }
}
