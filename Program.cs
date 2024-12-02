int[] listA = [3, 4, 2, 1, 3, 3];
int[] listB = [4, 3, 5, 3, 9, 3];

LocationComparer locationComparer = new LocationComparer(
    [3, 4, 2, 1, 3, 3],
    [4, 3, 5, 3, 9, 3]
);

int distances = locationComparer.CompareLocationPairDistance();
Console.WriteLine(distances);

public class LocationComparer
{
    private int[] listA;
    private int[] listB;

    public LocationComparer(int[] listA, int[] listB)
    {
        this.listA = this.SortList(listA);
        this.listB = this.SortList(listB);
    }

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
        int[] sortedLocationsA = this.SortList(this.listA);
        int[] sortedLocationsB = this.SortList(this.listB);

        for(int i = 0; i < sortedLocationsA.Length; i++)
        {
            int current = Math.Abs(sortedLocationsA[i] - sortedLocationsB[i]);
            distances = distances + current; 
        }

        return distances;
    }
}
