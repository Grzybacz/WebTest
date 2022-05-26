using WebTest.Models;
using WebTestApplication.Models;
using WebTestApplication.Repository.IRepository;

namespace WebTestApplication.Repository
{
    public interface IPupilSessionRepository : IRepository<PupilSession>
    {
        void Update(PupilSession obj);

        void UpdateMany(PupilSession obj);
    }
}
