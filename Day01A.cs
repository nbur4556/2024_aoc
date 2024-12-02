public class Day01A
{
    public Day01A()
    {
        Console.WriteLine("Created");
    }

    public void Solve()
    {
        Console.WriteLine("Solve");
    }

    public class ListWriter
    {
        public int[] list { get; private set; }

        public ListWriter()
        {
            list = new int[0];
        }

        public void AddToList(int num)
        {
            list = list.Concat(new int[] { num }).ToArray();
        }

        // An input line is a pair of numbers in string format
        // The format of an input line will be X___X where X is an integer of (n) digits and _ is a space
        // TODO: Error handling for unexpected format
        public void AddToList(String inputLine, bool isFirst)
        {
            String[] vals = inputLine.Split(" ");
            int val1 = Int32.Parse(vals[0]);
            int val2 = Int32.Parse(vals[3]);

            if (isFirst == true)
            {
                this.AddToList(val1);
            }
            else
            {
                this.AddToList(val2);
            }
        }
    }

    public class LocationComparer
    {
        private int[] locationsA;
        private int[] locationsB;

        public LocationComparer(int[] listA, int[] listB)
        {
            this.locationsA = this.SortList(listA);
            this.locationsB = this.SortList(listB);
        }

        // quick-sort algorithm
        private int[] SortList(int[] list)
        {
            if (list.Length <= 1)
            {
                return list;
            }

            int pivot = list[0];
            int[] left = new int[0];
            int[] right = new int[0];

            for (int i = 1; i < list.Length; i++)
            {
                if (list[i] < pivot)
                {
                    left = left.Concat(new int[] { list[i] }).ToArray();
                }
                else
                {
                    right = right.Concat(new int[] { list[i] }).ToArray();
                }
            }

            left = this.SortList(left);
            right = this.SortList(right);
            int[] middle = new int[] { pivot };
            return left.Concat(middle.Concat(right)).ToArray();
        }

        // TODO: account for unequal lists?
        public int CompareLocationPairDistance()
        {
            int distances = 0;
            for (int i = 0; i < locationsA.Length; i++)
            {
                int current = Math.Abs(locationsA[i] - locationsB[i]);
                distances = distances + current;
            }
            return distances;
        }
    }
}

