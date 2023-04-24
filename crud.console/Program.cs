using crud.console.Commands;

internal class Program
{
    private static void Main(string[] args)
    {
        // Display title as the C# console calculator app.
        Console.WriteLine("Console CRUD\r");
        Console.WriteLine("------------------------\n");

        ClientCommands.GetUserCommand();

        // Wait for the user to respond before closing.
        Console.Write("Press any key to close the Calculator console app...");
        Console.ReadKey();
    }
}