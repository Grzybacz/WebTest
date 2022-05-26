using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using WebTest.Models;
using WebTestApplication.Models;
using WebTestApplication.Repository.IRepository;
using System.Linq;

namespace WebTestApplication.Controllers;
[Area("Pupil")]
public class HomeController : Controller
{


    private readonly IUnitOfWork _unitOfWork;
    public HomeController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }



    public IActionResult Index()
    {


        return View();
    }

    //GetPost
    public IActionResult PupilSession(string name, string surname, int id)
    {


        var QuestionsList = _unitOfWork.Questions.GetAll().Select(
            u => new SelectListItem
            {
                Text = u.TestName,
                Value = u.Id.ToString()
            });

        ViewBag.QuestionsList = QuestionsList;




        PupilSession pupilsession = new()
        {
            Name = name,
            Surname = surname,
            TestId = id
        };


        return View();
    }


    //Post
    [HttpPost]
    public IActionResult PupilSession(PupilSession pupilsession)
    {



        PupilSession test = new()
        {
            TestId = pupilsession.TestId,
            Name = pupilsession.Name,
            Surname = pupilsession.Surname

        };

        TempData["Name"] = test.Name;
        TempData["Surname"] = test.Surname;

        try
        {
            _unitOfWork.PupilSession.Add(test);
            _unitOfWork.Save();


            if (test.Id < 1)

            {
                TempData["error"] = "Invalid session details. Please try again";
                return View("PupilSession");
            }
            else
            {
                TempData["success"] = "Session created successfully";

            }


            int testid = test.TestId;
            var test1 = _unitOfWork.Test.GetFirstOrDefault(c => c.Id == testid);
            TempData["Test"] = testid;

            ViewBag.Nazwa = test1.Name;
            ViewBag.Description = test1.Description;

            try
            {
                Questions questions = new();
                {
                    var test2 = _unitOfWork.TestCart.GetAll().Where(c => c.TestId == testid);
                    var CountQuestions = 0;
                    foreach (var question in test2)
                    {
                        CountQuestions += 1;
                    }

                    TempData["CountQuestions"] = CountQuestions;
                };

            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Instruction", test);
        }
        catch (Exception ex)
        {

        }

        return View(test);
    }

    public IActionResult Instruction(PupilSession pupilSession)
    {

        Test test = new()
        {
            Name = _unitOfWork.Test.GetFirstOrDefault(x => x.Id == pupilSession.TestId).Name,
            Description = _unitOfWork.Test.GetFirstOrDefault(x => x.Id == pupilSession.TestId).Description,
        };

        TempData["TestName"] = test.Name;
        TempData["TestDescription"] = test.Description;


        var cauntQuestions = _unitOfWork.TestCart.GetAll(x => x.TestId == pupilSession.TestId).Count();
        @TempData["CountQuestions"] = cauntQuestions;


        return View(pupilSession);
    }

    public IActionResult Exam(PupilSession pupilSession, int? qno, int testId)
    {

        if (testId == 0)
        {
            testId = Convert.ToInt32(TempData["Test"]);
        }

        var random = new Random();

        pupilSession.TestId = testId;
        ViewBag.TestId = testId;


        var testCarts = _unitOfWork.TestCart.GetAll(x => x.TestId == pupilSession.TestId).ToList();
        ViewBag.countQuestion = testCarts.Count();


        if (qno < 1 || qno == null)
        {
            testCarts.ForEach(x => x.QuestionNumber = 0);
            foreach (var testCart in testCarts)
            {
                var number = random.Next(1, testCarts.Count + 1);

                while (testCarts.Any(x => x.QuestionNumber == number))
                {
                    number = random.Next(1, testCarts.Count + 1);
                }

                testCart.QuestionNumber = number;
            }

            _unitOfWork.TestCart.UpdateMany(testCarts);


            if (qno.GetValueOrDefault() < 1)
                qno = 1;





            return View(testCarts);
        }

        var testCartsVM = _unitOfWork.TestCart.GetFirstOrDefault(x => x.QuestionNumber == qno).Content;
        ViewBag.testCartsVM = testCartsVM;


        TempData["testId"] = testId;        
        ViewBag.qno = qno;

        return View();


    }


    [HttpPost]
    public IActionResult AnswerPost(PupilSession pupilSession, int testId, int qno, string answer)
    {
        if (testId == 0 || qno==0)
        {
            testId = (int)TempData["testId"];
            pupilSession.TestId = (int)TempData["testId"];
            pupilSession.QuestionNumber = (int)TempData["qno"];
            pupilSession.Name = (string)TempData["Name"];
            pupilSession.Surname = (string)TempData["Surname"];

        }
        

        _unitOfWork.PupilSession.UpdateMany(pupilSession);
        _unitOfWork.Save();
        TempData["success"] = "Answer save successfully";

        return RedirectToAction("Exam", pupilSession);
    }
}

       
