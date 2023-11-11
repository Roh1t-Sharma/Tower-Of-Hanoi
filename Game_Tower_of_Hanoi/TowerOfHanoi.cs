using Newtonsoft.Json;

namespace Game_Tower_of_Hanoi
{
    public class TowerOfHanoi
    {
        private int _moves;
        private readonly int _disks;
        private readonly List<int> _rodA;
        private readonly List<int> _rodB;
        private readonly List<int> _rodC;

        public TowerOfHanoi(int difficultyLevel)
        {
            _moves = 0;
            _disks = difficultyLevel;
            _rodA = new List<int>(Enumerable.Range(1, _disks).Reverse());
            _rodB = new List<int>();
            _rodC = new List<int>();
        }

        public List<int> GetRodA()
        {
            return _rodA;
        }

        public List<int> GetRodB()
        {
            return _rodB;
        }

        public List<int> GetRodC()
        {
            return _rodC;
        }

        public int GetDisks()
        {
            return _disks;
        }

        public void MoveDisk(char sourceRod, char destinationRod)
        {
            List<int> source, destination;
            if (sourceRod == 'A')
                source = _rodA;
            else if (sourceRod == 'B')
                source = _rodB;
            else
                source = _rodC;

            if (destinationRod == 'A')
                destination = _rodA;
            else if (destinationRod == 'B')
                destination = _rodB;
            else
                destination = _rodC;

            if (source.Count == 0)
            {
                Console.WriteLine("Invalid move!! Source rod empty.");
                return;
            }

            int diskToMove = source[source.Count - 1];

            if (destination.Count != 0 && diskToMove > destination[destination.Count - 1])
            {
                Console.WriteLine("Invalid move!! Larger disks cannot be placed on top of a smaller disk.");
                return;
            }

            destination.Add(diskToMove);
            source.RemoveAt(source.Count - 1);
            _moves++;
        }

        public bool IsGameWon()
        {
            return _rodC.Count == _disks;
        }

        public int GetMoves()
        {
            return _moves;
        }

        public void SaveGame(string fileName)
        {
            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(fileName, json);
        }

        public static TowerOfHanoi? LoadGame(string fileName)
        {
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                return JsonConvert.DeserializeObject<TowerOfHanoi>(json);
            }
            else
            {
                throw new FileNotFoundException("Saved game file not found.");
            }
        }
    }
}
