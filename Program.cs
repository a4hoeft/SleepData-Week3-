﻿// ask for input
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
{   //reading file
    string[] lines = File.ReadAllLines("data.txt");
//looping over file
    foreach (string line in lines)
    {
        //first split date,hours into array of 2
        string[] parts = line.Split(',');
        //setting varible for the date
        DateTime date = Convert.ToDateTime(parts[0]);
        //second split hours into array of 7
        string[] hours = parts[1].Split('|');
        //converting string array to int array
        int[] hoursInt = Array.ConvertAll(hours, int.Parse);
        //summing the total hours
        int total = hoursInt.Sum();
        //calculating the average hours
        double average = hoursInt.Average();


        Console.WriteLine("Week of {0:MMM}, {0:dd}, {0:yyyy}", date);
        Console.WriteLine(" Su Mo Tu We Th Fr Sa Tot Avg");
        Console.WriteLine(" -- -- -- -- -- -- -- --- ---");
        Console.WriteLine($" {hoursInt[0],2} {hoursInt[1],2} {hoursInt[2],2} {hoursInt[3],2} {hoursInt[4],2} {hoursInt[5],2} {hoursInt[6],2} {total,3} {average,3:F1}");
        Console.WriteLine();

    }


}
