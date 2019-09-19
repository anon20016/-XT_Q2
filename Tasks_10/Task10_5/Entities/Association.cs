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
        public override bool Equals(object obj)
        {
            return (obj as Association).firstID == firstID && (obj as Association).secondID == secondID;
        }

    }
}