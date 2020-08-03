using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Description
    {
        //properties
        public string Id { get; set; }
        public string Detail { get; set; }

        //relationships
        public string DefinitionId { get; set; }
        public virtual Definition Definition { get; set; }
        public virtual List<Example> Examples { get; set; }
        public Description()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
