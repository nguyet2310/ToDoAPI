using ToDoAPI.Models;

namespace ToDoAPI.Repositories
{
    public interface IToDoRepository
    {
        public Task<List<ToDoItemModel>> GetAllItemAsync();
        public Task<ToDoItemModel> GetItemAsync(int id);
        public Task<int> AddItemAsync(ToDoItemModel model);
        public Task UpdateItemAsync(int id, ToDoItemModel model);
        public Task DeleteItemAsync(int id);
    }
}
