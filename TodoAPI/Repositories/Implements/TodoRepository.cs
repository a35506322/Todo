namespace Todo.API.Repositories.Implements;

public class TodoRepository : ITodoRepository
{
    private readonly DatabaseConnHelper _databaseConnHelper;
    public TodoRepository(DatabaseConnHelper databaseConnHelper)
    {
        this._databaseConnHelper = databaseConnHelper;
    }

    public async Task<bool> DeleteByTodoIdAsync(Guid TodoId)
    {
        string sql = @" DELETE FROM [Todo].[dbo].[TodoList]
                        WHERE TodoId = @TodoId ";

        using var conn = _databaseConnHelper.TodoConnection();
        var count = await conn.ExecuteAsync(sql, new { TodoId = TodoId });
        if (count != 1) return false;
        return true;
    }

    public async Task<IEnumerable<TodoEntity>> GetAsync(TodoEntity? entity)
    {
        string sql = @"SELECT *
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

    public async Task<TodoEntity?> GetByTodoIdAsync(Guid TodoId)
    {
        string sql = @"SELECT *
                      FROM [Todo].[dbo].[TodoList] 
                      Where TodoId = @TodoId  ";

        using var conn = _databaseConnHelper.TodoConnection();
        var todo = await conn.QuerySingleOrDefaultAsync<TodoEntity>(sql,new { TodoId = TodoId });
        return todo;
    }

    public async Task<bool> InsertAsync(TodoEntity entity)
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

    public async Task<bool> UpdateTodoByTodoIdAsync(TodoEntity entity)
    {
        string sql = @"UPDATE [Todo].[dbo].[TodoList]
                       SET [Name] = @Name
                          ,[Title] = @Title
                          ,[TodoContent] = @TodoContent
                        WHERE TodoId = @TodoId";

        using var conn = _databaseConnHelper.TodoConnection();
        var count = await conn.ExecuteAsync(sql, entity);
        if (count != 1) return false;
        return true;
    }

    public async Task<bool> UpdateTodoStatusByTodoIdAsync(TodoEntity entity)
    {
        string sql = @"UPDATE [Todo].[dbo].[TodoList]
                       SET [IsComplete] = @IsComplete
                          ,[CompleteTime] = @CompleteTime
                        WHERE TodoId = @TodoId";

        using var conn = _databaseConnHelper.TodoConnection();
        var count = await conn.ExecuteAsync(sql, entity);
        if (count != 1) return false;
        return true;
    }
}
