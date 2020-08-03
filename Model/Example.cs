using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Example
    {
        //properties
        public string Id { get; set; }
        public string Sentence { get; set; }
        public string Meaning { get; set; }

        //relationships
        public string DescriptionId { get; set; }
        public virtual Description Description { get; set; }
        public Example()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
