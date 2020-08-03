using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class ExampleRepository : RepositoryBase<Example>, IExampleRepository
    {
        public ExampleRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

        public bool ExampleExists(string exampleId)
        {
            return dbSet.Any(example => example.Id == exampleId);
        }

        public Example GetExample(string exampleId)
        {
            return dbSet.Where(example => example.Id == exampleId).FirstOrDefault();
        }

        public List<Example> GetExamples(string descriptionId)
        {
            return dbContext.Descriptions.Where(description => description.Id == descriptionId).FirstOrDefault().Examples;
        }
    }
}
