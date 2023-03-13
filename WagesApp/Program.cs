//Imports
using System;
using System.Collections.Generic;

namespace WagesApp

{
    class Program

    {
        //Global variables
        static string topEarner = "";
        static int topEarnerHours = -10;

        //Methods and/or functions
        
        static string CheckFlag()
        {
            while (true)
            {
                //Get the users choice
                Console.WriteLine("Press <Enter> to add another employee.\nOr type 'XXX' to quit.");
                string userInput = Console.ReadLine();

                //Convert user input to upper case
                userInput = userInput.ToUpper();
                
                if (userInput.Equals("XXX") || userInput.Equals(""))
                {
                    return userInput;
                }
                Console.WriteLine("\nError 2:\n\nYou must enter either 'XXX' or press <Enter> to continue.\n");
            }

        }

        //Get the employee's name
        static string CheckName()
         {
            while (true)
            {
                Console.WriteLine("Enter the employee's name:\n");
                string name = Console.ReadLine();

                if (!name.Equals(""))
                {
                    //Convert the name into a capitalised name.
                    name = name[0].ToString().ToUpper() + name.Substring(1);

                    return name;
                }
                Console.WriteLine("Error 1:\n\nYou must enter a name\n");
            }

        }

        static void CalculateWages(int totalHours, string employeeName)
        {
            //Display the total weekly hours stored
            Console.WriteLine($"\n\tTotal hours worked : {totalHours} Hours");

            //Add 5 hours to the total hours if the total hours is above 30
            if (totalHours >= 30)
            {
                totalHours += 5;

                //If bonus hours have been given display correct amount
                Console.WriteLine($"\n\t5 bonus hours added: {totalHours} Hours");

            }

            //Calculate the top earner
            if (totalHours > topEarnerHours)
            {
                topEarnerHours = totalHours;
                topEarner = employeeName;
            }

            //Multiply the total hours by $22.00 and store the result in a variable named weeklyPay
            int weeklyPay = totalHours * 22;

            //Calculate tax
            float tax = 0.07f;

            if (weeklyPay > 450)
            {
                tax = 0.08f;

            }

            //Calculate final pay
            float finalPay = weeklyPay - (weeklyPay*tax);

            //Display total correct amount
            Console.WriteLine($"\n\tWeekly Pay: ${weeklyPay}\n" +
                $"\tTax Rate: {tax * 100}%\n" +
                $"\tTax: ${Math.Round(weeklyPay * tax, 2)}\n" +
                $"\tFinal Pay: ${finalPay}\n\n\n");

        }

        static void OneEmployee()
        {
            List<string> WeekDays = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };

            //Enter and store employee name
            string employeeName = CheckName();

            //Display employee name
            Console.Clear();

            Console.WriteLine($"{employeeName}:");

            int sumHours = 0;

            //Loop 5 times
            for (int dayIndex = 0; dayIndex < 5; dayIndex++)
            {
                Random ranGen = new Random();

                //Randomly generate the number of hours worked by a worker each day
                int hours = ranGen.Next(2, 7);

                //Assign the name of the day of the week to a variable called day
                string day = WeekDays[dayIndex];

                //Calculate and store the total number of hours worked over the five days
                sumHours += hours;

                //Display the name of the day and the number of hours worked
                Console.WriteLine($"\tHours worked on {day}: {hours}");

            }

            //Call the CalculateWages()
            CalculateWages(sumHours, employeeName);
        }

        //When run or Main process
        static void Main(string[] args)
        {
            //Display a title and description for the program (ASCII)
            Console.WriteLine
                (
                " __      __                    _             \n" +
               @" \ \    / /_ _ __ _ ___ ___   /_\  _ __ _ __ "+"\n"+
               @"  \ \/\/ / _` / _` / -_|_-<  / _ \| '_ \ '_ \ "+"\n"+
               @"   \_/\_/\__,_\__, \___/__/ /_/ \_\ .__/ .__/ "+"\n" + 
                "              |___/               |_|  |_|    \n"
                );
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine
                (
                "Wages App will calculate the wages for each \n" +
                "employee and display the hours worked for the\n" +
                "week.\n" + 
                "It will produce an employee summary, showing \n" +
                "the tax to be deducted and the total owed.\n" +
                "Lastly, Wages App will display which employee \n" +
                "worked the most ours over the week.\n" +
                "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\n");

            Console.WriteLine("Press <Enter>");
            Console.ReadLine();
            Console.Clear();

            string flagMain = "";
            while (!flagMain.Equals("XXX"))
            {
                Console.WriteLine("------------EMPLOYEE DATA------------"); 

                OneEmployee();

                flagMain = CheckFlag();

                Console.Clear();

            }

            Console.WriteLine($"\nThe employee with most hours is {topEarner} with {topEarnerHours} hours!");

        }

    }

}