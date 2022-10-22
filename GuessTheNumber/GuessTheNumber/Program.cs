using GuessTheNumber;

MainLoop();

static void MainLoop()
{
    var continuePlaying = true;

    while (continuePlaying)
    {
        Intro();

        var upperLimit = GetUpperLimit();

        Separator();
        Console.WriteLine($"Think a number from 1 to {upperLimit}. Click any button when you are ready.");
        Console.ReadKey();
        Separator();

        var takes = GuessTheNumberApp.Run(upperLimit);

        continuePlaying = Ending(takes, upperLimit);
    }
}

static void Intro()
{
    Separator();
    Console.WriteLine("Welcome to the GuessTheNumber application.");
    Console.WriteLine("I will try to guess the number you are thinking.");
    Console.WriteLine("Number will range from 1 to upper limit which I will ask for in a moment.");
    Console.WriteLine("If I'm wrong I will need you to tell me if the number is less than or greater than my initial prediction.");
    Console.WriteLine("If the number is less then than my initial prediction press '-'");
    Console.WriteLine("If the number is greater then than my initial prediction press '+'");
    Console.WriteLine("If the number is correct press '='");
    Separator();
}

static bool Ending(int takes, int upperLimit)
{
    Separator();
    Console.WriteLine($"Congratulations you have correctly guess the number from 1 to {upperLimit} in {takes} takes.");
    Console.WriteLine("Do you wish to continue? y/n");

    var character = Console.ReadKey();

    return character.KeyChar == 'y';
}

static int GetUpperLimit()
{
    Console.WriteLine("To get started I will need a number to set upper limit for out guessing game.");

    var input = Console.ReadLine();

    while (string.IsNullOrEmpty(input))
    {
        Console.WriteLine("Seems like you forgot to give me the number. Try again.");
        input = Console.ReadLine();
    }

    if (!int.TryParse(input, out var upperLimit))
    {
        Console.WriteLine("Congratulations you have successfully failed a task to insert a number from 1 to infinity, bravo. Upper limit has been set to 100");

        return 100;
    }

    if (upperLimit < 1)
    {
        Console.WriteLine("Congratulations you have successfully failed a task to insert a number from 1 to infinity, bravo. Upper limit has been set to 100");

        return 100;
    }

    return upperLimit;
}

static void Separator()
{
    Console.WriteLine("------------------");
}