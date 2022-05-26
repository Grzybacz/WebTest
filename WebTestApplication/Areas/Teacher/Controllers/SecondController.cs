using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebTest.Models;
using WebTestApplication.Models;
using WebTestApplication.Repository.IRepository;

namespace WebTestApplication.Controllers;

[Area("Teacher")]
public class SecondController : Controller

{
    private readonly IUnitOfWork _unitOfWork;
    public SecondController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

    }
    public IActionResult Index(int selectedCategoryId)
    {
        var tests = _unitOfWork.Test.GetAll()
            .Where(x => x.CategoryId == selectedCategoryId)
            .ToArray();

        var model = new SecondModel
        {
            Tests = new SelectList(tests, nameof(Test.Id), nameof(Test.Name))
        };
        var id = tests.First().Id;
        TempData["testId"] = id;
        return View(model);
    }

    public IActionResult SelectPupil()
    {
        int testId = (int)TempData["testId"];
        IEnumerable<PupilSession> obj = _unitOfWork.PupilSession.GetAll(x=>x.TestId== testId);
       
        return View( obj );
    }

    public IActionResult GetAnswer(int id)
    {
        var pupil = _unitOfWork.PupilSession.GetFirstOrDefault(x => x.Id == id);
        
        IEnumerable<PupilSession> obj = _unitOfWork.PupilSession.GetAll(x => x.Name == pupil.Name);
        return View(obj);
    }

   
}
    
