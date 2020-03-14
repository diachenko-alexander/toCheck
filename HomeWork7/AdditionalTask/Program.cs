using System;


namespace AdditionalTask
{
   enum Access
    {
        Unlimited, 
        Limited,
    }
    
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    sealed class AccessLevelAttribute : Attribute
    {
        private readonly Access access;
        public Access Acces { get { return access; }  }

        public AccessLevelAttribute(Access access)
        {
            this.access = access;
        }
    }

    [AccessLevel(Access.Limited)]
    class Manager
    {

    }

    [AccessLevel(Access.Limited)]
    class Programmer
    {

    }

    [AccessLevel(Access.Unlimited)]
    class Director
    {

    }

    class Program
    {

        static void Main(string[] args)
        {
            Programmer programmer = new Programmer();
            if (CheckUnlimitedAcces(programmer))
            {
                Console.WriteLine("OK");
            }
            else Console.WriteLine("NO");


            Director director = new Director();
            if (CheckUnlimitedAcces(director))
            {
                Console.WriteLine("OK");
            }
            else Console.WriteLine("NO");
        }

        


        static bool CheckUnlimitedAcces<T> (T emp)
        {
            Type position = emp.GetType();
            object [] attribute = position.GetCustomAttributes(typeof(AccessLevelAttribute), true);
            
            foreach (AccessLevelAttribute atr in attribute)
            {
                if (atr.Acces == Access.Unlimited)
                {
                    return true; 
                }
            }

            return false;
                        
        }

    }
}
