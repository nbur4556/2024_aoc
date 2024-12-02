public class Day01B
{
    public String path;
    private ListWriter locationWriterA;
    private ListWriter locationWriterB;

    public Day01B(String path)
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
            SimilarityScorer similarityScorer = new SimilarityScorer
                (locationWriterA.list, locationWriterB.list);

            int score = similarityScorer.CalculateSimScore();
            Console.WriteLine(score);
        }
    }

    private class SimilarityScorer
    {
        private int[] locationsA;
        private int[] locationsB;

        public SimilarityScorer(int[] listA, int[] listB)
        {
            locationsA = listA;
            locationsB = listB;
        }

        public int CalculateSimScore()
        {
            int score = 0;

            foreach (int locA in locationsA)
            {
                int count = 0;
                foreach (int locB in locationsB)
                {
                    if (locA == locB)
                    {
                        count++;
                    }
                }
                score = score + (locA * count);
            }
            return score;
        }
    }
}
