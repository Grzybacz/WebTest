using WebTest.Models;
using WebTestApplication.Models;
using WebTestApplication.Repository.IRepository;

namespace WebTestApplication.Repository
{
    public interface ICategoryRepository: IRepository<Category>
    {
        void Update (Category obj);

        //void Save();
    }
}
