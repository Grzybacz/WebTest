
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTest.Models
{
    public class Questions
    {
        public int Id { get; set; }
        public IEnumerable<TestCart> ListQuestions{ get; set; }

        public int TestId { get; set; }

        public int CountQuestions { get; set; }

        public string TestName { get; set; }

        public int? TotalPoints { get; set; }

    }
}
