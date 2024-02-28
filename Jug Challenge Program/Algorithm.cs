public class AlgorithmClass
{
    private Jug jugX, jugY, jugZ;    // Creates objects for the jugs to be used
    private List<StepsClass> instructionList;
    private string stepByStepInstructions;

    // Class' constructor
    public AlgorithmClass()
    {
        jugX = new Jug();
        jugY = new Jug();
        jugZ = new Jug();

        instructionList = new List<StepsClass>();

        stepByStepInstructions = "";
    }

    // Class' functions

    // Set functions
    public void setJugX(Jug jugX)
    {
        this.jugX = jugX;
    }

    public void setJugY(Jug jugY)
    {
        this.jugY = jugY;
    }

    public void setJugZ(Jug jugZ)
    {
        this.jugZ = jugZ;
    }

    public string getStepByStepInstructions()
    {
        return stepByStepInstructions;
    }

    // Returns the GCD of jug X cap and jug Y cap
    public int GreatestCommonDivisor(int jugX, int jugY)
    {
        if (jugY == 0)
        {
            return jugX;
        }

        return GreatestCommonDivisor(jugY, jugX % jugY);
    }

    // Function to fill a jug until it reaches the goal value
    public void Fill(int fromCap, int toCap, int goalValue, bool switchCheck)
    {
        int from = fromCap;
        int to = 0;

        int steps = 0;    // The number of steps taken to fill the jug to the goal value

        StepsClass instructions = new StepsClass();

        // Add the steps
        if (!switchCheck)
        {
            instructions.addJugXStep(to);
            instructions.addJugYStep(from);
            instructions.addStepExplanation("Fill bucket Y");
        }

        else
        {
            instructions.addJugXStep(from);
            instructions.addJugYStep(to);
            instructions.addStepExplanation("Fill bucket X");
        }

        steps++;

        // Break the loop when either of the two jugs has the goal value
        while (from != goalValue && to != goalValue)
        {
            int temp = Math.Min(from, toCap - to);    // Find the mainimum amount that can be poured between the two jugs

            to += temp;    // Pour "temp" liters from "from" to "to"

            from -= temp;    // Substract the amount of water poured on the other jug

            // Add the steps taken
            if (!switchCheck)
            {
                instructions.addJugXStep(to);
                instructions.addJugYStep(from);
                instructions.addStepExplanation("Transfer from bucket Y to X");
            }

            else
            {
                instructions.addJugXStep(from);
                instructions.addJugYStep(to);
                instructions.addStepExplanation("Transfer from bucket X to Y");
            }

            steps++;

            // Check if any of the two jugs has the goal value by this point
            if (from == goalValue || to == goalValue)
            {
                break;
            }

            // If the first jug becomes empty, fill it
            if (from == 0)
            {
                from = fromCap;

                if (!switchCheck)
                {
                    instructions.addJugXStep(to);
                    instructions.addJugYStep(from);
                    instructions.addStepExplanation("Fill bucket Y");
                }

                else
                {
                    instructions.addJugXStep(from);
                    instructions.addJugYStep(to);
                    instructions.addStepExplanation("Fill bucket X");
                }

                steps++;
            }

            // If the second jug becomes full, empty it
            else if (to == toCap)
            {
                to = 0;

                if (!switchCheck)
                {
                    instructions.addJugXStep(to);
                    instructions.addJugYStep(from);
                    instructions.addStepExplanation("Empty bucket X");
                }

                else
                {
                    instructions.addJugXStep(from);
                    instructions.addJugYStep(to);
                    instructions.addStepExplanation("Empty bucket Y");
                }

                steps++;
            }
        }

        instructions.setStepNumber(steps);

        instructionList.Add(instructions);
    }

    public string minSteps()
    {
        int jugXCap = jugX.getCapacity();
        int jugYCap = jugY.getCapacity();
        int jugZCap = jugZ.getCapacity();

        StepsClass bestSteps = new StepsClass();

        int largestCap = Math.Max(jugXCap, jugYCap);    // Get the largest cap between the two jugs

        // If jug Z cap > largest cap, then we cant measure the water using the jugs
        if (jugZCap > largestCap)
        {
            return "No Solution";
        }

        // If the GCD of jug Y cap and jug X cap does not divide to the jug Z cap, then a solution is not possible
        if ((jugZCap % GreatestCommonDivisor(jugYCap, jugXCap)) != 0)
            return "No Solution";

        // Check both situations: Jug X to Y and viceversa

        Fill(jugYCap, jugXCap, jugZCap, false);    // jug Y to jug X

        Fill(jugXCap, jugYCap, jugZCap, true);    // jug X to jug Y

        bestSteps = getBestStepsTaken();

        return getTotalInstruction(bestSteps);
    }

    // Get the Step class object with the lowest steps taken
    public StepsClass getBestStepsTaken()
    {
        int firstStepsAmount = instructionList[0].getStepNumber();
        int secondStepsAmount = instructionList[1].getStepNumber();

        // Check which one is the shortest, and return them
        if (firstStepsAmount < secondStepsAmount)
        {
            StepsClass firstSteps = new StepsClass();
            firstSteps = instructionList[0];

            return firstSteps;
        }

        else
        {
            StepsClass secondSteps = new StepsClass();
            secondSteps = instructionList[1];

            return secondSteps;
        }
    }

    // Function show the solution of the problem via the console
    public string getTotalInstruction(StepsClass bestSteps)
    {
        string totalInstruction = "";

        int stepsAmount = 0;
        stepsAmount = bestSteps.getStepNumber();

        List<int> jugXStep = bestSteps.getJugXStep();
        List<int> jugYStep = bestSteps.getJugYStep();
        List<string> stepExplanation = bestSteps.getStepExplanation();

        for (int i = 0; i < stepsAmount; i++)
        {
            int xStep = jugXStep[i];
            int yStep = jugYStep[i];
            string explanation = stepExplanation[i];

            totalInstruction += $"Step {i + 1}: \nJug X = {xStep} \nJug Y = {yStep} \nExplanation = {explanation}\n\n";
        }

        stepByStepInstructions = totalInstruction;

        return totalInstruction;
    }
}