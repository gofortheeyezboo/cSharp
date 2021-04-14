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
  public class ToDoListController : ControllerBase
  {
    private readonly ToDoListService _service;

    public ToDoListController(ToDoListService service)
    {
      _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ToDoList>> Get()
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
    public ActionResult<IEnumerable<ToDoList>> Get(int id)
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
    public async Task<ActionResult<ToDoList>> CreateAsync([FromBody] ToDoList newToDoList)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newToDoList.CreatorId = userInfo.Id;
        newToDoList.Creator = userInfo;
        return Ok(_service.Create(newToDoList));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ToDoList>> Edit([FromBody] ToDoList updated, int id)
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
    public async Task<ActionResult<ToDoList>> Delete(int id)
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