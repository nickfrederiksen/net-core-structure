using System.ComponentModel.DataAnnotations;

namespace IoCTest.Infrastructure.DAL.Entities
{
	public class SomeEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
