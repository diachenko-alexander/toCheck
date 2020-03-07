namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student(1, "Studen1Name", "Student2Surname");
            Student studentCopy = new Student(1, "Studen1Name", "Student2Surname");
            Pensioner pensioner1 = new Pensioner(2, "Pensioner1Name", "Pensioner1Surname");
            Worker worker1 = new Worker(3, "Worker1Name", "Worker2Surname");
            Pensioner pensioner2 = new Pensioner(4, "Pensioner2Name", "Pensioner2Surname");

            CitizenCollection collection = new CitizenCollection();
            collection.Add(student1);
            //collection.Add(studentCopy);
            collection.Add(pensioner1);
            collection.Add(worker1);
            collection.Add(pensioner2);
            
            foreach (Citizen item in collection)
            {
                System.Console.WriteLine($"{item.Id} {item.Name}");
            }

            System.Console.WriteLine();

            collection.Remove(pensioner1);
                        
            foreach (Citizen item in collection)
            {
                System.Console.WriteLine($"{item.Id} {item.Name}");
            }

            System.Console.WriteLine();

            collection.Remove(worker1);
            foreach (Citizen item in collection)
            {
                System.Console.WriteLine($"{item.Id} {item.Name}");
            }
        }
    }
}
