int[] listA = [3, 4, 2, 1, 3, 3];
int[] listB = [4, 3, 5, 3, 9, 3];

ListComparer listComparer = new ListComparer(
    [3, 4, 2, 1, 3, 3],
    [4, 3, 5, 3, 9, 3]
);

LocationId smallestA = listComparer.LocateSmallestNumber(listComparer.listA);
LocationId smallestB = listComparer.LocateSmallestNumber(listComparer.listB);
Console.WriteLine(smallestA.id);
Console.WriteLine(smallestA.index);
Console.WriteLine(smallestB.id);
Console.WriteLine(smallestB.index);

public struct LocationId()
{
    public int id, index;

    public LocationId(int id, int index) : this()
    {
        this.id = id;
        this.index = index;
    }
}

public class ListComparer
{
    //TODO: Should be private if possible
    public LocationId[] listA;
    public LocationId[] listB;

    public ListComparer(int[] listA, int[] listB)
    {
        LocationId[] _a = new LocationId[listA.Length];
        LocationId[] _b = new LocationId[listB.Length];

        for (int i = 0; i < listA.Length; i++)
        {
            LocationId id = new LocationId(listA[i], i);
            _a[i] = id;
        }

        for (int i = 0; i < listB.Length; i++)
        {
            LocationId id = new LocationId(listB[i], i);
            _b[i] = id;
        }

        this.listA = _a;
        this.listB = _b;
    }

    public LocationId LocateSmallestNumber(LocationId[] list)
    {
        LocationId smallest = list[0];
        for (int i = 0; i < list.Length; i++)
        {
            if (list[i].id < smallest.id)
            {
                smallest = list[i];
            }
        }

        return smallest;
    }
}
