﻿using System.IO;

namespace Orion.Networking.Packets {
    /// <summary>
    /// Packet sent to show a tree growing effect.
    /// </summary>
    public sealed class ShowTreeEffectPacket : Packet {
        /// <summary>
        /// Gets or sets the tree's X coordinate.
        /// </summary>
        public short TreeX { get;set; }

        /// <summary>
        /// Gets or sets the tree's Y coordinate.
        /// </summary>
        public short TreeY { get;set; }

        /// <summary>
        /// Gets or sets the tree height.
        /// </summary>
        public byte TreeHeight { get; set; }

        /// <summary>
        /// Gets or sets the tree type.
        /// </summary>
        public short TreeType { get; set; }

        private protected override void ReadFromReader(BinaryReader reader, ushort packetLength) {
            reader.ReadByte();
            TreeX = reader.ReadInt16();
            TreeY = reader.ReadInt16();
            TreeHeight = reader.ReadByte();
            TreeType = reader.ReadInt16();
        }

        private protected override void WriteToWriter(BinaryWriter writer) {
            writer.Write((byte)1);
            writer.Write(TreeX);
            writer.Write(TreeY);
            writer.Write(TreeHeight);
            writer.Write(TreeType);
        }
    }
}