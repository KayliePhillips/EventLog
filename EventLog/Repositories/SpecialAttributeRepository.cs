using Dapper;
using EventLog.Models;
using System;
using System.Data;

namespace EventLog.Repositories
{
    public class SpecialAttributeRepository : ISpecialAttributeRepository
    {
        private readonly IDbConnection _specialConn;

        public SpecialAttributeRepository(IDbConnection specialConn)
        {
            _specialConn = specialConn;
        }
         
        public IEnumerable<SpecialAttribute> GetAllSpecialAttributes()
        {
            return _specialConn.Query<SpecialAttribute>("SELECT * FROM special_attribute;");
        }
        public void InsertSpecialAttribute(SpecialAttribute specialAttributeToInsert)
        {
            _specialConn.Execute("INSERT INTO special_attribute (SpecialAttributeName) VALUES (@SpecialAttributeName);",
                new { specialAttributeToInsert.SpecialAttributeName });
        }

        public SpecialAttribute GetSpecialAttribute(int id)
        {
            return _specialConn.QuerySingle<SpecialAttribute>("SELECT * FROM special_attribute WHERE SpecialattributeID = @id;", new {id});
        }
        public void UpdateSpecialAttribute(SpecialAttribute specialAttributeToUpdate)
        {
            _specialConn.Execute("UPDATE special_attribute SET SpecialAttributeName = @name WHERE SpecialAttributeID = @id",
                new { name = specialAttributeToUpdate.SpecialAttributeName, id = specialAttributeToUpdate.SpecialAttributeID });
        }

        public void DeleteSpecialAttribute(SpecialAttribute specialAttributeToDelete)
        {
            _specialConn.Execute("DELETE FROM all_event WHERE SpecialAttributeName = @name;", new { name = specialAttributeToDelete.SpecialAttributeName });
            _specialConn.Execute("DELETE FROM special_attribute WHERE SpecialAttributeID = @id;", new { id = specialAttributeToDelete.SpecialAttributeID });
        }


    }
}
