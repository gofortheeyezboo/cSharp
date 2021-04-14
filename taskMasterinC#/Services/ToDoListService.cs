using System;
using System.Collections.Generic;
using System.Linq;
using taskMasterinC_.Models;
using taskMasterinC_.Repositories;

namespace taskMasterinC_.Services
{
  public class ToDoListService
  {
    private readonly ToDoListRepository _repo;

    public ToDoListService(ToDoListRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<ToDoList> Get()
    {
      return _repo.GetAll();
    }

    internal ToDoList GetById(int id)
    {
      ToDoList data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid id");
      }
      return data;
    }

    internal ToDoList Create(ToDoList newToDoList)
    {
      return _repo.Create(newToDoList);
    }

    internal ToDoList Edit(ToDoList updated)
    {
      ToDoList original = GetById(updated.Id);
      if (updated.CreatorId != original.CreatorId)
      {
        throw new Exception("You cannot edit this.");
      }
      updated.Title = updated.Title != null ? updated.Title : original.Title;
      return _repo.Edit(updated);
    }

    internal ToDoList Delete(int id, string userId)
    {
      ToDoList original = GetById(id);
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
    //   return parties.ToList().FindAll(p => p.Public);
    // }

    // internal IEnumerable<PartyPartyMemberViewModel> GetByAccountId(string id)
    // {
    //   return _repo.GetPartiesByProfileId(id);
    // }
  }
}