using System;
using System.Collections.Generic;
using System.Data;
using taskMasterinC_.Models;
using Dapper;

namespace taskMasterinC_.Repositories
{
  public class ProfileRepository
  {
    private readonly IDbConnection _db;

    public ProfileRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Profile GetById(string id)
    {
      string sql = "SELECT * FROM profiles WHERE id = @id";
      return _db.QueryFirstOrDefault<Profile>(sql, new { id });
    }

    internal Profile Create(Profile newProfile)
    {
      string sql = @"
            INSERT INTO profiles
              (name, picture, email, id)
            VALUES
              (@Name, @Picture, @Email, @Id)";
      _db.Execute(sql, newProfile);
      return newProfile;
    }

    internal Profile Edit(Profile update)
    {
      string sql = @"
            UPDATE profiles
            SET 
              name = @Name,
              picture = @Picture
            WHERE id = @Id;";
      _db.Execute(sql, update);
      return update;
    }
  }
}