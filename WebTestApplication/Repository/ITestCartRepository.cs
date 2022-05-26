using WebTest.Models;
using WebTestApplication.Models;
using WebTestApplication.Repository.IRepository;

namespace WebTestApplication.Repository
{
    public interface ITestCartRepository: IRepository<TestCart>
    {
        void Update (TestCart obj);

        void UpdateMany(IEnumerable<TestCart> collection);

        //void Save();
    }
}
