
namespace PAC.Data.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public int? TeamInstanceId { get; set; }
        public virtual TeamInstance TeamInstance { get; set; }
    }
}
