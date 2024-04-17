using AutoMapper;
using ToDoAPI.Data;
using ToDoAPI.Models;

namespace ToDoAPI.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<ToDoItem, ToDoItemModel>().ReverseMap();
        }
    }
}
