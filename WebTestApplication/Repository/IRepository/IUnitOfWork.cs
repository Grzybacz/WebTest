namespace WebTestApplication.Repository.IRepository
{
    public interface IUnitOfWork
    { 
        ICategoryRepository Category { get; }

        ITestRepository Test { get; }

        ITestCartRepository TestCart { get; }

        IQuestionsRepository Questions { get; }

        IPupilSessionRepository PupilSession { get; }

        void Save();
    }
}
