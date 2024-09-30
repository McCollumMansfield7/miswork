
    {
        static void Main(string[] args)
        {
            bool exit = false; 
            while (!exit)
            {
                Console.WriteLine("Main Menu:");
                Console.WriteLine("1. Convert Units of Measure");
                Console.WriteLine("2. Rock Classification");
                Console.WriteLine("3. Exit");
                Console.Write("Please choose an option (1-3): ");

                // Menu selection
                switch (Console.ReadLine())
                {
                    case "1":
                        UnitConversionMenu(); 
                        break;
                    case "2":
                        RockClassificationMenu(); 
                        break;
                    case "3":
                        exit = true; 
                        Console.WriteLine("Leaving Program.");
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please choose a valid option."); 
                        break;
                }
            }
        }

        
        static void UnitConversionMenu()
        {
            Console.WriteLine("\n--- Unit Conversion ---");
            Console.WriteLine("1. Length (inches, yards, miles)");
            Console.WriteLine("2. Mass (oz, lbs)");
            Console.WriteLine("3. Temperature (Fahrenheit)");
            Console.Write("Select type of conversion (1-3): ");
            string type = Console.ReadLine();

            double amount, result = 0;
            string fromUnit = "", toUnit = "";


            switch (type)
            {
                case "1":
                    Console.WriteLine("Length conversion:");
                    Console.Write("From unit (inches, yards, miles): ");
                    fromUnit = Console.ReadLine();
                    Console.Write("To unit (inches, yards, miles): ");
                    toUnit = Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine("Mass conversion:");
                    Console.Write("From unit (oz, lbs): ");
                    fromUnit = Console.ReadLine();
                    Console.Write("To unit (oz, lbs): ");
                    toUnit = Console.ReadLine();
                    break;
                case "3":
                    Console.WriteLine("Temperature conversion:");
                    fromUnit = "F"; 
                    toUnit = "C";
                    break;
                default:
                    Console.WriteLine("Invalid selection.");
                    return;
            }

            Console.Write("Enter the starting amount: ");
            if (!double.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("Invalid amount.");
                return;
            }

            
            result = ConvertUnits(type, fromUnit, toUnit, amount);

            Console.WriteLine($"Converted amount: {result}\n");
        }

        
        static double ConvertUnits(string type, string fromUnit, string toUnit, double amount)
        {
            switch (type)
            {
                case "1": 
                    if (fromUnit == "inches" && toUnit == "yards") return amount / 36;
                    if (fromUnit == "inches" && toUnit == "miles") return amount / 63360;
                    if (fromUnit == "yards" && toUnit == "inches") return amount * 36;
                    if (fromUnit == "yards" && toUnit == "miles") return amount / 1760;
                    if (fromUnit == "miles" && toUnit == "inches") return amount * 63360;
                    if (fromUnit == "miles" && toUnit == "yards") return amount * 1760;
                    break;
                case "2": 
                    if (fromUnit == "oz" && toUnit == "lbs") return amount / 16;
                    if (fromUnit == "lbs" && toUnit == "oz") return amount * 16;
                    break;
                case "3": 
                    if (fromUnit == "F" && toUnit == "C") return (amount - 32) * 5 / 9;
                    break;
            }
            Console.WriteLine("Invalid conversion.");
            return 0;
        }

       
        static void RockClassificationMenu()
        {
            Console.WriteLine("\n--- Rock Classification ---");

            
            Console.Write("Enter the number of identical rock samples found: ");
            if (!int.TryParse(Console.ReadLine(), out int numSamples))
            {
                Console.WriteLine("Invalid number.");
                return;
            }

            Console.Write("Is transportation needed? (yes/no): ");
            string transportation = Console.ReadLine();
            bool transportNeeded = transportation.ToLower() == "yes";

            Console.Write("Enter the rock's surface temperature (in degrees Celsius): ");
            if (!double.TryParse(Console.ReadLine(), out double temperature))
            {
                Console.WriteLine("Invalid temperature.");
                return;
            }

            Console.Write("Enter the total mass of rock samples (in kg): ");
            if (!double.TryParse(Console.ReadLine(), out double totalMass))
            {
                Console.WriteLine("Invalid mass.");
                return;
            }

            // Calculate points based on criteria
            double points = numSamples * 4.5;

            if (transportNeeded)
                points += 7.3;

            if (temperature <= 0)
                points += 9.2;

            if (totalMass > 25)
                points += points * 0.17;

            Console.WriteLine($"Initial rock classification points: {points}\n");

           
            double originalPoints = points;
            double totalAdjustment = 0;
            bool satisfied = false;

            while (!satisfied)
            {
                Console.Write("Would you like to adjust score? (yes/no): ");
                string response = Console.ReadLine();
                if (response.ToLower() == "no")
                {
                    satisfied = true;
                    break;
                }

                Console.Write("Enter point adjustment (positive or negative value): ");
                if (!double.TryParse(Console.ReadLine(), out double adjustment))
                {
                    Console.WriteLine("Invalid change .");
                    continue;
                }

                
                if (Math.Abs(adjustment) > originalPoints)
                {
                    Console.WriteLine("Error: The change can't be greater than original value.");
                }
                else
                {
                    points += adjustment;
                    totalAdjustment += adjustment;
                    Console.WriteLine($"Updated points: {points}");
                    Console.WriteLine($"Total adjustment made: {totalAdjustment}\n");
                }
            }

          
            Console.WriteLine($"Final rock classification points: {points}\n");
            Console.WriteLine($"Total adjustment made: {totalAdjustment}\n");
        }
    }
}
