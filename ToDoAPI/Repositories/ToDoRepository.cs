using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Data;
using ToDoAPI.Models;

namespace ToDoAPI.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ToDoRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddItemAsync(ToDoItemModel model)
        {
            var newItem = _mapper.Map<ToDoItem>(model);
            _context.ToDoItems!.Add(newItem);
            await _context.SaveChangesAsync();
            return newItem.ItemId;
        }

        public async Task DeleteItemAsync(int id)
        {
            var deleteItem = _context.ToDoItems!.SingleOrDefault(t => t.ItemId == id);
            if(deleteItem != null)
            {
                _context.ToDoItems!.Remove(deleteItem);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<ToDoItemModel>> GetAllItemAsync()
        {
            var items = await _context.ToDoItems!.ToListAsync();
            return _mapper.Map<List<ToDoItemModel>>(items);
        }

        public async Task<ToDoItemModel> GetItemAsync(int id)
        {
            var item = await _context.ToDoItems!.FindAsync(id);
            return _mapper.Map<ToDoItemModel>(item);
        }

        public async Task UpdateItemAsync(int id, ToDoItemModel model)
        {
            if(id == model.ItemId)
            {
                var updateItem = _mapper.Map<ToDoItem>(model);
                _context.ToDoItems!.Update(updateItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
