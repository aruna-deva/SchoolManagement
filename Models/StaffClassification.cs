using System.ComponentModel.DataAnnotations;
namespace SchoolManagementSystem.Models
{
    public class Staffclassification
    {
        [Key]
        public int StaffTypeId {get; set;}
        public string TypeName {get; set;}
    }
}