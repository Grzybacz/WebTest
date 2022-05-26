using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebTest.Models;
using WebTestApplication.Models;
using WebTestApplication.Repository;
using WebTestApplication.Repository.IRepository;

namespace WebTestApplication.Controllers;
[Area("Teacher")]
public class TestCartController : Controller
{

        private readonly IUnitOfWork _unitOfWork;
        public TestCartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


    //Get
    public IActionResult Create(int? id)
    {
        
        if (id == null || id == 0)
        {
            return NotFound();
        }
        
        var testFromDbFirst = _unitOfWork.Test.GetFirstOrDefault(c => c.Id == id);        

        if (testFromDbFirst == null)
        {
            return NotFound();
        }
        ViewBag.testFromDbFirst = testFromDbFirst;
        return View();
    }
    [HttpPost, ActionName("Create")]
    //Post
    public IActionResult PostCreate(int? id, string content)
    {
        try
        {
            TestCart testcart = new()
            {
                TestId = id,
                Content = content,
                


            };
            
            
            _unitOfWork.TestCart.Add(testcart);
           
            _unitOfWork.Save();
            TempData["success"] = "Test created successfully";

            
        }
        catch (Exception ex)
        {

        }
        
        
        return View();


    }




}

