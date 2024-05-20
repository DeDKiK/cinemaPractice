using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    public class QueryObject
    {
      public string? Genre { get; set; } = null;

      public string? SortBy { get; set; } = null;

      public bool IsDecsending { get; set; } = false;
    }
}