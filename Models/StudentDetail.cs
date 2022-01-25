using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models
{
    public class StudentDetail
    {
        [Key]
        public int StudentID {get; set;}
        public string StudentName {get; set;}
        public string FatherName {get; set;}
        public string ClassId {get; set;}
        public DateTime BirthDate {get; set;}
        public string BloodGroup {get; set;}
        public string Address {get; set;}
        public string City {get; set;}
        public string Nationality {get; set;}
        public string ContactNumber {get; set;}
    }
}