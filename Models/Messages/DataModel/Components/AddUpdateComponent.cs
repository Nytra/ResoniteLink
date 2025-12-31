using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ResoniteLink
{
    public abstract class AddUpdateComponent : Message
    {
        /// <summary>
        /// The ID of the component that's being added/updated. When being added, this can be omitted.
        /// The ID will be allocated by Resonite, but for any subsequent updates you'll need to fetch it back.
        /// </summary>
        [JsonPropertyName("componentId")]
        public string ComponentID { get; set; }

        /// <summary>
        /// The state of the component data. Any members that are not included will be left as is.
        /// </summary>
        [JsonPropertyName("data")]
        public Component Data { get; set; }
    }

    public class AddComponent : AddUpdateComponent
    {
        /// <summary>
        /// The ID of the Slot that this component should be added to.
        /// </summary>
        [JsonPropertyName("containerSlotId")]
        public string ContainerSlotId { get; set; }
    }

    public class UpdateComponent : AddUpdateComponent
    {

    }
}
