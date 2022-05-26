using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTestApplication.Models
{
   

    public class AnswersModel
    {
        public SelectList Categories { get; set; }
        public int SelectedCategoryId { get; set; }
    }
}
