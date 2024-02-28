public class Jug
{
    private int capacity;

    // Constructor overloading
    public Jug()
    {
        capacity = 0;
    }

    public Jug(int capacity)
    {
        this.capacity = capacity;
    }

    // Class' functions

    public void setCapacity(int capacity)
    {
        this.capacity = capacity;
    }

    public int getCapacity()
    {
        return capacity;
    }
}