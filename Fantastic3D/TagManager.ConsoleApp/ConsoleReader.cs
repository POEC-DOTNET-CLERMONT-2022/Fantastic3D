namespace Fantastic3D.Tags
{
    internal class ConsoleReader : IReader
    {
        public IWriter Writer { get; set; }

        public T GetElementFromList<T>(List<T> choices, string prompt)
        {
            int choiceIndex = 1;
            foreach (var item in choices)
            {
                Writer.Display($"{choiceIndex++} : {item}");
            }
            int choiceWithOffset = this.ReadId(1, choiceIndex - 1);

            return choices[choiceWithOffset - 1];
        }

        public int ReadId(int lowerBound = 0, int higherBound = 0)
        {
            bool valueIsCorrect = false;
            int outputValue = 0;
            while (!valueIsCorrect)
            {
                var userInput = Console.ReadLine();
                if (int.TryParse(userInput, out outputValue))
                {
                    if (outputValue >= lowerBound && outputValue <= higherBound)
                    {
                        valueIsCorrect = true;
                    }
                }
            }
            return outputValue;
        }

        public string ReadText()
        {
            var inputUserString = string.Empty;
            do
            {
                inputUserString = Console.ReadLine();
            }
            while (!string.IsNullOrEmpty(inputUserString));
            return inputUserString;
        }
    }
}