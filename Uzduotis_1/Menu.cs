namespace Uzduotis_1
{
    public class Menu
    {
        public Option SelectedOption { get; private set; } = Option.Undefined;
        public string Result { get; private set; }

        public enum Option
        {
            Undefined = 0,
            Encode = 1,
            Decode = 2
        }

        public void Start()
        {
            System.Console.ForegroundColor = System.ConsoleColor.Green;
            System.Console.WriteLine("Caesar cipher\n");
            System.Console.ResetColor();

            DisplayOptions();

            BeginProcess(SelectedOption);

            System.Console.ReadKey();
        }

        public void DisplayOptions()
        {
            while (SelectedOption == Option.Undefined)
            {
                System.Console.WriteLine("Select option:\n");
                System.Console.WriteLine("1. Encode");
                System.Console.WriteLine("2. Decode");

                string inputOption = System.Console.ReadLine();

                switch (inputOption)
                {
                    case "1":
                        SelectedOption = Option.Encode;
                        break;
                    case "2":
                        SelectedOption = Option.Decode;
                        break;
                    default:
                        System.Console.WriteLine("Option doesn't exist\n");
                        break;
                }
            }
        }

        public void BeginProcess(Option option)
        {
            string inputText = InputText();
            int shift = InputShift();

            switch (SelectedOption)
            {
                case Option.Encode:
                    Result = Ceasar.Encode(inputText, shift);
                    break;
                case Option.Decode:
                    Result = Ceasar.Decode(inputText, shift);
                    break;
                default:
                    break;
            }

            DisplayResult();
            SelectedOption = Option.Undefined;
            Start();
        }

        private static string InputText()
        {
            string inputText = "";

            while (string.IsNullOrWhiteSpace(inputText))
            {
                System.Console.WriteLine("Enter your text:");
                inputText = System.Console.ReadLine();
            }

            return inputText;
        }

        private static int InputShift()
        {
            string inputShift = "";
            int shift = 0;
            bool success = false;

            while (string.IsNullOrWhiteSpace(inputShift) && !success)
            {
                System.Console.WriteLine("Enter shift:");
                inputShift = System.Console.ReadLine();

                try
                {
                    shift = int.Parse(inputShift);
                    success = true;
                }
                catch (System.FormatException)
                {
                    System.Console.WriteLine("Not a number");
                    inputShift = "";
                }
            }

            return shift;
        }

        private void DisplayResult()
        {
            System.Console.Clear();
            System.Console.BackgroundColor = System.ConsoleColor.White;
            System.Console.ForegroundColor = System.ConsoleColor.Black;
            System.Console.WriteLine("Result: " + Result + "\n");
            System.Console.ResetColor();
        }
    }
}
