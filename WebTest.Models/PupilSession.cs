using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTest.Models
{
    public class PupilSession
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
        [Required]       

        public int TestId { get; set; }

        public Test Test { get; set; }

        public int QuestionNumber { get; set; }

        public string? Answer{ get; set; }
    }
}
