public class MainFunction
{
    public static void Main()
    {
        CapacityCheckClass capCheck = new CapacityCheckClass();

        Jug jugX = new Jug();
        Jug jugY = new Jug();
        Jug jugZ = new Jug();

        JsonFileUtils jsonFU = new JsonFileUtils();

        // Assign the first container value
        string jugNumber = "first (X)";
        int capacity = 0;

        capacity = capCheck.capacityCheck(jugNumber);
        jugX.setCapacity(capacity);

        // Assign the second container value

        jugNumber = "second (Y)";
        capacity = capCheck.capacityCheck(jugNumber);
        jugY.setCapacity(capacity);

        // Assign the third container value

        jugNumber = "third (Z)";
        capacity = capCheck.capacityCheck(jugNumber);
        jugZ.setCapacity(capacity);

        AlgorithmClass ac = new AlgorithmClass();
        ac.setJugX(jugX);
        ac.setJugY(jugY);
        ac.setJugZ(jugZ);

        Console.Write("\nThe solution is as following: \n\n" +
                       ac.minSteps());

        string filename = "Solution/results.json";

        string stepInstructions = "";
        stepInstructions = ac.getStepByStepInstructions();

        if (stepInstructions != "")
        {
            jsonFU.SimpleWrite(stepInstructions, filename);
        }

        else
        {
            jsonFU.SimpleWrite("No Solution", filename);
        }

        
    }

}