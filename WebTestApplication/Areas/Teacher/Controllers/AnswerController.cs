using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebTest.Models;
using WebTestApplication.Models;
using WebTestApplication.Repository.IRepository;

namespace WebTestApplication.Controllers;
[Area("Teacher")]
public class AnswerController : Controller
    {   

    private readonly IUnitOfWork _unitOfWork;
    public AnswerController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

    }

    public record Category(int Id, string Name);

    public IActionResult Index()
    {
                       
        var categories = _unitOfWork.Category.GetAll();

        var model = new AnswersModel
        {
            Categories = new SelectList(categories, nameof(Category.Id), nameof(Category.Name))
        };        

        return View(model);
    }

    [HttpPost]
    public IActionResult OnCategoryIdChanged(AnswersModel model)
    {
        return RedirectToAction("Index", "Second", new { selectedCategoryId = model.SelectedCategoryId });

    }


  
}

