using System.ComponentModel.DataAnnotations;
namespace SchoolManagementSystem.Models
{

    public class ClassRoom
    {
        [Key]
        public int ClassroomId {get; set;}
        public string Standard { get; set; }
        public string  Section { get; set; }
    }
}
