int[] listA = [3, 4, 2, 1, 3, 3];
int[] listB = [4, 3, 5, 3, 9, 3];

LocationComparer locationComparer = new LocationComparer(
    [3, 4, 2, 1, 3, 3],
    [4, 3, 5, 3, 9, 3]
);

int distances = locationComparer.CompareLocationPairDistance();
Console.WriteLine(distances);

public struct LocationId()
{
    public int id, index;

    public LocationId(int id, int index) : this()
    {
        this.id = id;
        this.index = index;
    }
}

public class LocationComparer
{
    private LocationId[] listA;
    private LocationId[] listB;

    public LocationComparer(int[] listA, int[] listB)
    {
        this.listA = this.ConvertIntegerList(listA);
        this.listB = this.ConvertIntegerList(listB);
    }

    // TODO: Possibly should be a method on the LocationId struct?
    private LocationId[] ConvertIntegerList(int[] list)
    {
        LocationId[] ids = new LocationId[list.Length];
        for (int i = 0; i < list.Length; i++)
        {
            LocationId id = new LocationId(list[i], i);
            ids[i] = id;
        }
        return ids;
    }

    private LocationId[] SortList(LocationId[] list)
    {
        if (list.Length <= 1)
        {
            return list;
        }

        LocationId pivot = list[0];
        LocationId[] left = new LocationId[0];
        LocationId[] right = new LocationId[0];

        for (int i = 1; i < list.Length; i++)
        {
            if (list[i].id < pivot.id)
            {
                left = left.Concat(new LocationId[] { list[i] }).ToArray();
            }
            else
            {
                right = right.Concat(new LocationId[] { list[i] }).ToArray();
            }
        }

        left = this.SortList(left);
        right = this.SortList(right);
        LocationId[] middle = new LocationId[] { pivot };
        return left.Concat(middle.Concat(right)).ToArray();
    }

    // TODO: account for unequal lists?
    public int CompareLocationPairDistance()
    {
        int distances = 0;
        LocationId[] sortedLocationsA = this.SortList(this.listA);
        LocationId[] sortedLocationsB = this.SortList(this.listB);

        for(int i = 0; i < sortedLocationsA.Length; i++)
        {
            int current = Math.Abs(sortedLocationsA[i].id - sortedLocationsB[i].id);
            distances = distances + current; 
        }

        return distances;
    }
}
