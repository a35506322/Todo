namespace Todo.API.Repositories.Interfaces;

public interface ITodoRepository
{
    public Task<bool> InsertAsyc(TodoEntity entity);
}
