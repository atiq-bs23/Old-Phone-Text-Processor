using TextProcessor;

Console.Write("Enter the number of test: ");
if(int.TryParse(Console.ReadLine(), out int numberOfTest))
{
    for(int i= 0; i<numberOfTest;i++)
    {
        Console.Write("Enter the input: ");
        var input = Console.ReadLine();
        if(input is null)
        {
            Console.WriteLine("Input is null, please retry again");
            i--;
            continue;
        }
        var output = new DigitToText().ProcessInput(input);
        Console.WriteLine(output);
    }
}
else
{
    Console.WriteLine("Sorry, your input is not a valid number.");
}
