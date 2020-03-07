using System.Collections;

namespace Task2
{
    class Months : IEnumerable, IEnumerator
    {
        int[] month = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        int[] day = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        int position = -1;

        public object Current
        {
            get { return month[position] + "---" + day[position]; }
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (position < month.Length - 1)
            {
                position++;
                return true;
            }
            Reset();
            return false;
        }

        public void Reset()
        {
            position = -1;
        }

        public string GetMonthByNumber(int number)
        {
            if (number < month.Length)
            {
                return string.Format($"Month number {number} ---  Days in this month {day[number - 1]}");
            }
            else return "no such month";
        }

        public string GetMonthByDaysCount(int count)
        {
            string result = string.Empty;
            for (int i = 0; i < day.Length; i++)
            {
                if (count == day[i])
                {
                    result += month[i] + "---" + day[i] + "\n";
                }
            }
            return result;
        }
    }
}
