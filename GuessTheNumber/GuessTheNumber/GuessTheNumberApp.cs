namespace GuessTheNumber;
public static class GuessTheNumberApp
{
    public static int Run(int upperLimit)
    {
        var numberOfTakes = 0;
        var lowerLimit = 1;

        while (true) 
        {
            numberOfTakes++;

            var numberGuess = (lowerLimit + upperLimit) / 2;

            Console.WriteLine($"Is {numberGuess} your number? - less than, = correct, + greater than");
            var response = Console.ReadKey().KeyChar;

            if (response == '=')
            {
                break;
            }

            if (response == '+')
            {
                lowerLimit = numberGuess;
            }

            if (response == '-')
            {
                upperLimit = numberGuess;
            }
        }

        return numberOfTakes;
    }
}
