using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;

namespace ResoniteLink
{
    public abstract class ImportCubemapRawDataBase<C> : BinaryPayloadMessage
        where C : unmanaged
    {
        /// <summary>
        /// Size of each face. All faces are square
        /// </summary>
        [JsonPropertyName("size")]
        public int Size { get; set; }

        /// <summary>
        /// Whether mipmap data is included or not.
        /// </summary>
        [JsonPropertyName("mipMaps")]
        public bool MipMaps { get; set; }

        /// <summary>
        /// Indicates number of mipmaps this cubemap will have based on its current Size
        /// </summary>
        [JsonIgnore]
        public int MipMapCount
        {
            get
            {
                // If mipmaps are disabled, it's just the top one
                if (!MipMaps)
                    return 1;

                int count = 1;
                int size = Size;

                while(size > 1)
                {
                    count++;
                    size >>= 1;
                }

                return count;
            }
        }


        /// <summary>
        /// Access the raw data of the cubemap positive X face.
        /// </summary>
        /// <returns>2D Span allowing access to individual pixels of the face</returns>
        public Span2D<C> AccessPositiveX(int mipLevel = 0) => AccessFaceRawData(0, mipLevel);

        /// <summary>
        /// Access the raw data of the cubemap positive Y face.
        /// </summary>
        /// <returns>2D Span allowing access to individual pixels of the face</returns>
        public Span2D<C> AccessPositiveY(int mipLevel = 0) => AccessFaceRawData(1, mipLevel);

        /// <summary>
        /// Access the raw data of the cubemap positive Z face.
        /// </summary>
        /// <returns>2D Span allowing access to individual pixels of the face</returns>
        public Span2D<C> AccessPositiveZ(int mipLevel = 0) => AccessFaceRawData(2, mipLevel);

        /// <summary>
        /// Access the raw data of the cubemap negative X face.
        /// </summary>
        /// <returns>2D Span allowing access to individual pixels of the face</returns>
        public Span2D<C> AccessNegativeX(int mipLevel = 0) => AccessFaceRawData(3, mipLevel);

        /// <summary>
        /// Access the raw data of the cubemap negative Y face.
        /// </summary>
        /// <returns>2D Span allowing access to individual pixels of the face</returns>
        public Span2D<C> AccessNegativeY(int mipLevel = 0) => AccessFaceRawData(4, mipLevel);

        /// <summary>
        /// Access the raw data of the cubemap negative Z face.
        /// </summary>
        /// <returns>2D Span allowing access to individual pixels of the face</returns>
        public Span2D<C> AccessNegativeZ(int mipLevel = 0) => AccessFaceRawData(5, mipLevel);

        /// <summary>
        /// Access the raw data of the cubemap face as span. You MUST specify Size first.
        /// </summary>
        /// <returns>2D Span allowing access to individual pixels of the cubemap face data</returns>
        /// <exception cref="ArgumentOutOfRangeException">When size is invalid or not set</exception>
        /// <exception cref="InvalidOperationException">When size changes after already accessing data.</exception>
        public unsafe Span2D<C> AccessFaceRawData(int faceIndex, int mipLevel = 0)
        {
            if (Size <= 0)
                throw new ArgumentOutOfRangeException(nameof(Size));

            if (faceIndex < 0 || faceIndex >= 6)
                throw new ArgumentOutOfRangeException(nameof(faceIndex));

            // Cache it
            var mipMapCount = MipMapCount;

            if (mipLevel < 0 || mipLevel >= mipMapCount)
                throw new ArgumentOutOfRangeException(nameof(mipLevel));

            int accessOffset = 0;
            int accessSize = Size;
            int accessFaceBytes = 0;

            int totalBytes = 0;

            int size = Size;

            for(int mip = 0; mip < mipMapCount; mip++)
            {
                var mipElements = size * size;
                var faceBytes = sizeof(C) * mipElements;

                if (mip == mipLevel)
                {
                    accessSize = size;
                    accessFaceBytes = faceBytes;
                }

                int mipTotalBytes = faceBytes * 6;

                if (mip < mipLevel)
                    accessOffset += mipTotalBytes;

                totalBytes += mipTotalBytes;

                size >>= 1;
            }

            if (RawBinaryPayload == null)
                RawBinaryPayload = new byte[totalBytes];
            else if (RawBinaryPayload.Length != totalBytes)
                throw new InvalidOperationException("Size was changed after data was already accessed. This is not supported");

            return new Span2D<C>(accessSize, accessSize, MemoryMarshal.Cast<byte, C>(
                RawBinaryPayload.AsSpan(accessOffset + accessFaceBytes * faceIndex)));
        }
    }
}
