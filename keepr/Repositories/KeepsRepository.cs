using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class KeepsRepository
  {
      private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Keep> GetAll()
    {
      string sql = @"
      SELECT 
        a.*,
        k.*
        FROM keeps k
        JOIN accounts a ON a.id = k.creatorId;";
      return _db.Query<Profile, Keep, Keep>(sql, (prof, keep) =>
      {
          keep.Creator = prof;
          return keep;
      }, splitOn: "id").ToList<Keep>();      
    }

    internal List<Keep> GetByProfileId(String id)
    {
      string sql = @"
      SELECT
       a.*,
       k.*
       FROM keeps k
       JOIN accounts a ON a.id = k.creatorId
       WHERE k.creatorId = @id;";
       return _db.Query<Profile, Keep, Keep>(sql, (prof, keep) =>
       {
         keep.Creator = prof;
         return keep;
       }, new { id }, splitOn: "id").ToList();
    }

    internal Keep GetById(int id)
    {
        string sql = @"
        SELECT
          a.*,
          k.*
          FROM keeps k
          JOIN accounts a ON a.id = k.creatorId
          WHERE k.id = @id;";
          return _db.Query<Profile, Keep, Keep>(sql, (prof, keep) =>
          {
              keep.Creator = prof;
              return keep;
          }, new {id}, splitOn: "id").FirstOrDefault();
    }
    internal Keep Create(Keep newKeep)
    {
      string sql = @"
      INSERT INTO keeps
      (name, description, img, creatorId)
      VALUES
      (@Name, @Description, @Img, @CreatorId);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newKeep);
      return GetById(id);
    }


    internal Keep Edit(Keep original)
    {
        string sql = @"
        UPDATE keeps
        SET
            name = @Name,
            description = @Description,
            img = @Img
        WHERE id = @Id;";
        _db.Execute(sql, original);
        return GetById(original.Id); 
    }
    internal void Delete(int id)
    {
        string sql = "DELETE FROM keeps WHERE id = @id LIMIT 1;";
        _db.Execute(sql, new { id });
    }
  }
}