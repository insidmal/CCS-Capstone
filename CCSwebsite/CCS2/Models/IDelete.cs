using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CCS2.Models
{
    public interface IDelete
    {
        bool UserDelete { get; set; }
        bool AdminDelete { get; set; }
    }
}
