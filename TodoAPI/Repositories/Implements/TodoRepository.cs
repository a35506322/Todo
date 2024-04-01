namespace Todo.API.Repositories.Implements;

public class TodoRepository : ITodoRepository
{
    private readonly DatabaseConnHelper _databaseConnHelper;
    public TodoRepository(DatabaseConnHelper databaseConnHelper)
    {
        this._databaseConnHelper = databaseConnHelper;
    }

    public async Task<IEnumerable<TodoEntity>> GetAsyc(TodoEntity? entity)
    {
        string sql = @"SELECT [TodoId]
                          ,[Name]
                          ,[Title]
                          ,[TodoContent]
                          ,[IsComplete]
                          ,[AddTime]
                          ,[CompleteTime]
                      FROM [Todo].[dbo].[TodoList] 
                      Where 1 = 1  ";

        if (entity is not null)
        {
            if (!String.IsNullOrEmpty(entity.Name))
            {
                sql += " And Name = @Name ";
            }
        }

        using var conn = _databaseConnHelper.TodoConnection();
        var todos = await conn.QueryAsync<TodoEntity>(sql, entity);
        return todos;
    }

    public async Task<bool> InsertAsyc(TodoEntity entity)
    {
        string sql = @"INSERT INTO [Todo].[dbo].[TodoList]
                           ([Name]
                           ,[Title]
                           ,[TodoContent]
                           ,[IsComplete]
                           ,[AddTime])
                     VALUES
                           (@Name
                           ,@Title
                           ,@TodoContent
                           ,@IsComplete
                           ,@AddTime)";

        using var conn = _databaseConnHelper.TodoConnection();
        var count = await conn.ExecuteAsync(sql, entity);
        if (count != 1) return false;
        return true;
    }
}
