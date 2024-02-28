public class StepsClass
{
    private int stepNumber;
    private List<int> jugXStep, jugYStep; 
    private List<string> stepExplanation;

    // Constructor overloading
    public StepsClass()
    {
        stepNumber = 0;
        
        jugXStep = new List<int>();
        jugYStep = new List<int>();
        stepExplanation = new List<string>();
    }

    public StepsClass(int stepNumber, List<int> jugXStep, List<int> jugYStep, List<string> stepExplanation)
    {
        this.stepNumber = stepNumber;

        this.jugXStep = jugXStep;
        this.jugYStep = jugYStep;
        this.stepExplanation = stepExplanation;
    }

    // Class' functions
    public void setStepNumber(int stepNumber)
    {
        this.stepNumber = stepNumber;
    }

    public void addJugXStep(int step)
    {
        jugXStep.Add(step);
    }

    public void addJugYStep(int step)
    {
        jugYStep.Add(step);
    }

    public void addStepExplanation(string stepExplanation)
    {
        this.stepExplanation.Add(stepExplanation);
    }

    // Get functions
    public int getStepNumber()
    {
        return stepNumber;
    }

    public List<int> getJugXStep()
    {
        return jugXStep;
    }

    public List<int> getJugYStep()
    {
        return jugYStep;
    }

    public List<string> getStepExplanation()
    {
        return stepExplanation;
    }
}