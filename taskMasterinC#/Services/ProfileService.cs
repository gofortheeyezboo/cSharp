using System;
using System.Collections.Generic;
using System.Data;
using taskMasterinC_.Models;
using taskMasterinC_.Repositories;

namespace taskMasterinC_.Services
{
  public class ProfileService
  {
    private readonly ProfileRepository _repo;
    public ProfileService(ProfileRepository repo)
    {
      _repo = repo;
    }
    internal Profile GetOrCreateProfile(Profile userInfo)
    {
      Profile profile = _repo.GetById(userInfo.Id);
      if (profile == null)
      {
        return _repo.Create(userInfo);
      }
      return profile;
    }

    internal Profile GetProfileById(string id)
    {
      Profile profile = _repo.GetById(id);
      if (profile == null)
      {
        throw new Exception("Invalid Id");
      }
      return profile;
    }

  }
}