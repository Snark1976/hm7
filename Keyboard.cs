using System.Collections.ObjectModel;

namespace Calculator
{
    internal static class Keyboard
    {
        public static readonly ReadOnlyCollection<ConsoleKey> ControlKeys = new(new List<ConsoleKey>()
        {
            ConsoleKey.Escape,
            ConsoleKey.Enter, 
            ConsoleKey.C,
        });

        public static readonly ReadOnlyCollection<ConsoleKey> NumberKeys = new(new List<ConsoleKey>()
        {
            ConsoleKey.NumPad0,
            ConsoleKey.NumPad1,
            ConsoleKey.NumPad2,
            ConsoleKey.NumPad3,
            ConsoleKey.NumPad4,
            ConsoleKey.NumPad5,
            ConsoleKey.NumPad6,
            ConsoleKey.NumPad7,
            ConsoleKey.NumPad8,
            ConsoleKey.NumPad9,
            ConsoleKey.Decimal,
        });

        public static readonly ReadOnlyCollection<ConsoleKey> OperatorKeys = new(new List<ConsoleKey>()
        {
            ConsoleKey.Divide,
            ConsoleKey.Subtract,
            ConsoleKey.Multiply,
            ConsoleKey.Add,            
        });

        private static readonly List<ConsoleKey> _usedKeys;

        static Keyboard()
        {
            _usedKeys = new(ControlKeys);
            _usedKeys.AddRange(NumberKeys);
            _usedKeys.AddRange(OperatorKeys);
        }

        public static ConsoleKeyInfo GetButton()
        {
            while (true)
            {
                var key = Console.ReadKey(true);
                if (_usedKeys.Contains(key.Key))
                {
                    Console.Write(key.KeyChar);
                    return key;
                }
            }
        }
    }
}
