using Microsoft.EntityFrameworkCore;
namespace SchoolManagementSystem.Models
{
    [Keyless]
    public class ClassRoom
    {
        
        public string Standard { get; set; }
        public string  Section { get; set; }
    }
}