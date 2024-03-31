namespace Todo.API.Domain.Request.Post;

public class PostTodoRequest
{
    /// <summary>
    /// 姓名
    /// </summary>
    [Display(Name = "姓名")]
    [Required(ErrorMessage = "{0} 為必填")]
    public string Name { get; set; }
    /// <summary>
    /// 標題
    /// </summary>
    [Display(Name = "標題")]
    [Required(ErrorMessage = "{0} 為必填")]
    public string Title { get; set; }
    /// <summary>
    /// 完成事項內容
    /// </summary>
    [Display(Name = "完成事項內容")]
    [Required(ErrorMessage = "{0} 為必填")]
    public string TodoContent { get; set; }
}
