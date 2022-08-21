using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestApplication.Models;

namespace WebTest.Models
{
    public class Test
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }
        
        public Category Category { get; set; }
        
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

        public ICollection<TestCart> TestCarts { get; set; }
        [NotMapped]
        public object TestId { get; set; }
        [NotMapped]
        public string name_category { get; set; }


    }
}
