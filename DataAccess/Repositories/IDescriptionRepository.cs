using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public interface IDescriptionRepository
    {
        Description GetDescription(string descriptionId);
        List<Description> GetDescriptions(string definitionId);
        bool DescriptionExists(string descriptionId);
    }
}
