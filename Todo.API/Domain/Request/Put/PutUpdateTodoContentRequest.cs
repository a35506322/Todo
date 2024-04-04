namespace Todo.API.Domain.Request.Put;

public class PutUpdateTodoContentRequest
{
    /// <summary>
    /// PK
    /// </summary>
    public Guid TodoId { get; set; }
    /// <summary>
    /// 姓名
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 標題
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// 完成事項內容
    /// </summary>
    public string TodoContent { get; set; }
}
