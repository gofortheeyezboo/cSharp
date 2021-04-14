using System;
using System.Collections.Generic;
using System.Linq;
using taskMasterinC_.Models;
using taskMasterinC_.Repositories;

namespace taskMasterinC_.Services
{
  public class ToDoTaskService
  {
    private readonly ToDoTaskRepository _repo;

    public ToDoTaskService(ToDoTaskRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<ToDoTask> Get()
    {
      return _repo.GetAll();
    }

    internal ToDoTask GetById(int id)
    {
      ToDoTask data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid id");
      }
      return data;
    }

    internal ToDoTask Create(ToDoTask newToDoTask)
    {
      return _repo.Create(newToDoTask);
    }

    internal ToDoTask Edit(ToDoTask updated)
    {
      ToDoTask original = GetById(updated.Id);
      if (updated.CreatorId != original.CreatorId)
      {
        throw new Exception("You cannot edit this.");
      }
      updated.Body = updated.Body != null ? updated.Body : original.Body;
      return _repo.Edit(updated);
    }

    internal ToDoTask Delete(int id, string userId)
    {
      ToDoTask original = GetById(id);
      if (userId != original.CreatorId)
      {
        throw new Exception("You cannot delete this.");
      }
      _repo.Delete(id);
      return original;
    }

    // internal IEnumerable<PartyPartyMemberViewModel> GetByProfileId(string id)
    // {
    //   IEnumerable<PartyPartyMemberViewModel> parties = _repo.GetPartiesByProfileId(id);
    //   return parties.ToTask().FindAll(p => p.Public);
    // }

    // internal IEnumerable<PartyPartyMemberViewModel> GetByAccountId(string id)
    // {
    //   return _repo.GetPartiesByProfileId(id);
    // }
  }
}