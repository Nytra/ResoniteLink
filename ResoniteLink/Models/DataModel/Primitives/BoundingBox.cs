using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;

namespace ResoniteLink
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BoundingBox
    {
        [JsonPropertyName("min")]
        public float3 min { get; set; }

        [JsonPropertyName("max")]
        public float3 max { get; set; }
    }
}
