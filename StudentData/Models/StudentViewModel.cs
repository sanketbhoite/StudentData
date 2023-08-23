using System.ComponentModel;

namespace StudentData.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; } 

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Stream")]
        public string Stream { get; set; }

        [DisplayName("Name")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
