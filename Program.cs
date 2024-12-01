int[] listA = [3, 4, 2, 1, 3, 3];
int[] listB = [4, 3, 5, 3, 9, 3];

ListComparer listComparer = new ListComparer(
    [3, 4, 2, 1, 3, 3],
    [4, 3, 5, 3, 9, 3]
);

LocationId smallestA = listComparer.LocateSmallestNumber(listComparer._listA);
LocationId smallestB = listComparer.LocateSmallestNumber(listComparer._listB);
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
    public int[] _listA;
    public int[] _listB;

    public ListComparer(int[] listA, int[] listB)
    {
        _listA = listA;
        _listB = listB;
    }

    public LocationId LocateSmallestNumber(int[] list)
    {
        LocationId smallest = new LocationId(list[0], 0);
        for (int i = 0; i < list.Length; i++)
        {
            if (list[i] < smallest.id)
            {
                smallest.id = list[i];
                smallest.index = i;
            }
        }

        return smallest;
    }
}
