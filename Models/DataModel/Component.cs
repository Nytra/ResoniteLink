using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ResoniteLink
{
    public class Component : Worker
    {
        /// <summary>
        /// Members (fields, references, lists...) of this component and their data
        /// </summary>
        [JsonPropertyName("members")]
        public Dictionary<string, Member> Members { get; set; } = new Dictionary<string, Member>(); 
    }
}
