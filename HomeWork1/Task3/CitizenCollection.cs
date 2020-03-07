using System;
using System.Collections;

namespace Task3
{
    class CitizenCollection : IEnumerable
    {
        Citizen[] citizens;

        public CitizenCollection()
        {
            citizens = new Citizen[0];
        }

        public int Count 
        { 
            get 
            {
                return citizens.Length;
            } 
        }

        public object this[int index]
        {
            get 
            {
                if (index < Count)
                {
                    return citizens[index];
                }
                else return null;            
            }
        }
        public IEnumerator GetEnumerator()
        {
            return citizens.GetEnumerator();
        }

       public bool Contains (Citizen citizen)
        {
            for (int i = 0; i < citizens.Length; i++)
            {
                if (citizens[i].Id == citizen.Id)
                {
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            citizens = new Citizen[0];
        }

        public Citizen ReturnLast(out int lastIdex)
        {
            lastIdex = citizens.Length - 1;
            return citizens[lastIdex];
        }

        private int GetLastPensionerIndex ()
        {
            int index = 0;
            for (int i = 0; i < citizens.Length; i++)
            {
                if (citizens[i] as Pensioner != null)
                {
                    index++;
                }
            }
            return index;
        } 

        public void Add (Citizen citizen)
        {
            if (Contains(citizen))
            {
                Console.WriteLine("Citizen with such Id is exist");
                return;
            }

            Citizen[] tempCitizens = new Citizen[citizens.Length + 1];

            if (citizen as Pensioner != null)
            {
                int lastPensionerIndex = GetLastPensionerIndex();
                Array.ConstrainedCopy(citizens, 0, tempCitizens, 0, lastPensionerIndex);
                tempCitizens[lastPensionerIndex] = citizen;
                Array.ConstrainedCopy(citizens, lastPensionerIndex, tempCitizens, lastPensionerIndex + 1, citizens.Length - lastPensionerIndex);
            } else
            {
                citizens.CopyTo(tempCitizens, 0);
                tempCitizens[citizens.Length] = citizen;
            }
            citizens = tempCitizens;
        }

        public void Remove()
        {
            Citizen[] tempCitizens = new Citizen[citizens.Length - 1];
            citizens.CopyTo(tempCitizens, 1);
            citizens = tempCitizens;
        }
        
        public void Remove (Citizen citizen)
        {
            if (!Contains(citizen))
            {
                Console.WriteLine("No such citizen in collection");
                return;
            }

            int indexToRemove = 0;
            for (int i = 0; i < citizens.Length; i++)
            {
                if (citizens[i].Id == citizen.Id)
                {
                    indexToRemove = i;
                }
            }

            Citizen[] tempCitizens = new Citizen[citizens.Length - 1];
            Array.ConstrainedCopy(citizens, 0, tempCitizens, 0, indexToRemove);
            Array.ConstrainedCopy(citizens, indexToRemove + 1, tempCitizens, indexToRemove, tempCitizens.Length - indexToRemove);
            citizens = tempCitizens;
        }
    }
}
