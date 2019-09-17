namespace Entities
{
    public class Award
    {
        static public int count = 0;

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Discription { get; private set; }

        public Award(int id, string name, string discription)
        {
            Id = id;
            Name = name;
            Discription = discription;
        }

        public override string ToString()
        {
            return Id.ToString() + " " + Name + " " + Discription;
        }
    }
}
