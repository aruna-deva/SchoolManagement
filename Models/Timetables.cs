namespace SchoolManagementSystem.Models
{
    public class TimeTables
    {
        public string ClassId { get; set; }
        public int TimeTableId { get; set; }
        public int TeacherId { get; set; }
        public int SessionNumber { get; set; }
        public time Timings { get; set; }
    }
}