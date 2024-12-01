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

// TODO: account for unequal lists?
public class ListComparer
{
    //TODO: Should be private if possible
    public LocationId[] listA;
    public LocationId[] listB;

    public ListComparer(int[] listA, int[] listB)
    {
        this.listA = this.ConvertIntegerList(listA);
        this.listB = this.ConvertIntegerList(listB);
    }

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

    // TODO: This method may not be used
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
