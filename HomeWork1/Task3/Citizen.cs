namespace Task3
{
    abstract class Citizen
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Citizen(uint id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = name;
        }
    }

    class Student : Citizen
    {
        public Student(uint id, string name, string surname)
            : base(id, name, surname)
        {

        }
    }

    class Pensioner : Citizen
    {
        public Pensioner(uint id, string name, string surname)
            : base(id, name, surname)
        {

        }
    }

    class Worker : Citizen
    {
        public Worker(uint id, string name, string surname)
            : base(id, name, surname)
        {

        }
    }
}
