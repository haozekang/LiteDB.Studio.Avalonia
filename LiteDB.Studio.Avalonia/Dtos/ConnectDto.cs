using LiteDB.Studio.Avalonia.Enums;
using Newtonsoft.Json;
using System;

namespace LiteDB.Studio.Avalonia.Dtos
{
    public class ConnectDto
    {
        [JsonProperty("mode")]
        public ConnectionModes? Mode { get; set; }

        [JsonProperty("filename")]
        public string? Filename { get; set; }

        [JsonProperty("password")]
        public string? Password { get; set; }

        [JsonProperty("init_size_mb")]
        public string? InitSizeMB { get; set; }

        [JsonProperty("culture_type")]
        public string? CultureType { get; set; }

        [JsonProperty("compare_option")]
        public string? CompareOption { get; set; }

        [JsonProperty("is_read_only")]
        public bool? IsReadOnly { get; set; }

        [JsonProperty("is_upgrade")]
        public bool? IsUpgrade { get; set; }

        [JsonProperty("last_time")]
        public DateTime? LastTime { get; set; }
    }
}
