using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ResoniteLink
{
    /// <summary>
    /// Response from Resonite to a message that has been sent. This can simply indicate success/failure
    /// or contain response data when requested.
    /// </summary>
    public abstract class Response
    {
        /// <summary>
        /// Unique ID of the message that this response is to.
        /// </summary>
        [JsonPropertyName("sourceMessageId")]
        public string SourceMessageID { get; set; }
    }
}
