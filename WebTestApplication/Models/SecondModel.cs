using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebTestApplication.Models
{
    public class SecondModel : Controller
    {
        public SelectList Tests { get; set; }
        public int SelectedTestId { get; set; }
    }
}
