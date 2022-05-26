using WebTest.Models;
using WebTestApplication.Models;
using WebTestApplication.Repository.IRepository;

namespace WebTestApplication.Repository
{
    public interface ITestRepository: IRepository<Test>
    {
        void Update (Test obj);

        //void Save();
    }
}
