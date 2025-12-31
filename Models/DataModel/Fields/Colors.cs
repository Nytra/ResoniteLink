using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ResoniteLink
{
    public class Field_color : Field
    {
        [JsonPropertyName("r")]
        public float r { get; set; }

        [JsonPropertyName("g")]
        public float g { get; set; }

        [JsonPropertyName("b")]
        public float b { get; set; }

        [JsonPropertyName("a")]
        public float a { get; set; }
    }

    public class Field_colorX : Field
    {
        [JsonPropertyName("profile")]
        public string Profile { get; set; }
    }

    public class Field_color32 : Field
    {
        [JsonPropertyName("r")]
        public byte r { get; set; }

        [JsonPropertyName("g")]
        public byte g { get; set; }

        [JsonPropertyName("b")]
        public byte b { get; set; }

        [JsonPropertyName("a")]
        public byte a { get; set; }
    }

    [JsonDerivedType(typeof(Field_color), "color")]
    [JsonDerivedType(typeof(Field_colorX), "colorX")]
    [JsonDerivedType(typeof(Field_color32), "color32")]
    public partial class Member { }
}