using System;
using System.Collections.Generic;
using EventLog.Models;


namespace EventLog.Repositories
{
    public interface ISpecialAttributeRepository
    {
        public IEnumerable<SpecialAttribute> GetAllSpecialAttributes();
        public void InsertSpecialAttribute(SpecialAttribute specialAttributeToInsert);

        public SpecialAttribute GetSpecialAttribute(int id);

        public void UpdateSpecialAttribute(SpecialAttribute specialAttributeToUpdate);

        public void DeleteSpecialAttribute(SpecialAttribute specialAttributeToDelete);

    }
}
