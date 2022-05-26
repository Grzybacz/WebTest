//using WebTestApplication.Data;
using WebTest.Models;
using WebTestApplication.DataAccess;
using WebTestApplication.Models;

namespace WebTestApplication.Repository
{
    public class TestRepository : Repository<Test>, ITestRepository
    {
             
        
        private ApplicationDbContext _db;

        public TestRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }


       

        public void Update(Test obj)
        {
            _db.Tests.Update(obj);
        }
    }
}
