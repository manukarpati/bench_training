using System;
using System.Collections.Generic;

namespace TimeSlot
{
    class Program
    {
        static void Main(string[] args)
        {
            var slotList = CreateTimeSlots();
            foreach (var item in slotList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            TimeSlot timeSlot = new TimeSlot(new TimeSpan(13, 15, 00), slotList);
            foreach (var item in timeSlot)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();


            TimeSlot timeSlotWithShownSlotNumber = new TimeSlot(new TimeSpan(11, 15, 00), slotList,5);
            foreach (var item in timeSlotWithShownSlotNumber)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        static IList<TimeSpan> CreateTimeSlots()
        {
            IList<TimeSpan> result = new List<TimeSpan>();
            result.Insert(0, new TimeSpan(11,00,00));

            for (int i=0; i < 15; i++)
            {
                result.Add(result[i].Add(new TimeSpan(00, 15, 00)));
            }

            return result;
        }
    }
}
