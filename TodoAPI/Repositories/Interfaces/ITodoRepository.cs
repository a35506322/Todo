namespace Todo.API.Repositories.Interfaces;

public interface ITodoRepository
{
    /// <summary>
    /// 多筆取得Todo
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<IEnumerable<TodoEntity>> GetAsyc(TodoEntity? entity = null);
    /// <summary>
    /// 單筆新增 Todo
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<bool> InsertAsyc(TodoEntity entity);
}
