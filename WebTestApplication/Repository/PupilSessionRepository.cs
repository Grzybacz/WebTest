using WebTest.Models;
using WebTestApplication.DataAccess;
using WebTestApplication.Models;

namespace WebTestApplication.Repository
{
    public class PupilSessionRepository : Repository<PupilSession>, IPupilSessionRepository
    {


        private ApplicationDbContext _db;

        public PupilSessionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(PupilSession obj)
        {
            _db.PupilSessions.Update(obj);
        }

        public void UpdateMany(PupilSession pupilSessions)
        {
            
            _db.PupilSessions.UpdateRange(pupilSessions);

            _db.SaveChanges();
        }
    }
}
