using System.Runtime.InteropServices.JavaScript;

namespace Game_Tower_of_Hanoi
{
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
    
        public void MoveDisk(char sourceRod, char destinationRod)
        {
            List<int> source, destination;
            if (sourceRod == 'A')
                source = rodA;
            else if (sourceRod == 'B')
                source = rodB;
            else
                source = rodC;
    
            if (destinationRod == 'A')
                destination = rodA;
            else if (destinationRod == 'B')
                destination = rodB;
            else
                destination = rodC;
    
            if (source.Count == 0)
            {
                Console.WriteLine("Invalid move!! Source rod empty.");
                return;
            }
    
            int diskToMove = source[source.Count - 1];
    
            if (destination.Count !=0 && diskToMove > destination[destination.Count - 1])
            {
                Console.WriteLine("Invalid move!! Larger disks cannot be placed on top of a smaller disk.");
                return;
            }
            destination.Add(diskToMove);
            source.RemoveAt(source.Count - 1);
            moves++;
        }
    
        public bool IsGameWon()
        {
            return rodC.Count == disks;
        }
    
        public int GetMoves()
        {
            return moves;
        }
    }
}

