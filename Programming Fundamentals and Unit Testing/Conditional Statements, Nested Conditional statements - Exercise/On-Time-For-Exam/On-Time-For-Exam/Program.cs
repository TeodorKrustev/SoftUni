namespace On_Time_For_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int exH = int.Parse(Console.ReadLine());
            int exM = int.Parse(Console.ReadLine());
            int arH = int.Parse(Console.ReadLine());
            int arM = int.Parse(Console.ReadLine());

            int arTotalM = arH * 60 + arM;
            int exTotalM = exH * 60 + exM;

            int diff = exTotalM - arTotalM;

            String status = "";
            String comparison = "";

            if (diff >= 0 && diff <= 30)
            {
                status = "On time";
                comparison = "before";
            }
            else if (diff < 0)
            {
                status = "Late";
                comparison = "after";
                diff = -diff;
            }
            else
            {
                status = "Early";
                comparison = "before";
            }

            int compH = diff / 60;
            int compM = diff % 60;
            Console.WriteLine(status);
            if (compH > 0)
                Console.WriteLine($"{compH}:{compM:D2} hours {comparison} the start");
            else
                if (compM > 0)
                Console.WriteLine($"{compM} minutes {comparison} the start");


        }
    }
}
