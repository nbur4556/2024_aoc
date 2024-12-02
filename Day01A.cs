public class Day01A
{
    private String path;
    private ListWriter locationWriterA;
    private ListWriter locationWriterB;

    public Day01A(String path)
    {
        this.path = path;
        locationWriterA = new ListWriter();
        locationWriterB = new ListWriter();
    }

    public void Solve()
    {
        String? line;
        try
        {
            StreamReader sr = new StreamReader(path);
            line = sr.ReadLine();
            while (line != null)
            {
                locationWriterA.AddToList(line, true);
                locationWriterB.AddToList(line, false);
                line = sr.ReadLine();
            }
            sr.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            LocationComparer locationComparer = new LocationComparer
                (locationWriterA.list, locationWriterB.list);

            int distances = locationComparer.CompareLocationPairDistance();
            Console.WriteLine(distances);
        }
    }

    private class LocationComparer
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

