﻿namespace Orion.Tests.Networking.Packets {
    using System;
    using System.IO;
    using System.Linq;
    using FluentAssertions;
    using Orion.Items;
    using Orion.Networking.Packets;
    using Xunit;

    public class UpdatePlayerInventorySlotPacketTests {
        // These canned bytes were taken from a real client.
        private static readonly byte[] Bytes = {0, 0, 1, 0, 59, 179, 13};

        [Fact]
        public void FromReader_NullReader_ThrowsArgumentNullException() {
            Func<UpdatePlayerInventorySlotPacket> func = () => UpdatePlayerInventorySlotPacket.FromReader(null);

            func.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void FromReader_IsCorrect() {
            using (var stream = new MemoryStream(Bytes))
            using (var reader = new BinaryReader(stream)) {
                var packet = UpdatePlayerInventorySlotPacket.FromReader(reader);

                packet.IsSentToClient.Should().BeTrue();
                packet.IsSentToServer.Should().BeTrue();
                packet.Type.Should().Be(TerrariaPacketType.UpdatePlayerInventorySlot);
                packet.PlayerId.Should().Be(0);
                packet.InventorySlot.Should().Be(0);
                packet.ItemStackSize.Should().Be(1);
                packet.ItemPrefix.Should().Be(ItemPrefix.Godly);
                packet.ItemType.Should().Be(expected: ItemType.CopperShortsword);
                stream.Position.Should().Be(Bytes.Length);
            }
        }

        [Fact]
        public void WriteToStream_IsCorrect() {
            using (var stream = new MemoryStream(Bytes))
            using (var reader = new BinaryReader(stream))
            using (var stream2 = new MemoryStream()) {
                var packet = UpdatePlayerInventorySlotPacket.FromReader(reader);

                packet.WriteToStream(stream2);

                stream2.ToArray().Skip(3).Should().BeEquivalentTo(Bytes);
            }
        }
    }
}
