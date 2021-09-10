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
  }
}