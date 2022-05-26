using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebTestApplication.Models;

namespace WebTest.Models
{
    public class TestCart
    {

        public int Id { get; set; }
        public string Content { get; set; }
        public int? QuestionNumber { get; set; }
        public int? TestId { get; set; }
        public Test Test { get; set; }










    }
}
