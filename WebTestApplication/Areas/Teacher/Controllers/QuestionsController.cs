using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebTest.Models;
using WebTestApplication.Repository.IRepository;

namespace WebTestApplication.Controllers;
[Area("Teacher")]

public class QuestionsController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    //public Questions Questions { get; set;}
    

    public QuestionsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IActionResult Index(int? id)
    {
        ViewBag.id = id;       
       

        if (id == null || id == 0)
        {
            return NotFound();
        }


        var test = _unitOfWork.Test.GetFirstOrDefault(c => c.Id == id);
        string testname = test.Name;

        Questions questions = new()
        {
           
            ListQuestions = _unitOfWork.TestCart.GetAll(c => c.TestId == id),

            TestId = (int)id,
            TestName = testname,           
               
            };

        questions.CountQuestions = 0;
        foreach (var question in questions.ListQuestions)
        {
            questions.CountQuestions += 1;
        }

        _unitOfWork.Questions.Add(questions);
        _unitOfWork.Save();





        return View(questions);
    }

  

        //Get
        public IActionResult Edit(int? id)
    {
        
        if (id == null || id == 0)
        {
            return NotFound();
        }
        
        var testcartFromDbFirst = _unitOfWork.TestCart.GetFirstOrDefault(c => c.Id == id);
        
        if (testcartFromDbFirst == null)
        {
            return NotFound();
        }
        return View(testcartFromDbFirst);
    }

    //Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(TestCart obj)
    {

            
            _unitOfWork.TestCart.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "Question updated successfully";
            return View(obj);
       

    }



    //Get
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        
        var testcartFromDbFirst = _unitOfWork.TestCart.GetFirstOrDefault(c => c.Id == id);        
        if (testcartFromDbFirst == null)
        {
            return NotFound();
        }
        return View(testcartFromDbFirst);
    }

    //Post
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var obj = _unitOfWork.TestCart.GetFirstOrDefault(c => c.Id == id);
        if (obj == null)
        {
            return NotFound();
        }
       
        _unitOfWork.TestCart.Remove(obj);
        _unitOfWork.Save();
        TempData["success"] = "Question deleted successfully";
        return RedirectToAction("Index", "Test");

    }


}

