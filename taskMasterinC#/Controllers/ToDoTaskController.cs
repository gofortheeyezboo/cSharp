using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Mvc;
using taskMasterinC_.Models;
using taskMasterinC_.Services;

namespace taskMasterinC_.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ToDoTaskController : ControllerBase
  {
    private readonly ToDoTaskService _service;

    public ToDoTaskController(ToDoTaskService service)
    {
      _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ToDoTask>> Get()
    {
      try
      {
        return Ok(_service.Get());
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<IEnumerable<ToDoTask>> Get(int id)
    {
      try
      {
        return Ok(_service.GetById(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPost]
    public async Task<ActionResult<ToDoTask>> CreateAsync([FromBody] ToDoTask newToDoTask)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newToDoTask.CreatorId = userInfo.Id;
        newToDoTask.Creator = userInfo;
        return Ok(_service.Create(newToDoTask));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ToDoTask>> Edit([FromBody] ToDoTask updated, int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        updated.CreatorId = userInfo.Id;
        updated.Id = id;
        updated.Creator = userInfo;
        return Ok(_service.Edit(updated));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult<ToDoTask>> Delete(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_service.Delete(id, userInfo.Id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
  }
}