namespace Entities
{
    public class Association
    {
        public int firstID { get; set; }
        public int secondID { get; set; }

        public Association(int fr, int sc)
        {
            firstID = fr;
            secondID = sc;
        }


    }
}