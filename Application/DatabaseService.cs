using Application.Interfaces;

namespace Application;

public class DatabaseService : IDatabaseService
{
    private readonly IDatabaseRepository _repository;
    
    public DatabaseService(IDatabaseRepository repository)
    {
        _repository = repository;
    }
    
    public void RebuildDb()
    {
        _repository.RebuildDb();
    }
}