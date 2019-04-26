using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TimeSlot
{
    public class TimeSlot : IEnumerable
    {
        public TimeSpan StartTime { get; set; }
        public int ShownSlotNumber { get; set; }
        public IList<TimeSpan> TimeSlots { get; }

        public TimeSlot(TimeSpan startTime,  IList<TimeSpan> timeSlots, int shownSlotNumber=-1)
        {
            StartTime = startTime;
            ShownSlotNumber = shownSlotNumber==-1? timeSlots.Count : shownSlotNumber;
            TimeSlots = timeSlots;
        }

        public IEnumerator GetEnumerator()
        {
            return new TimeSlotEnumerator(this, TimeSlots.IndexOf(StartTime));
        }

        private class TimeSlotEnumerator : IEnumerator
        {
            private TimeSlot timeSlot;
            private int startingIndex;
            private int backwardsIndex;
            private int forwardIndex;
            private int shownSlotCounter = 0;
            public TimeSlotEnumerator(TimeSlot timeSlot, int startingIndex)
            {
                this.timeSlot = timeSlot;
                this.startingIndex = startingIndex;
                backwardsIndex = startingIndex;
                forwardIndex = startingIndex;
            }

            public object Current
            {
                get
                {
                    object o;
                    if (IsBackwardIndexValid())
                    {
                        o = timeSlot.TimeSlots[backwardsIndex];
                    }
                    else 
                    {
                        o = timeSlot.TimeSlots[forwardIndex];
                    }
                    return o;
                }
            }

            public bool MoveNext()
            {
                if (IsBackwardIndexValid())
                {
                    backwardsIndex--;
                }
                else
                {
                    forwardIndex++;
                }
                shownSlotCounter++;

                return (shownSlotCounter <= timeSlot.ShownSlotNumber 
                    &&  (forwardIndex < timeSlot.TimeSlots.Count
                            || backwardsIndex >= 0));
            }

            private bool IsBackwardIndexValid()
            {
                return !((backwardsIndex < 0) || startingIndex - backwardsIndex != forwardIndex - startingIndex) || forwardIndex == timeSlot.TimeSlots.Count;
            }

            public void Reset()
            {
                startingIndex = -1;
                forwardIndex = -1;
                backwardsIndex = -1;
            }
        }
    }
}
