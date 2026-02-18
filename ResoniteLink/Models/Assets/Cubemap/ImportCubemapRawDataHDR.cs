using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;

namespace ResoniteLink
{
    /// <summary>
    /// Imports cubemap from raw floating point color data, allowing for HDR values.
    /// Resonite will take care of encoding the data into a file format.
    /// </summary>
    public class ImportCubemapRawDataHDR : ImportCubemapRawDataBase<color>
    {

    }
}
