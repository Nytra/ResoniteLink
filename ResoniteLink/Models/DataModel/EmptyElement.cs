using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ResoniteLink
{
    public class EmptyElement : Member
    {

    }


    [JsonDerivedType(typeof(EmptyElement), "empty")]
    public partial class Member { }
}
