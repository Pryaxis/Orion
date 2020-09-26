﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Orion.Core.Packets.Npcs
{
    public sealed class NpcStealCoinsTests
    {
        private readonly byte[] _bytes = { 19, 0, 92, 1, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 64, 0, 0, 0, 64 };

        [Fact]
        public void NpcIndex_Set_Get()
        {
            var packet = new NpcStealCoins();

            packet.NpcIndex = 1;

            Assert.Equal(1, packet.NpcIndex);
        }

        [Fact]
        public void Value_Set_Get()
        {
            var packet = new NpcStealCoins();

            packet.Value = 1;

            Assert.Equal(1, packet.Value);
        }

        [Fact]
        public void X_Set_Get()
        {
            var packet = new NpcStealCoins();

            packet.X = 1;

            Assert.Equal(1, packet.X);
        }

        [Fact]
        public void Y_Set_Get()
        {
            var packet = new NpcStealCoins();

            packet.Y = 1;

            Assert.Equal(1, packet.Y);
        }

        [Fact]
        public void Read()
        {
            var packet = TestUtils.ReadPacket<NpcStealCoins>(_bytes, PacketContext.Server);

            Assert.Equal(1, packet.NpcIndex);
            Assert.Equal(2, packet.Value);
            Assert.Equal(2, packet.X);
            Assert.Equal(2, packet.Y);
        }
    }
}