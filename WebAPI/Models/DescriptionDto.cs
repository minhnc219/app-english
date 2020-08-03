using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class DescriptionDto
    {
        public string Word { get; set; }
        public string Id { get; set; }
        public string Detail { get; set; }
        public WordType WordType { get; set; }

    }
}
