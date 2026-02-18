using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ResoniteLink
{
    /// <summary>
    /// Import cubemap asset from a local file system from a single image file with regions specifying location of each face.
    /// Note that the image file needs to be supported by Resonite, otherwise this will fail.
    /// If you are unsure if the file format is supported, send raw texture data instead.
    /// The regions are in normalized coordinates from 0...1 range and will be calculated to actual pixel locations.
    /// </summary>
    public class ImportCubemapFileWithRegions : Message
    {
        /// <summary>
        /// Path to a texture file representing the cubemap
        /// </summary>
        [JsonPropertyName("filePath")]
        public string FilePath { get; set; }

        /// <summary>
        /// Normalized region of the image file representing positive X face
        /// </summary>
        [JsonPropertyName("positiveXregion")]
        public Rect PositiveXRegion { get; set; }

        /// <summary>
        /// Normalized region of the image file representing positive Y face
        /// </summary>
        [JsonPropertyName("positiveYregion")]
        public Rect PositiveYRegion { get; set; }

        /// <summary>
        /// Normalized region of the image file representing positive Z face
        /// </summary>
        [JsonPropertyName("positiveZregion")]
        public Rect PositiveZRegion { get; set; }

        /// <summary>
        /// Normalized region of the image file representing negative X face
        /// </summary>
        [JsonPropertyName("negativeXregion")]
        public Rect NegativeXRegion { get; set; }

        /// <summary>
        /// Normalized region of the image file representing negative Y face
        /// </summary>
        [JsonPropertyName("negativeYregion")]
        public Rect NegativeYRegion { get; set; }

        /// <summary>
        /// Normalized region of the image file representing negative Z face
        /// </summary>
        [JsonPropertyName("negativeZregion")]
        public Rect NegativeZRegion { get; set; }
    }
}
