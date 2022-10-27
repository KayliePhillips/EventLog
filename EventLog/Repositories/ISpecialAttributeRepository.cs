using System;
using System.Collections.Generic;
using EventLog.Models;


namespace EventLog.Repositories
{
    public interface ISpecialAttributeRepository
    {
        public IEnumerable<SpecialAttribute> GetAllSpecialAttributes();

    }
}
