using System;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace gardenBox
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            SqliteConnection connection = new SqliteConnection(@"Data Source=/Users/mamama/Documents/gb/garden-db/gardenBox/gardenBox/garden_box.db");
            connection.Open();
            //Loop to prompt user to begin or exit
            string inputBegin = "y";
            string cropInput;
            bool calc = true;
            //bool calc2 = true; 
            Console.WriteLine("Hello. Welcome to the Garden Box Calculator App. Would you like to calculate a garden? Enter [Y]es or [N]o");
            inputBegin = Console.ReadLine().ToLower();
            while (calc)
            {
                if (inputBegin == "n")
                {
                    break;
                }
                else
                {
                    Garden garden = new Garden();
                    Console.WriteLine("Enter the length in feet:");
                    int userLength = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the width in feet: ");
                    int userWidth = Convert.ToInt32(Console.ReadLine());
                    //if statement 
                    Console.WriteLine();

                    //int userArea = ;
                    int userArea = garden.CalcArea(userLength, userWidth);
                    int userPerimeter = garden.CalcPerimeter(userLength, userWidth);
                    Console.WriteLine("The area of your garden is: " + userArea);
                    Console.WriteLine("The perimeter of your garden is: " + userPerimeter);
                    Console.WriteLine();
                    string anotherCrop = "Y";
                    while (calc)
                    {
                        if (anotherCrop == "Y")
                        {
                            Console.WriteLine("Choose a crop to calculate how many can fit: ");
                            //prints crop options. would like this to be a function
                            Console.WriteLine("{0,12}{1,12}{2,12}{3,12}{4,12}", "[basil]", "[beets]", "[carrots]", "[celery]", "[cilantro]");
                            Console.WriteLine("{0,12}{1,12}{2,12}{3,12}{4,12}", "[corn]", "[oregano]", "[dill]", "[garlic]", "[cucumbers]");
                            Console.WriteLine("{0,12}{1,12}{2,12}{3,12}{4,12}", "[leeks]", "[lettuce]", "[okra]", "[onions]", "[kale]");
                            Console.WriteLine("{0,12}{1,12}{2,12}{3,12}{4,12}", "[parsley]", "[radishes]", "[peppers]", "[potatoes]", "[peas]");
                            Console.WriteLine("{0,12}{1,12}{2,12}{3,12}{4,12}", "[rosemary]", "[spinach]", "[turnips]", "[tomatoes]", "[zucchini]");
                            //user inputs crop
                            cropInput = Console.ReadLine().ToLower();
                            Console.WriteLine();
                            //calculates # crop can fit in garden
                            //Console.WriteLine($"You can plant XXX {cropInput}");

                            SqliteCommand command = new SqliteCommand();
                            command.Connection = connection;
                            command.CommandText = $@"SELECT perSq from crops WHERE cropName = '{cropInput}'";
                            SqliteDataReader reader = command.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    int perSq = Convert.ToInt32(reader["perSq"]);
                                    double cropTotal = garden.CalcCrop(perSq, userArea);
                                    Console.WriteLine($"You can plant {cropTotal} {cropInput} ");
                                }
                            }
                            reader.Close();


                            //prompts user to continue calculating crops
                            Console.WriteLine("Would you like to calculate another crop? Enter [Y]es or [N]o?");
                            anotherCrop = Console.ReadLine().ToUpper();

                        }
                    }

                }
            }
            connection.Close();
        }
    }
}

/*public class CropCalc;
    {
        public public int cropMath
        public int userArea
        public string cropInput
        public string cropName
        {
        Calc(int perSq, int userArea)
    (Convert.ToDouble(perSq) / 4) * userArea
    int cropCalc = return;
        }
    }
    static void Main(string[] args)
{
CropCalc cc = new CropCalc();
cc.Calc();
}
}*/
