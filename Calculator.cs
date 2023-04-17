using System.Text;

namespace Calculator
{
    internal class Calculator
    {
        private double _result;
        private StringBuilder _number;
        private char? _operation;
        private bool _isNewNumber;

        public Calculator()
        {
            _number = new StringBuilder();
            _operation = null;
            _result = 0;
            _isNewNumber = true;
        }

        public void Run()
        {
            ConsoleKeyInfo button;
            Console.Clear();
            Console.WriteLine(_result);
            do
            {                
                button = Keyboard.GetButton();
                if (Keyboard.NumberKeys.Contains(button.Key))
                {
                    _number.Append(button.Key == ConsoleKey.Decimal ? ',' : button.KeyChar);
                    if (_isNewNumber)
                    {
                        _result = double.Parse(_number.ToString());
                        Output();
                    }                   
                }
                else if (Keyboard.OperatorKeys.Contains(button.Key))
                {
                    if (_isNewNumber)
                    {
                        _operation = button.KeyChar;
                        _isNewNumber = false;
                        Output();
                    }
                    else
                    {
                        Calculate(button);                        
                    }
                }
                else if (button.Key == ConsoleKey.Enter)
                {
                    if (_isNewNumber)
                    {
                        _isNewNumber = false;
                        Output();
                    }
                    else
                    {
                        Calculate(null);
                    }
                }
                else if (button.Key == ConsoleKey.C)
                {
                    Clear();
                }
            } while (button.Key != ConsoleKey.Escape);
        }

        private void Clear() 
        {
            _number = new StringBuilder();
            _operation = null;
            _result = 0;
            Output();
            _isNewNumber = true;
        }

        private void Calculate(ConsoleKeyInfo? newOperation) 
        { 
            double? operand = _number.Length != 0 ? double.Parse(_number.ToString()) : null;
            _result = (_operation, operand) switch
            {
                { _operation: '+', operand: not null } => _result + operand.Value,
                { _operation: '-', operand: not null } => _result - operand.Value,
                { _operation: '*', operand: not null } => _result * operand.Value,
                { _operation: '/', operand: not null } => _result / operand.Value,
                { _operation: '/', operand: null } => 1 / _result, // обратное
                { _operation: '-', operand: null } => - _result, // противоположное
                { _operation: null, operand: not null } => operand.Value,
                _ => _result
            };
            _number = new();
            _operation = newOperation?.KeyChar ?? _operation;
            Output();
        }

        private void Output()
        {
            Console.Clear();
            Console.WriteLine($"{_result} {_operation}");
        }
    }
}
