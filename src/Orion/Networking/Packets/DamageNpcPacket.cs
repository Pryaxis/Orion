﻿using System.IO;

namespace Orion.Networking.Packets {
    /// <summary>
    /// Packet sent to damage an NPC.
    /// </summary>
    public sealed class DamageNpcPacket : Packet {
        /// <summary>
        /// Gets or sets the NPC index.
        /// </summary>
        public short NpcIndex { get; set; }

        /// <summary>
        /// Gets or sets the damage.
        /// </summary>
        public short Damage { get; set; }

        /// <summary>
        /// Gets or sets the knockback.
        /// </summary>
        public float Knockback { get; set; }

        /// <summary>
        /// Gets or sets the hit direction.
        /// </summary>
        public int HitDirection { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the hit is critical.
        /// </summary>
        public bool IsCriticalHit { get; set; }

        private protected override void ReadFromReader(BinaryReader reader, ushort packetLength) {
            NpcIndex = reader.ReadInt16();
            Damage = reader.ReadInt16();
            Knockback = reader.ReadSingle();
            HitDirection = reader.ReadByte() - 1;
            IsCriticalHit = reader.ReadBoolean();
        }

        private protected override void WriteToWriter(BinaryWriter writer) {
            writer.Write(NpcIndex);
            writer.Write(Damage);
            writer.Write(Knockback);
            writer.Write((byte)(HitDirection + 1));
            writer.Write(IsCriticalHit);
        }
    }
}