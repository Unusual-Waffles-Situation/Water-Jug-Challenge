public class CapacityCheckClass()
{
    public bool hasOnlyNumbers(string input)
    {
        int integerInput = 0;

        bool result = int.TryParse(input, out integerInput);

        return result;
    }

    public bool hasPositiveNumbers(int input)
    {
        if (input <= 0)
        {
            return false;
        }

        return true;
    }

    public int capacityCheck(string jugNumber)
    {
        string consoleMessage = $"Write the capacity for the {jugNumber} jug: ";

        bool errorCheck = false;

        int capacityAmount = 0;    // The value to be used on the algorithm

        string? inputValue = "";

        do
        {
            Console.WriteLine(consoleMessage);
            inputValue = Console.ReadLine();

            // Check if the input value is empty
            if (inputValue != null)
            {   

                // Check if the input only has numbers
                if (!hasOnlyNumbers(inputValue))
                {
                    Console.WriteLine("\nThe capacity value has to be an integer.\n");

                    errorCheck = true;
                }

                else
                {
                    int.TryParse(inputValue, out capacityAmount);

                    if (!hasPositiveNumbers(capacityAmount))
                    {
                        Console.WriteLine("\nThe capacity value can't be zero (0) nor a negative number.\n");

                        errorCheck = true;
                    }

                    else
                    {
                        errorCheck = false;
                    }
                }
            }

            else
            {
                errorCheck = true;
            }
                

        } while(errorCheck);

        return capacityAmount;
    }
}
