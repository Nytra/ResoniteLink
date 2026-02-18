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
        /// Access the raw data of the cubemap positive X face.
        /// </summary>
        /// <returns>2D Span allowing access to individual pixels of the face</returns>
        public Span2D<C> AccessPositiveX() => AccessFaceRawData(0);

        /// <summary>
        /// Access the raw data of the cubemap positive Y face.
        /// </summary>
        /// <returns>2D Span allowing access to individual pixels of the face</returns>
        public Span2D<C> AccessPositiveY() => AccessFaceRawData(1);

        /// <summary>
        /// Access the raw data of the cubemap positive Z face.
        /// </summary>
        /// <returns>2D Span allowing access to individual pixels of the face</returns>
        public Span2D<C> AccessPositiveZ() => AccessFaceRawData(2);

        /// <summary>
        /// Access the raw data of the cubemap negative X face.
        /// </summary>
        /// <returns>2D Span allowing access to individual pixels of the face</returns>
        public Span2D<C> AccessNegativeX() => AccessFaceRawData(3);

        /// <summary>
        /// Access the raw data of the cubemap negative Y face.
        /// </summary>
        /// <returns>2D Span allowing access to individual pixels of the face</returns>
        public Span2D<C> AccessNegativeY() => AccessFaceRawData(4);

        /// <summary>
        /// Access the raw data of the cubemap negative Z face.
        /// </summary>
        /// <returns>2D Span allowing access to individual pixels of the face</returns>
        public Span2D<C> AccessNegativeZ() => AccessFaceRawData(5);

        /// <summary>
        /// Access the raw data of the cubemap face as span. You MUST specify Size first.
        /// </summary>
        /// <returns>2D Span allowing access to individual pixels of the cubemap face data</returns>
        /// <exception cref="ArgumentOutOfRangeException">When size is invalid or not set</exception>
        /// <exception cref="InvalidOperationException">When size changes after already accessing data.</exception>
        public unsafe Span2D<C> AccessFaceRawData(int faceIndex)
        {
            if (Size <= 0)
                throw new ArgumentOutOfRangeException(nameof(Size));

            if (faceIndex < 0 || faceIndex >= 6)
                throw new ArgumentOutOfRangeException(nameof(faceIndex));

            var elements = Size * Size;
            var faceBytes = sizeof(C) * elements;
            var totalBytes = faceBytes * 6;

            if (RawBinaryPayload == null)
                RawBinaryPayload = new byte[totalBytes];
            else if (RawBinaryPayload.Length != totalBytes)
                throw new InvalidOperationException("Size was changed after data was already accessed. This is not supported");

            return new Span2D<C>(Size, Size, MemoryMarshal.Cast<byte, C>(RawBinaryPayload.AsSpan(faceBytes * faceIndex)));
        }
    }
}
