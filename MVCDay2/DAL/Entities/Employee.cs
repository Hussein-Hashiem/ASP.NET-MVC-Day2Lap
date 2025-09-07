using System.ComponentModel.DataAnnotations;

namespace MVCDay2.DAL.Entities
{
	public class Employee
	{
        [Key]
        public int id { get; set; }
        [MaxLength(50)]
        public string name { get; set; }
        public int age { get; set; }
    }
}
