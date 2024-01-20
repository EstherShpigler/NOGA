using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SYSMCLTD.API.Data;

namespace SYSMCLTD.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly SYSMCDBContext _sysdbcontext;

        public CustomerController(SYSMCDBContext sysdbcontext)
        {
            this._sysdbcontext = sysdbcontext;
        }

        //Get All
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customer = await _sysdbcontext.customer.ToListAsync(c=>c.);
            return Ok(customer);
        }
        ////שליפת משימה לפי ID
        //[HttpGet]
        //[Route("{id:guid}")]
        //[ActionName("GetTask")]
        //public async Task<IActionResult> GetTask([FromRoute] Guid id)
        //{
        //    var _task = await dtask.task_vm.FirstOrDefaultAsync(x => x.Id == id);
        //    if (_task != null)
        //    {
        //        return Ok(_task);
        //    }
        //    return NotFound("Task Not Found");
        //}


        ////Add Task--הוספת משימה
        //[HttpPost]

        //public async Task<IActionResult> AddTask([FromBody] TaskModel task_m)
        //{
        //    task_m.Id = Guid.NewGuid();
        //    await dtask.task_vm.AddAsync(task_m);
        //    await dtask.SaveChangesAsync();
        //    return CreatedAtAction(nameof(GetTask), new { id = task_m.Id }, task_m);
        //}
        ////עדכון משימה
        //[HttpPut]
        //[Route("{id:guid}")]

        //public async Task<IActionResult> UpdateTask([FromRoute] Guid id, [FromBody] TaskModel task_m)
        //{
        //    var update_task = await dtask.task_vm.FirstOrDefaultAsync(x => x.Id == id);
        //    if (update_task != null)
        //    {
        //        update_task.Type = task_m.Type;
        //        update_task.Name = task_m.Name;
        //        update_task.Description = task_m.Description;
        //        update_task.StartDate = task_m.StartDate;
        //        update_task.EndDate = task_m.EndDate;
        //        update_task.BackTask = task_m.BackTask;
        //        update_task.Finish = task_m.Finish;
        //        update_task.IsActive = task_m.IsActive;
        //        await dtask.SaveChangesAsync();
        //        return Ok(update_task);
        //    }
        //    return NotFound("Task Not Found");

        //}
    }
}
