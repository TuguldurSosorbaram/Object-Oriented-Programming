namespace BagType
{
    public class Element
    {
        public int e, f;
        public Element() { }
        public Element(int e, int f) { this.e = e; this.f = f;}
    }
    public class Bag
    {
        //exceptions
        public class EmptyBagException : Exception { }
        public class NotElementException : Exception { }
        //attributes
        private List<Element> seq = new();
        private int SingleECount = 0;
        //constructor
        public Bag() { }
        //methods
        public void clear()
        {
            seq.Clear();
            SingleECount = 0;
        }
        public bool isEmpty()
        {
            return seq.Count == 0;
        }
        public int isin(int elem)
        {
            for (int i = 0; i < seq.Count; i++)
            {
                if (seq[i].e == elem) return i;
            }
            return -1;
        }
        public List<Element> getSeq() { return seq; }
        public int countAll()
        {
            int c = 0;
            foreach (Element e in seq)
            {
                c += e.f;
            }
            return c;
        }
        public void putin(int elem)
        {
            int ind = this.isin(elem);
            if (ind == -1)
            {
                Element e = new(elem,1);
                seq.Add(e);
                SingleECount++;
            }
            else
            {
                seq[ind].f++;
                if (seq[ind].f!=1) SingleECount--;
            }            
        }
        public void takeout(int elem)
        {
            if (this.isEmpty()) { throw new EmptyBagException(); }
            int ind = this.isin(elem);
            if (ind==-1) throw new NotElementException();
            seq[ind].f-=1;
            if (seq[ind].f == 0)
            {
                SingleECount--;
                seq.RemoveAt(ind);
            }
            else if (seq[ind].f == 1) SingleECount++;
        }
        public int countE(int elem)
        {
            if (this.isEmpty()) { throw new EmptyBagException(); }
            int ind = this.isin(elem);
            if (ind == -1) throw new NotElementException();
            return seq[ind].f;
        }
        public int getSingleECount()
        {
            if (this.isEmpty()) { throw new EmptyBagException(); }
            return this.SingleECount;
        }
        public void print()
        {
            if (this.isEmpty()) { throw new EmptyBagException(); }
            Console.WriteLine("Bag elements: ");
            foreach (Element i in seq)
            {
                for(int j = 0; j < i.f; j++)
                {
                    Console.Write("{0} ",i.e);
                }
            }
        }

    }
}
