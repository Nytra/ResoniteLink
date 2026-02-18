using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ResoniteLink
{
    /// <summary>
    /// Import a cubemap asset from a files on the local file system. Note that all image files need
    /// to be supported by Resonite, otherwise this will fail.
    /// If you are unsure if the file format is supported, send raw texture data instead.
    /// Ideally all files should also be same format and size. Otherwise they will be resized
    /// to match the largest dimensions, which can lower the quality.
    /// </summary>
    public class ImportCubemapFiles : Message
    {
        /// <summary>
        /// Path to a texture file representing positive X axis face
        /// </summary>
        [JsonPropertyName("filePathPositiveX")]
        public string FilePathPositiveX { get; set; }

        /// <summary>
        /// Path to a texture file representing positive Y axis face
        /// </summary>
        [JsonPropertyName("filePathPositiveY")]
        public string FilePathPositiveY { get; set; }

        /// <summary>
        /// Path to a texture file representing positive Z axis face
        /// </summary>
        [JsonPropertyName("filePathPositiveZ")]
        public string FilePathPositiveZ { get; set; }

        /// <summary>
        /// Path to a texture file representing negative X axis face
        /// </summary>
        [JsonPropertyName("filePathNegativeX")]
        public string FilePathNegativeX { get; set; }

        /// <summary>
        /// Path to a texture file representing negative Y axis face
        /// </summary>
        [JsonPropertyName("filePathNegativeY")]
        public string FilePathNegativeY { get; set; }

        /// <summary>
        /// Path to a texture file representing negative Z axis face
        /// </summary>
        [JsonPropertyName("filePathNegativeZ")]
        public string FilePathNegativeZ { get; set; }
    }
}
