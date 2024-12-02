int[] listA = [3, 4, 2, 1, 3, 3];
int[] listB = [4, 3, 5, 3, 9, 3];

ListComparer listComparer = new ListComparer(
    [3, 4, 2, 1, 3, 3],
    [4, 3, 5, 3, 9, 3]
);

Console.WriteLine("List A: length " + listComparer.listA.Length);
LocationId[] sortedListA = listComparer.SortList(listComparer.listA);
for(int i = 0; i < sortedListA.Length; i++)
{
    Console.WriteLine("{ " + sortedListA[i].id + ", " + sortedListA[i].index + " }");
}
Console.WriteLine();

Console.WriteLine("List B: length " + listComparer.listB.Length);
LocationId[] sortedListB = listComparer.SortList(listComparer.listB);
for(int i = 0; i < sortedListB.Length; i++)
{
    Console.WriteLine("{ " + sortedListB[i].id + ", " + sortedListB[i].index + " }");
}
Console.WriteLine();

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

    public LocationId[] SortList(LocationId[] list) {
        if (list.Length <= 1) 
        {
            return list;
        }

        LocationId pivot = list[0];
        LocationId[] left = new LocationId[0];
        LocationId[] right = new LocationId[0];

        for (int i = 1; i < list.Length; i ++) {
            if (list[i].id < pivot.id)
            {
                left = left.Concat(new LocationId[] { list[i] }).ToArray();
            } else {
                right = right.Concat(new LocationId[] { list[i] }).ToArray();
            }
        }

        left = this.SortList(left);
        right = this.SortList(right);
        LocationId[] middle = new LocationId[] { pivot };
        return left.Concat(middle.Concat(right)).ToArray();
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
