namespace Todo.API.Repositories.Interfaces;

public interface ITodoRepository
{
    /// <summary>
    /// 多筆取得Todo
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<IEnumerable<TodoEntity>> GetAsync(TodoEntity? entity = null);
    /// <summary>
    /// 單筆新增 Todo
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<bool> InsertAsync(TodoEntity entity);
    /// <summary>
    /// 單筆修改狀態
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<bool> UpdateTodoStatusByTodoIdAsync(TodoEntity entity);
    /// <summary>
    /// 單筆取得Todo
    /// </summary>
    /// <param name="TodoId">PK</param>
    /// <returns></returns>
    public Task<TodoEntity?> GetByTodoIdAsync(Guid TodoId);
    /// <summary>
    /// 單筆刪除Todo
    /// </summary>
    /// <param name="TodoId">PK</param>
    /// <returns></returns>
    public Task<bool> DeleteByTodoIdAsync(Guid TodoId);
    /// <summary>
    /// 單筆修改內容
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<bool> UpdateTodoByTodoIdAsync(TodoEntity entity);
}
