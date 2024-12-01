int[] listA = [3, 4, 2, 1, 3, 3];
int[] listB = [4, 3, 5, 3, 9, 3];

ListComparer listComparer = new ListComparer(
    [3, 4, 2, 1, 3, 3], 
    [4, 3, 5, 3, 9, 3]
);

Console.WriteLine(listComparer.LocateSmallestNumber(listComparer._listA));
Console.WriteLine(listComparer.LocateSmallestNumber(listComparer._listB));

public class ListComparer {
    //TODO: Should be private if possible
    public int[] _listA;
    public int[] _listB;

    public ListComparer(int[] listA, int[] listB) {
        _listA = listA;
        _listB = listB;
    }

    public int LocateSmallestNumber(int[] list) {
        int smallest = list[0];

        for(int i = 0; i < list.Length; i++) {
            if (list[i] < smallest) {
                smallest = list[i];
            }
        }

        return smallest;
    }
}
