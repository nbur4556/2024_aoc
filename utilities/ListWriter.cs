    public class ListWriter
    {
        public int[] list { get; private set; }

        public ListWriter()
        {
            list = new int[0];
        }

        public void AddToList(int num)
        {
            list = list.Concat(new int[] { num }).ToArray();
        }

        // An input line is a pair of numbers in string format
        // The format of an input line will be X___X where X is an integer of (n) digits and _ is a space
        // TODO: Error handling for unexpected format
        public void AddToList(String inputLine, bool isFirst)
        {
            String[] vals = inputLine.Split(" ");
            int val1 = Int32.Parse(vals[0]);
            int val2 = Int32.Parse(vals[3]);

            if (isFirst == true)
            {
                this.AddToList(val1);
            }
            else
            {
                this.AddToList(val2);
            }
        }
    }
