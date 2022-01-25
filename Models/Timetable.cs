using System.Text;
using System.ComponentModel.DataAnnotations;
namespace SchoolManagementSystem.Models
{

    public class TimeTable
    {
        public string ClassId { get; set; }
        [Key]
        public int TimeTableId { get; set; }
        public int TeacherId { get; set; }
        public int SessionNumber { get; set; }
        public string Timings { get; set; }
    }
}