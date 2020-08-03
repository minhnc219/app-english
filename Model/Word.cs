using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Word
    {
        //properties
        public string Id { get; set; }
        public string Name { get; set; }
        public int Week { get; set; }
        public int Day { get; set; }

        //relationships
        public virtual List<Definition> Definitions { get; set; }
        public Word()
        {
            Id = Guid.NewGuid().ToString();
            Definitions = new List<Definition>();
        }
    }
}
