using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.SortingSearching
{
    [TestClass]
    public class MeetingRooms2
    {
        #region Tests
        [TestMethod]
        public void MeetingRooms2_Solutions1()
        {
            Assert.AreEqual(2, MinMeetingRooms(new[]
            {
                new Interval(0, 30),
                new Interval(5, 10),
                new Interval(15, 20)
            }));
        }
        [TestMethod]
        public void MeetingRooms2_Solutions2()
        {
            Assert.AreEqual(1, MinMeetingRooms(new[]
            {
                new Interval(7, 10),
                new Interval(2, 4)
            }));
        }
        #endregion


        public int MinMeetingRooms(Interval[] intervals)
        {
            int[] starts = new int[intervals.Length];
            int[] ends = new int[intervals.Length];
            for (int i = 0; i < intervals.Length; i++)
            {
                starts[i] = intervals[i].start;
                ends[i] = intervals[i].end;
            }
            Array.Sort(starts);
            Array.Sort(ends);
            int rooms = 0;
            int endsItr = 0;
            for (int i = 0; i < starts.Length; i++)
            {
                if (starts[i] < ends[endsItr])
                    rooms++;
                else
                    endsItr++;
            }
            return rooms;
        }

        public int MinMeetingRooms1(Interval[] intervals)
        {
            var meetingRooms = new List<List<Interval>>();

            if (intervals == null || intervals.Length == 0)
                return meetingRooms.Count;

            intervals = intervals.OrderBy(i => i.start).ThenBy(i => i.end).ToArray();

            meetingRooms.Add(new List<Interval> {intervals[0]});

            for (var i = 1; i < intervals.Length; i++)
                if (!MeetingFits(intervals[i], meetingRooms))
                    meetingRooms.Add(new List<Interval> {intervals[i]});

            return meetingRooms.Count;
        }

        private bool MeetingFits(Interval meeting, List<List<Interval>> meetingRooms)
        {
            foreach (var meetingRoom in meetingRooms)
            {
                if (MeetingFits(meeting, meetingRoom))
                {
                    return true;
                }
            }

            return false;
        }

        private bool MeetingFits(Interval meeting, List<Interval> meetingRoom)
        {
            if (meeting.end <= meetingRoom[0].start)
            {
                meetingRoom.Insert(0, meeting);
                return true;
            }
            if (meeting.start >= meetingRoom[meetingRoom.Count - 1].end)
            {
                meetingRoom.Add(meeting);
                return true;
            }

            var prev = 0;

            for (var i = 1; i < meetingRoom.Count; i++)
            {
                if (meeting.start >= meetingRoom[prev].end && meeting.end <= meetingRoom[i].start)
                {
                    meetingRoom.Insert(i, meeting);
                    return true;
                }

                prev = i;
            }

            return false;
        }

        public class Interval
        {
            public int start;
            public int end;

            public Interval()
            {
                start = 0;
                end = 0;
            }

            public Interval(int s, int e)
            {
                start = s;
                end = e;
            }
        }
    }
}
