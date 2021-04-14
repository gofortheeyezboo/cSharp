using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using taskMasterinC_.Models;
using Dapper;

namespace taskMasterinC_.Repositories
{
  public class ToDoTaskRepository
  {
    private readonly IDbConnection _db;
    public ToDoTaskRepository(IDbConnection db)
    {
      _db = db;
    }


    internal IEnumerable<ToDoTask> GetAll()
    {
      string sql = @"
      SELECT 
      todotask.*,
      prof.*
      FROM todotasks todotask
      JOIN profiles prof ON todotask.creatorId = prof.id";
      return _db.Query<ToDoTask, Profile, ToDoTask>(sql, (todotask, profile) =>
      {
        todotask.Creator = profile;
        return todotask;
      }, splitOn: "id");
    }

    internal ToDoTask GetById(int id)
    {
      string sql = @" 
      SELECT 
      todotask.*,
      prof.*
      FROM todotasks todotask
      JOIN profiles prof ON todotask.creatorId = prof.id
      WHERE todotask.id = @id";
      return _db.Query<ToDoTask, Profile, ToDoTask>(sql, (todotask, profile) =>
      {
        todotask.Creator = profile;
        return todotask;
      }, new { id }, splitOn: "id").FirstOrDefault();
    }

    internal ToDoTask Create(ToDoTask newToDoTask)
    {
      string sql = @"
      INSERT INTO todotasks 
      (body, creatorId) 
      VALUES 
      ( @Body, @CreatorId);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newToDoTask);
      newToDoTask.Id = id;
      return newToDoTask;
    }

    internal ToDoTask Edit(ToDoTask updated)
    {
      string sql = @"
        UPDATE todotasks
        SET
         body = @Body,
        WHERE id = @Id;";
      _db.Execute(sql, updated);
      return updated;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM todotasks WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }
  }
}