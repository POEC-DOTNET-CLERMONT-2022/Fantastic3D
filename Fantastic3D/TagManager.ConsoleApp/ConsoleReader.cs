// See https://aka.ms/new-console-template for more information
using Fantastic3D.Models;
using Fantastic3D.Tags;

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

    public int ReadId(int lowerBound, int higherBound)
    {
        bool valueIsCorrect = false;
        int outputValue = 0;
        //int cursorPosition = Console.GetCursorPosition();
        while(!valueIsCorrect)
        {
            var userInput = Console.ReadLine();
            if(int.TryParse(userInput, out outputValue))
            {
                if(outputValue >= lowerBound && outputValue <= higherBound)
                {
                    valueIsCorrect = true;
                }
            }
        }
        return outputValue;
    }

    public string ReadText()
    {
        // TODO : une boucle, tant que c'est "null", refaire un readline
        bool stringIsCorrect = false;

        var InputUserString = Console.ReadLine();
        while (!stringIsCorrect)
        {
            if (InputUserString != null)
            {
                stringIsCorrect = true;
            }
        }
        return InputUserString;
    }
}