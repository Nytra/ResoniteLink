using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ResoniteLink
{
    public class SyncObjectDefinitionData : Response
    {
        /// <summary>
        /// Definition of the sync object that was requested
        /// </summary>
        [JsonPropertyName("definition")]
        public SyncObjectDefinition Definition { get; set; }
    }
}
