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

    internal List<VaultKeepViewModel> GetKeepsByVaultId(int id)
    {
      string sql = @"
      SELECT
      k.*,
      vk.id AS vaultKeepId
      FROM vaultKeeps vk
      JOIN keeps k on vk.keepId = k.Id
      WHERE vk.vaultId = @id;
      ";
      return _db.Query<VaultKeepViewModel>(sql, new {id}).ToList();
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

    
    internal List<Keep> GetAll(int vaultId)
    {
      string sql = @"
      SELECT
      a.*,
      k.*,
      vk.*
      FROM keeps k
      JOIN accounts a ON vk.creatorId = a.id,
      JOIN vaultKeeps vk ON vk.keepId = k.id
      WHERE vk.vaultId = @vaultId;";
      return _db.Query<Profile, Keep, VaultKeep, Keep>(sql, (prof, keep, vaultKeep) =>
      {
        keep.Creator = prof;
        vaultKeep.Id = vaultId;
        return keep;
      }, new { vaultId }, splitOn: "id").ToList();

    }

    
    
    internal Keep Create(Keep newKeep)
    {
      string sql = @"
      INSERT INTO keeps
      (name, description, img, creatorId)
      VALUES
      (@Name, @Description, @Img, @CreatorId);
      SELECT LAST_INSERT_ID();
      ";
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
            img = @Img,
            keeps = @Keeps,
            views = @Views,
            shares = @Shares
        WHERE id = @Id;";
        _db.Execute(sql, original);
        return GetById(original.Id); 
    }
    internal Keep KeepsChange(Keep edit)
    {
      string sql = @"
      UPDATE keeps
      SET 
        keeps = @Keeps
      WHERE id = @Id;";
      _db.ExecuteScalar(sql, edit);
      return GetById(edit.Id);   
    }

    internal void Delete(int id)
    {
        string sql = "DELETE FROM keeps WHERE id = @id LIMIT 1;";
        _db.Execute(sql, new { id });
    }
  }
}