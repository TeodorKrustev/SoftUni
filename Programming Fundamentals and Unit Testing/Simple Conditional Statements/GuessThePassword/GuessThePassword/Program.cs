namespace GuessThePassword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String passwd = Console.ReadLine();

            if (passwd == "s3cr3t!")
                Console.WriteLine("Welcome");
            else
                Console.WriteLine("Wrong password!");
        }
    }
}
