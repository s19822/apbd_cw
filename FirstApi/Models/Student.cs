
namespace FirstApi.Models
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentNumber { get; set; }
        public string BirthDate { get; set; }
        public string DegreeCourse { get; set; }
        public string ModeCourse { get; set; }
        public string EmailAddress { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }




        public override string ToString()
        {
            return base.ToString();
        }


    }
}
