
namespace PAC.Data.Model
{
    /// <summary>
    /// The student.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Gets or sets the team instance id.
        /// </summary>
        public int? TeamInstanceId { get; set; }

        /// <summary>
        /// Gets the team instance.
        /// </summary>
        public virtual TeamInstance TeamInstance { get; private set; }
    }
}
