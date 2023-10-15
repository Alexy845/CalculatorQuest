using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CalculatorQuest;

namespace CalculatorScreen
{
    public abstract class CalculateurScreen : Window
    {
        private Calc _calc = new Calc();
        private string _operation = "";

        public CalculateurScreen()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            // Connect buttons to event handlers
            this.FindControl<Button>("Zero")!.Click += (s, e) => AddNumber("0");
            this.FindControl<Button>("Un")!.Click += (s, e) => AddNumber("1");
            this.FindControl<Button>("Deux")!.Click += (s, e) => AddNumber("2");
            this.FindControl<Button>("Trois")!.Click += (s, e) => AddNumber("3");
            this.FindControl<Button>("Quatre")!.Click += (s, e) => AddNumber("4");
            this.FindControl<Button>("Cinq")!.Click += (s, e) => AddNumber("5");
            this.FindControl<Button>("Six")!.Click += (s, e) => AddNumber("6");
            this.FindControl<Button>("Sept")!.Click += (s, e) => AddNumber("7");
            this.FindControl<Button>("Huit")!.Click += (s, e) => AddNumber("8");
            this.FindControl<Button>("Neuf")!.Click += (s, e) => AddNumber("9");


            this.FindControl<Button>("Plus")!.Click += (s, e) => AddOperator("+");
            this.FindControl<Button>("Less")!.Click += (s, e) => AddOperator("-");
            this.FindControl<Button>("Multiply")!.Click += (s, e) => AddOperator("x");
            this.FindControl<Button>("Divide")!.Click += (s, e) => AddOperator("/");
            this.FindControl<Button>("Modulo")!.Click += (s, e) => AddOperator("%");
            this.FindControl<Button>("Sign")!.Click += (s, e) => AddOperator("+/-");
            this.FindControl<Button>("Equal")!.Click += (s, e) => Calculate();
            this.FindControl<Button>("ClearAll")!.Click += (s, e) => ClearAll();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void AddNumber(string number)
        {
            _operation += number;
            UpdateOperationDisplay();
        }

        private void AddOperator(string op)
        {
            _operation += op;
            UpdateOperationDisplay();
        }

        private void Calculate()
        {
            string result = _calc.Operator(_operation);
            this.FindControl<Label>("Result")!.Content = result;
        }

        private void ClearAll()
        {
            _operation = "";
            UpdateOperationDisplay();
            this.FindControl<Label>("Result")!.Content = "";
        }

        private void UpdateOperationDisplay()
        {
            this.FindControl<Label>("Operation")!.Content = _operation;
        }
    }
}