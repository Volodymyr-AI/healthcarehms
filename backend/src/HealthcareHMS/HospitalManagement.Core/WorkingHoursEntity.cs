using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core
{
    public class WorkingHoursEntity
    { 
        public int Id {  get; set; }
        public Guid DoctorId { get; set; }
        public DoctorEntity Doctor { get; set; }
        public Guid HospitalAdmin {  get; set; }
        public DayOfWeek Day {  get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
