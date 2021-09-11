using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultsRepository
  {
      private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Vault> GetAll()
    {
      string sql = @"
      SELECT
      a.*,
      v.*
      FROM vaults v
      JOIN accounts a ON a.id = v.creatorId;
      ";
      return _db.Query<Profile, Vault, Vault>(sql, (prof, vault) =>
      {
          vault.Creator = prof;
          return vault;
      }, splitOn: "id").ToList<Vault>();
    }

    internal List<Vault> GetAll(string creatorId)
    {
        string sql = @"
        SELECT
         a.*,
         v.*
         FROM vaults v
         JOIN accounts a ON a.id = v.creatorId
         WHERE v.creatorId = @creatorId;
         ";
         return _db.Query<Profile, Vault, Vault>(sql, (prof, vault) =>
         {
             vault.Creator = prof;
             return vault;
         }, new { creatorId }, splitOn: "id").ToList();
    }

    internal List<Vault> GetVaultsByProfileId(string id)
    {
        string sql = @"
        SELECT
         a.*,
         v.*
         FROM vaults v
         JOIN accounts a ON a.id = v.creatorId
         WHERE v.creatorId = @id;
         ";
         return _db.Query<Profile, Vault, Vault>(sql, (prof, vault) =>
         {
             vault.Creator = prof;
             return vault;
         }, new { id }, splitOn: "id").ToList();

    }

    internal Vault GetById(int id)
    {
       string sql = @"
       SELECT 
        a.*,
        v.*
        FROM vaults v
        JOIN accounts a ON a.id = v.creatorId
        WHERE v.id = @id;
        ";
        return _db.Query<Profile, Vault, Vault>(sql, (prof, vault) =>
        {
            vault.Creator = prof;
            return vault;
        }, new { id }, splitOn: "id").FirstOrDefault(); 
    }

    internal Vault Create(Vault newVault)
    {
        string sql = @"
        INSERT INTO vaults
        (name, description, isPrivate, creatorId)
        VALUES
        (@Name, @Description, @IsPrivate, @CreatorId);
        SELECT LAST_INSERT_ID();
        ";
        int id = _db.ExecuteScalar<int>(sql, newVault);
        return GetById(id);
    }

    internal Vault Edit(Vault editedVault)
    {
        string sql = @"
        UPDATE vaults
        SET
            name = @Name,
            description = @Description,
            isPrivate = @IsPrivate
        WHERE id = @Id;
        ";
        _db.Execute(sql, editedVault);
        return GetById(editedVault.Id);

    }

    internal void Delete(int id)
    {
        string sql = "DELETE FROM vaults WHERE id = @id LIMIT 1;";
        _db.ExecuteScalar(sql, new { id });
    }
  }
}