﻿namespace Todo.API.Domain.Entity;

public class TodoEntity
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
    /// <summary>
    /// 是否完成 (Y:是 N:否)
    /// </summary>
    public string IsComplete { get; set; }
    /// <summary>
    /// 新增時間
    /// </summary>
    public DateTime AddTime { get; set; }
    /// <summary>
    /// 完成時間
    /// </summary>
    public DateTime? CompleteTime { get; set; }
}
