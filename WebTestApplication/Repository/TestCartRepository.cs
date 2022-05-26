//using WebTestApplication.Data;
using WebTest.Models;
using WebTestApplication.DataAccess;
using WebTestApplication.Models;

namespace WebTestApplication.Repository
{
    public class TestCartRepository : Repository<TestCart>, ITestCartRepository
    {
             
        
        private ApplicationDbContext _db;

        public TestCartRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }


        //public void Save()
        //{
        //    _db.SaveChanges();
        //}

        public void Update(TestCart obj)
        {
            var objFromDb = _db.TestCarts.FirstOrDefault(u => u.Id == obj.Id);
            if(objFromDb != null)
            {
                objFromDb.Content = obj.Content;
            }
        }

        public void UpdateMany(IEnumerable<TestCart> testCarts)
        {
            //var testCartsIds = testCarts.Select(x => x.Id).ToArray();
            //var testCartsDb = _db.TestCarts
            //    .Where(x => testCartsIds.Contains(x.Id))
            //    .ToArray();

            _db.TestCarts.UpdateRange(testCarts);

            _db.SaveChanges();
        }
    }
}
