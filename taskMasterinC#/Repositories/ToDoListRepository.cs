using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using taskMasterinC_.Models;
using Dapper;

namespace taskMasterinC_.Repositories
{
  public class ToDoListRepository
  {
    private readonly IDbConnection _db;
    public ToDoListRepository(IDbConnection db)
    {
      _db = db;
    }


    internal IEnumerable<ToDoList> GetAll()
    {
      string sql = @"
      SELECT 
      todolist.*,
      prof.*
      FROM todolists todolist
      JOIN profiles prof ON todolist.creatorId = prof.id";
      return _db.Query<ToDoList, Profile, ToDoList>(sql, (todolist, profile) =>
      {
        todolist.Creator = profile;
        return todolist;
      }, splitOn: "id");
    }

    internal ToDoList GetById(int id)
    {
      string sql = @" 
      SELECT 
      todolist.*,
      prof.*
      FROM todolists todolist
      JOIN profiles prof ON todolist.creatorId = prof.id
      WHERE todolist.id = @id";
      return _db.Query<ToDoList, Profile, ToDoList>(sql, (todolist, profile) =>
      {
        todolist.Creator = profile;
        return todolist;
      }, new { id }, splitOn: "id").FirstOrDefault();
    }

    internal ToDoList Create(ToDoList newToDoList)
    {
      string sql = @"
      INSERT INTO todolists 
      (title, body, creatorId) 
      VALUES 
      (@Title, @Body, @CreatorId);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newToDoList);
      newToDoList.Id = id;
      return newToDoList;
    }

    internal ToDoList Edit(ToDoList updated)
    {
      string sql = @"
        UPDATE todolists
        SET
         title = @Title,
         body = @Body,
        WHERE id = @Id;";
      _db.Execute(sql, updated);
      return updated;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM todolists WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }


    // internal IEnumerable<WishListProductViewModel> GetProductsByListId(int id)
    // {
    //   string sql = @"SELECT 
    //   p.*,
    //   wlp.id AS WishListProductId
    //   FROM wishlistproducts wlp
    //   JOIN products p ON p.id = wlp.productId
    //   WHERE wishlistId = @id;";
    //   return _db.Query<WishListProductViewModel>(sql, new { id });
    // }
  }
}