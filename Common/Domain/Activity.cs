using System;
using System.Collections.Generic;

namespace Isarithm.Common.Domain
{
    public class TimeRecord
    {
        public int Order;
        public int AngleX;
        public int AngleY;
        public int AngleZ;
        public int AccelerationX;
        public int AccelerationY;
        public int AccelerationZ;
    }
    
    public class Activity
    {
        public int Id;
        public string Name;
        public int Tolerance;
        public List<TimeRecord> TimeRecords;
        public DateTime CreateDateTime;
        public DateTime LastUpdateDateTime;
    }
}