using System.Text;
using Microsoft.EntityFrameworkCore;
namespace SchoolManagementSystem.Models
{
    [Keyless]
    public class TimeTable
    {
        public string ClassId { get; set; }
        public int TimeTableId { get; set; }
        public int TeacherId { get; set; }
        public int SessionNumber { get; set; }
        public string Timings { get; set; }
    }
}