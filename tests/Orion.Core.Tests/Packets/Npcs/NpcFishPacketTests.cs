﻿// Copyright (c) 2020 Pryaxis & Orion Contributors
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

using System;
using System.Diagnostics.CodeAnalysis;
using Orion.Core.Npcs;
using Xunit;

namespace Orion.Core.Packets.Npcs {
    [SuppressMessage("Style", "IDE0017:Simplify object initialization", Justification = "Testing")]
    public class NpcFishPacketTests {
        public static readonly byte[] Bytes = { 9, 0, 130, 100, 0, 0, 1, 108, 2 };

        [Fact]
        public void X_Set_Get() {
            var packet = new NpcFishPacket();

            packet.X = 100;

            Assert.Equal(100, packet.X);
        }

        [Fact]
        public void Y_Set_Get() {
            var packet = new NpcFishPacket();

            packet.Y = 256;

            Assert.Equal(256, packet.Y);
        }

        [Fact]
        public void Id_Set_Get() {
            var packet = new NpcFishPacket();

            packet.Id = NpcId.HemogoblinShark;

            Assert.Equal(NpcId.HemogoblinShark, packet.Id);
        }

        [Fact]
        public void Read() {
            var packet = new NpcFishPacket();
            var span = Bytes.AsSpan(IPacket.HeaderSize..);
            Assert.Equal(span.Length, packet.Read(span, PacketContext.Server));

            Assert.Equal(100, packet.X);
            Assert.Equal(256, packet.Y);
            Assert.Equal(NpcId.HemogoblinShark, packet.Id);
        }

        [Fact]
        public void RoundTrip() {
            TestUtils.RoundTripPacket<NpcFishPacket>(Bytes.AsSpan(IPacket.HeaderSize..), PacketContext.Server);
        }
    }
}