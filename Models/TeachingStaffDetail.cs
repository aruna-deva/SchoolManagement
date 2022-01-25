using System.ComponentModel.DataAnnotations;
namespace SchoolManagementSystem.Models
{
	public class TeachingStaffDetail
	{
		public string TeacherName { get; set; }
		[Key]
		public int TeacherId { get; set; }
		public string Qualification {get; set;}
		
        public int StaffTypeId {get; set;}

    }
}