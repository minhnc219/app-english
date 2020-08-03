using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class DescriptionRepository : RepositoryBase<Description>, IDescriptionRepository
    {
        public DescriptionRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

        public bool DescriptionExists(string descriptionId)
        {
            return dbSet.Any(description => description.Id == descriptionId);
        }

        public Description GetDescription(string descriptionId)
        {
            return dbSet.Where(description => description.Id == descriptionId).FirstOrDefault();
        }

        public List<Description> GetDescriptions(string definitionId)
        {
            return dbContext.Definitions.Where(definition => definition.Id == definitionId).FirstOrDefault().Descriptions;
        }
    }
}
