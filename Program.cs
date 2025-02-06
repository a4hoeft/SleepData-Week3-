// ask for input
using System.Reflection.PortableExecutable;

Console.WriteLine("Enter 1 to create data file.");
Console.WriteLine("Enter 2 to parse data.");
Console.WriteLine("Enter anything else to quit.");
// input response
string? resp = Console.ReadLine();

if (resp == "1")
{
    // create data file

    // ask a question
    Console.WriteLine("How many weeks of data is needed?");
    // input the response (convert to int)
    int weeks = Convert.ToInt32(Console.ReadLine());
    // determine start and end date
    DateTime today = DateTime.Now;
    // we want full weeks sunday - saturday
    DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
    // subtract # of weeks from endDate to get startDate
    DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));
    // random number generator
    Random rnd = new();
    // create file
    StreamWriter sw = new("data.txt");

    // loop for the desired # of weeks
    while (dataDate < dataEndDate)
    {
        // 7 days in a week
        int[] hours = new int[7];
        for (int i = 0; i < hours.Length; i++)
        {
            // generate random number of hours slept between 4-12 (inclusive)
            hours[i] = rnd.Next(4, 13);
        }
        // M/d/yyyy,#|#|#|#|#|#|#
        Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
        // Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
        sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");
        // add 1 week to date
        dataDate = dataDate.AddDays(7);
    }
    sw.Close();
}
else if (resp == "2")
{
    // TODO: parse data file
    //Minimal Goal:
// Week of Sep, 06, 2020
//  Su Mo Tu We Th Fr Sa
//  -- -- -- -- -- -- --
//   7  4 10  6  9 11  7

StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries;
string[] lines = File.ReadAllLines("data.txt"); 

foreach (string line in lines)
{
    string[] parts = line.Split(',', options);
    DateTime date = Convert.ToDateTime(parts[0]);
    string[] hours = parts[1].Split('|', options);
    int[] hoursInt = Array.ConvertAll(hours, int.Parse);
    //get total hours
int total = hoursInt.Sum();
//get average hours
double average = hoursInt.Average();


    Console.WriteLine("Week of {0:MMM}, {0:dd}, {0:yyyy}", date);
    Console.WriteLine(" Su Mo Tu We Th Fr Sa Tot Avg");
    Console.WriteLine(" -- -- -- -- -- -- -- -- --");
    Console.WriteLine($" {hoursInt[0],2} {hoursInt[1],2} {hoursInt[2],2} {hoursInt[3],2} {hoursInt[4],2} {hoursInt[5],2} {hoursInt[6],2} {total} {average,2}");
    Console.WriteLine();

}

//Extra Credit:
// Double Secret Extra Credit:
// Week of Sep, 06, 2020
//  Su Mo Tu We Th Fr Sa Tot AvgS
//  -- -- -- -- -- -- -- --- ---
//   7  4 10  6  9 11  7  48 6.9

// Week of Sep, 13, 2020
//  Su Mo Tu We Th Fr Sa Tot Avg
//  -- -- -- -- -- -- -- --- ---
//   7  4 10  6  9 11  7  64 9.1




}
