using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Definition
    {
        //properties
        public string Id { get; set; }

        public string IPA { get; set; }
        public WordType Type { get; set; }

        //relationships
        public string WordId { get; set; }
        public virtual Word Word { get; set; }
        public virtual List<Description> Descriptions { get; set; }
        public Definition()
        {
            Id = Guid.NewGuid().ToString();

        }
    }
}
