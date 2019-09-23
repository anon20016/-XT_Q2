namespace Entities
{
    public class User
    {
        static public int count = 0;

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Password { get; private set; }
        public string DateOfBirth { get; private set; }
        public int Age { get; private set; }
        public string Base64img { get; private set; }

        public User()
        {
            
        }
        public User(int id, string name, string dateofbirth)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateofbirth;
        }
        public User(int id, string name, string dateofbirth, string img64)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateofbirth;
            Base64img = img64;
        }
        public User(int id, string name, string dateofbirth, string pas, string img64)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateofbirth;
            Base64img = img64;
            Password = pas;
        }
        public override string ToString()
        {
            return Id.ToString() + " " + Name + " " + DateOfBirth;
        }
    }
}
