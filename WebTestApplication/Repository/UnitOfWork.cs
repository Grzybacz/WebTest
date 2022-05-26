//using WebTestApplication.Data;
using WebTestApplication.DataAccess;
using WebTestApplication.Repository.IRepository;

namespace WebTestApplication.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;

            Category = new CategoryRepository(_db);

            Test = new TestRepository(_db);

            TestCart = new TestCartRepository(_db);

            Questions = new QuestionsRepository(_db);

            PupilSession = new PupilSessionRepository(_db);

        }
        public ICategoryRepository Category { get; private set; }

        public ITestRepository Test { get; private set; }

        public ITestCartRepository TestCart { get; private set; }

        public IQuestionsRepository Questions { get; private set; }

        public IPupilSessionRepository PupilSession { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
