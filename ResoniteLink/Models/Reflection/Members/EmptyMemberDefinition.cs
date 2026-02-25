using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ResoniteLink
{
    /// <summary>
    /// Empty members don't contain any data model data, but they can be referenced by other pieces of code.
    /// This is often used for linking things, e.g. ProtoFlux nodes.
    /// </summary>
    public class EmptyMemberDefinition : MemberDefinition
    {
        // Nothing needed here. MemberDefinition already contains the type of this member
    }
}
