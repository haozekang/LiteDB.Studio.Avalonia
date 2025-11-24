using LiteDB.Studio.Avalonia.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDB.Studio.Avalonia.Entities
{
    public class ConnectEntity
    {
        public int Id { get; set; }

        public ConnectionModes? Mode { get; set; }

        public string? Filename { get; set; }

        public string? Password { get; set; }

        public string? InitSizeMB { get; set; }

        public string? CultureType { get; set; }

        public string? CompareOption { get; set; }

        public bool? IsReadOnly { get; set; }

        public bool? IsUpgrade { get; set; }

        public DateTime? LastTime { get; set; }
    }
}
