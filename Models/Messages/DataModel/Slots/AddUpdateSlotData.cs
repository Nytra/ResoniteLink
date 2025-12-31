using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ResoniteLink
{
    public abstract class AddUpdateSlotData : Message
    {
        /// <summary>
        /// The ID of the slot to add/update. When adding slot, this does not need to be specified if the slot
        /// isn't referenced and the ID can be allocated by Resonite instead.
        /// </summary>
        [JsonPropertyName("slotId")]
        public string SlotID { get; set; }

        /// <summary>
        /// Data of the slot to set/update.
        /// </summary>
        [JsonPropertyName("data")]
        public Slot Data { get; set; }
    }

    public class AddSlot : AddUpdateSlotData
    {

    }

    public class UpdateSlot : AddUpdateSlotData
    {

    }
}
