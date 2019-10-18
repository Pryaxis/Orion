﻿// Copyright (c) 2019 Pryaxis & Orion Contributors
// 
// This file is part of Orion.
// 
// Orion is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// Orion is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with Orion.  If not, see <https://www.gnu.org/licenses/>.

using System.IO;
using FluentAssertions;
using Xunit;

namespace Orion.Packets.Npcs {
    public class NpcDamagePacketTests {
        [Fact]
        public void SimpleProperties_Set_MarkAsDirty() {
            var packet = new NpcDamagePacket();

            packet.SimpleProperties_Set_MarkAsDirty();
        }

        public static readonly byte[] Bytes = { 13, 0, 28, 100, 0, 108, 0, 205, 204, 128, 64, 2, 0 };

        [Fact]
        public void ReadFromStream() {
            using var stream = new MemoryStream(Bytes);
            var packet = (NpcDamagePacket)Packet.ReadFromStream(stream, PacketContext.Server);

            packet.NpcIndex.Should().Be(100);
            packet.Damage.Should().Be(108);
            packet.Knockback.Should().Be(4.025f);
            packet.HitDirection.Should().Be(1);
            packet.IsCriticalHit.Should().BeFalse();
        }

        [Fact]
        public void DeserializeAndSerialize_SamePacket() => Bytes.ShouldDeserializeAndSerializeSamePacket();
    }
}
