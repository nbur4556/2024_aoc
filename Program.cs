Day01A day01A = new Day01A();
day01A.Solve();

if (args.Length <= 0)
{
    Console.WriteLine("Please provide a path to input data");
    return;
}
String path = args[0];
String? line;
Day01A.ListWriter locationWriterA = new Day01A.ListWriter();
Day01A.ListWriter locationWriterB = new Day01A.ListWriter();

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
    Day01A.LocationComparer locationComparer = new Day01A.LocationComparer
        (locationWriterA.list, locationWriterB.list);

    int distances = locationComparer.CompareLocationPairDistance();
    Console.WriteLine(distances);
}
