using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ResoniteLink
{
    /// <summary>
    /// Represents a playback state (audio, animation and so on).
    /// When getting data, all fields will always be populated with the current state.
    /// However when setting state, you can set any fields to null, which will preserve their current value.
    /// This can be useful to for example change playback state without having to set a specific position or change the loop state.
    /// Note that some operations are also not explicit. E.g. setting Play to False, but keeping position is Pause.
    /// Setting Play to False and setting Position to 0 is Stop.
    /// </summary>
    public class SyncPlayback : Member
    {
        /// <summary>
        /// Indicates if playback is currently playing or not (paused)
        /// </summary>
        [JsonPropertyName("play")]
        public bool? Play { get; set; }

        /// <summary>
        /// When true the playback loops around
        /// </summary>
        [JsonPropertyName("loop")]
        public bool? Loop { get; set; }

        /// <summary>
        /// Current position (in seconds) of the playback
        /// </summary>
        [JsonPropertyName("position")]
        public double? Position { get; set; }

        /// <summary>
        /// Current playback speed
        /// Normal speed is 1.0. 2.0 is twice as fast, 0.5 half the speed
        /// </summary>
        [JsonPropertyName("speed")]
        public float? Speed { get; set; }
    }

    [JsonDerivedType(typeof(SyncPlayback), "playback")]
    public partial class Member { }
}
