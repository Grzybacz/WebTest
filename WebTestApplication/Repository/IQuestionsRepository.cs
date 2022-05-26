using WebTest.Models;
using WebTestApplication.Models;
using WebTestApplication.Repository.IRepository;

namespace WebTestApplication.Repository
{
    public interface IQuestionsRepository: IRepository<Questions>
    {
        void Update (TestCart obj);

        
    }
}
