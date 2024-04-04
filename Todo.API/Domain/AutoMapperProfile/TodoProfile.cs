namespace Todo.API.Domain.AutoMapperProfile;

public class TodoProfile : Profile
{
    public TodoProfile()
    {
        CreateMap<PostTodoRequest, TodoEntity>()
            .AfterMap((src, dest) => dest.IsComplete = "N")
            .AfterMap((src, dest) => dest.AddTime = DateTime.Now);
        CreateMap<QueryTodoRequest, TodoEntity>();
        CreateMap<PutUpdateTodoStatusRequest, TodoEntity>()
            .AfterMap((src, dest) => dest.CompleteTime = src.IsComplete == "Y" ? DateTime.Now : null);
        CreateMap<PutUpdateTodoContentRequest, TodoEntity>();
    }
}
