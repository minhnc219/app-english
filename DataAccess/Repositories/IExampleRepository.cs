using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public interface IExampleRepository
    {
        Example GetExample(string exampleId);
        List<Example> GetExamples(string descriptionId);
        bool ExampleExists(string exampleId);
    }
}
