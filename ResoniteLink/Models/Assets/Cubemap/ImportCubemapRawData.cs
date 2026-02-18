using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;

namespace ResoniteLink
{
    /// <summary>
    /// Imports cubemap from raw 8-bit color data. Resonite will take care of encoding the data into a file format.
    /// </summary>
    public class ImportCubemapRawData : ImportCubemapRawDataBase<color32>
    {
        /// <summary>
        /// Color profile of the cubemap color data
        /// </summary>
        [JsonPropertyName("colorProfile")]
        public string ColorProfile { get; set; }
    }
}
