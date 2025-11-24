using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDB.Studio.Avalonia.Entities
{
    public class SystemConfigEntity
    {
        public int Id { get; set; }

        public string? Key { get; set; }

        public object? Value { get; set; }
    }
}
