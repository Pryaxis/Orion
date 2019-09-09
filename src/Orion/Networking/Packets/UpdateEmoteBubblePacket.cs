﻿using System.IO;

namespace Orion.Networking.Packets {
    /// <summary>
    /// Packet sent to the client to update an emote bubble.
    /// </summary>
    public sealed class UpdateEmoteBubblePacket : Packet {
        /// <summary>
        /// Gets or sets the emote ID.
        /// </summary>
        public int EmoteId { get; set; }

        /// <summary>
        /// Gets or sets the anchor type.
        /// </summary>
        public byte AnchorType { get; set; }

        /// <summary>
        /// Gets or sets the anchor index.
        /// </summary>
        public ushort AnchorIndex { get; set; }

        /// <summary>
        /// Gets or sets the lifetime.
        /// </summary>
        public byte Lifetime { get; set; }

        /// <summary>
        /// Gets or sets the emotion.
        /// </summary>
        public byte Emotion { get; set; }

        /// <summary>
        /// Gets or sets the metadata.
        /// </summary>
        public ushort Metadata { get; set; }

        private protected override void ReadFromReader(BinaryReader reader, ushort packetLength) {
            EmoteId = reader.ReadInt32();
            AnchorType = reader.ReadByte();
            if (AnchorType == byte.MaxValue) {
                return;
            }

            AnchorIndex = reader.ReadUInt16();
            Lifetime = reader.ReadByte();
            EmoteId = reader.ReadByte();
            if ((sbyte)Emotion < 0) {
                Metadata = reader.ReadUInt16();
            }
        }

        private protected override void WriteToWriter(BinaryWriter writer) {
            writer.Write(EmoteId);
            writer.Write(AnchorType);
            if (AnchorType == byte.MaxValue) {
                return;
            }

            writer.Write(AnchorIndex);
            writer.Write(Lifetime);
            writer.Write(Emotion);
            if ((sbyte)Emotion < 0) {
                writer.Write(Metadata);
            }
        }
    }
}