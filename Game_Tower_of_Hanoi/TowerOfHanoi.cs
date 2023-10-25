namespace Game_Tower_of_Hanoi;

public class TowerOfHanoi
{
    private int moves;
    private int disks;
    private List<int> rodA;
    private List<int> rodB;
    private List<int> rodC;

    public TowerOfHanoi(int numDisks)
    {
        moves = 0;
        disks = numDisks;
        rodA = new List<int>(Enumerable.Range(1, numDisks).Reverse());
        rodB = new List<int>();
        rodC = new List<int>();
    }

    public List<int> GetRodA()
    {
        return rodA;
    }
    
    public List<int> GetRodB()
    {
        return rodB;
    }
    
    public List<int> GetRodC()
    {
        return rodC;
    }
    
    public int GetDisks()
    {
        return disks;
    }
}