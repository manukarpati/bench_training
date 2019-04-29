using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Time.Slot;
using System;

namespace TimeSlotUnitTest
{
    [TestClass]
    public class TimeSlotTest
    {
        List<TimeSpan> slotList;

        [TestMethod]
        public void TimeSlot_TestSlotNumber()
        {
            //Arrange
            TimeSlot timeSlot = new TimeSlot(new TimeSpan(13, 15, 00), slotList);

            //Act


            //Assert

        }

        [TestInitialize]
        private void CreateTimeSlots()
        {
            slotList = new List<TimeSpan>();
            slotList.Insert(0, new TimeSpan(11, 00, 00));

            for (int i = 0; i < 15; i++)
            {
                slotList.Add(slotList[i].Add(new TimeSpan(00, 15, 00)));
            }

        }
    }
}
