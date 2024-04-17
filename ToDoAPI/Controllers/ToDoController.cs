using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Models;
using ToDoAPI.Repositories;

namespace ToDoAPI.Controllers
{
    //[Authorize(Roles = UserRoles.User)]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoRepository _itemRepo;

        public ToDoController(IToDoRepository repo)
        {
            _itemRepo = repo;
        }

        [HttpGet]
        
        public async Task<IActionResult> GetAllItem()
        {
            try
            {
                return Ok(await _itemRepo.GetAllItemAsync());
            }
            catch
            {
                return BadRequest();
            }
            //return Ok(await _itemRepo.GetAllItemAsync());
        }

        [HttpGet("{id}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetItemById(int id)
        {
            try
            {
                var item = await _itemRepo.GetItemAsync(id);
                return item == null ? NotFound() : Ok(item);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> AddNewItem(ToDoItemModel model)
        {
            try
            {
                var newItemId = await _itemRepo.AddItemAsync(model);
                var item = await _itemRepo.GetItemAsync(newItemId);
                return item == null ? NotFound() : Ok(item);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UpdateItem (int id, ToDoItemModel model)
        {
            if (id == model.ItemId)
            {
                await _itemRepo.UpdateItemAsync(id, model);
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteItem (int id)
        {
            try
            {
                await _itemRepo.DeleteItemAsync(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
