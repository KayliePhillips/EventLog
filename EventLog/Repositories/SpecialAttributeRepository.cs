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
    }
}
