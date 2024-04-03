namespace Todo.API.Domain.Request.Put;

public class PutUpdateTodoStatusRequest
{
    /// <summary>
    /// PK
    /// </summary>
    [Display(Name = "TodoId")]
    [Required(ErrorMessage = "{0} 為必填")]
    public Guid TodoId { get; set; }
    /// <summary>
    /// 更改狀態
    /// </summary>
    [Display(Name = "是否完成")]
    [Required(ErrorMessage = "{0} 為必填")]
    [RegularExpression(@"Y|N", ErrorMessage = "{0} 值為Y、N")]
    public string IsComplete { get; set; }
}
