using System.ComponentModel.DataAnnotations;

//Folder: Models


namespace SchoolManagementSystem.Models
{
    
    public class User
    {
        public int Id{get; set;}
        [Required]
        public int StaffTypeId{get; set;}
        [Required]
        public string TypeName{get; set;}
        
        public void Deconstruct(out int staffTypeId,out string typeName)
        {
            staffTypeId=this.StaffTypeId;
            typeName=this.TypeName;
        }

    }
}