using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebTest.Models;
using WebTestApplication.Models;
using WebTestApplication.Repository;
using WebTestApplication.Repository.IRepository;

namespace WebTestApplication.Controllers;
[Area("Teacher")]
public class TestController : Controller
{

        private readonly IUnitOfWork _unitOfWork;
        public TestController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        
        public IActionResult Index()
        {
        IEnumerable<Test> objTestList =_unitOfWork.Test.GetAll();
        return View(objTestList);
        
        }




    //Get
    public IActionResult Upsert(int? id)
        {
            Test test = new();
            IEnumerable < SelectListItem > CategoryList = _unitOfWork.Category.GetAll().Select(
            u => new SelectListItem
        {
            Text = u.Name,
            Value = u.Id.ToString()
        });

        
        
            if(id==null || id==0)
            {
                //create test
                ViewBag.CategoryList = CategoryList;
                return View(test);
            }
            else
            {
                ViewBag.CategoryList = CategoryList;
                var testFromDbFirst = _unitOfWork.Test.GetFirstOrDefault(c => c.Id == id);
                return View(testFromDbFirst);
            }
           
           
        }
       
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Test obj)
        {
        

            if (obj.Id== 0)
            {
            _unitOfWork.Test.Add(obj);
            }
            else
            {
            _unitOfWork.Test.Update(obj);
            }
                
                _unitOfWork.Save();
                TempData["success"] = "Test updated successfully";
                return RedirectToAction("Index");
            
            //return View(obj);
        }



        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
           // var categoryFromDb = _db.Categories.Find(id);
            var testFromDbFirst = _unitOfWork.Test.GetFirstOrDefault(c => c.Id == id);
            //var categoryFromSingle = _db.Categories.SingleOrDefault((c => c.Id == id);
            if (testFromDbFirst == null)
            {
                return NotFound();
            }
            return View(testFromDbFirst);
        }

        //Post
        [HttpPost,ActionName("Delete")]       
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Test.GetFirstOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Test.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Test deleted successfully";
            return RedirectToAction("Index");
           
        }
   


}

