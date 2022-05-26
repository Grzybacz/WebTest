//using WebTestApplication.Data;
using WebTest.Models;
using WebTestApplication.DataAccess;
using WebTestApplication.Models;

namespace WebTestApplication.Repository
{
    public class QuestionsRepository : Repository<Questions>, IQuestionsRepository
    {
             
        
        private ApplicationDbContext _db;

        public QuestionsRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }



        public void Update(TestCart obj)
        {
            _db.TestCarts.Update(obj);
        }
    }
}
