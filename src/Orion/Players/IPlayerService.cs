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

using System;
using Microsoft.Xna.Framework;
using Orion.Events;
using Orion.Events.Players;
using Orion.Packets;
using Orion.Utils;

namespace Orion.Players {
    /// <summary>
    /// Represents a player service. Provides access to player-related events and methods, and in a thread-safe manner
    /// if not specified otherwise.
    /// </summary>
    public interface IPlayerService {
        /// <summary>
        /// Gets the players. All players are returned, regardless of whether or not they are actually active.
        /// </summary>
        /// <value>The players.</value>
        IReadOnlyArray<IPlayer> Players { get; }

        /// <summary>
        /// Gets the event handlers that occur when receiving a packet. This event can be canceled.
        /// </summary>
        /// <value>The event handlers that occur when receiving a packet.</value>
        EventHandlerCollection<PacketReceiveEvent> PacketReceive { get; }

        /// <summary>
        /// Gets the event handlers that occur when sending a packet. This event can be canceled.
        /// </summary>
        /// <value>The event handlers that occur when sending a packet.</value>
        EventHandlerCollection<PacketSendEvent> PacketSend { get; }

        /// <summary>
        /// Gets the event handlers that occur when a player connects. This event can be canceled.
        /// </summary>
        /// <value>The event handlers that occur when a player connects.</value>
        EventHandlerCollection<PlayerConnectEvent> PlayerConnect { get; }

        /// <summary>
        /// Gets the event handlers that occur when a player updates their player data: e.g., clothing colors, name,
        /// etc. This event can be canceled.
        /// </summary>
        /// <value>The event handlers that occur when a player updates their player data.</value>
        EventHandlerCollection<PlayerDataEvent> PlayerData { get; }

        /// <summary>
        /// Gets the event handlers that occur when a player updates an inventory slot. This event can be canceled.
        /// </summary>
        /// <value>The event handlers that occur when a player updates an inventory slot.</value>
        EventHandlerCollection<PlayerInventoryEvent> PlayerInventorySlot { get; }

        /// <summary>
        /// Gets the event handlers that occur when a player joins. This event can be canceled.
        /// </summary>
        /// <value>The event handlers that occur when a player joins.</value>
        EventHandlerCollection<PlayerJoinEvent> PlayerJoin { get; }

        /// <summary>
        /// Gets the event handlers that occur when a player spawns. This event can be canceled.
        /// </summary>
        /// <value>The event handlers that occur when a player spawns.</value>
        EventHandlerCollection<PlayerSpawnEvent> PlayerSpawn { get; }

        /// <summary>
        /// Gets the event handlers that occur when player updates their information. This event can be canceled.
        /// </summary>
        /// <value>The event handlers that occur when player updates their information.</value>
        /// <remarks>
        /// Player information is sent whenever a player's position or velocity changes or when commonly updated flags
        /// change, such as the player's control states.
        /// </remarks>
        EventHandlerCollection<PlayerInfoEvent> PlayerInfo { get; }

        /// <summary>
        /// Gets the event handlers that occur when a player updates their health. This event can be canceled.
        /// </summary>
        /// <value>The event handlers that occur when a player updates their health.</value>
        EventHandlerCollection<PlayerHealthEvent> PlayerHealth { get; }

        /// <summary>
        /// Gets the event handlers that occur when a player toggles PvP. This event can be canceled.
        /// </summary>
        /// <value>The event handlers that occur when a player toggles PvP.</value>
        EventHandlerCollection<PlayerPvpEvent> PlayerPvp { get; }

        /// <summary>
        /// Gets the event handlers that occur when a player triggers a heal effect. This event can be canceled.
        /// </summary>
        /// <value>The event handlers that occur when a player triggers a heal effect.</value>
        EventHandlerCollection<PlayerHealEffectEvent> PlayerHealEffect { get; }

        /// <summary>
        /// Gets the event handlers that occur when a player responds to a server password request. This event can be
        /// canceled.
        /// </summary>
        /// <value>The event handlers that occur when a player responds to a server password request.</value>
        EventHandlerCollection<PlayerPasswordEvent> PlayerPasswordResponse { get; }

        /// <summary>
        /// Gets the event handlers that occur when a player updates their mana. This event can be canceled.
        /// </summary>
        /// <value>The event handlers that occur when a player updates their mana.</value>
        EventHandlerCollection<PlayerManaEvent> PlayerMana { get; }

        /// <summary>
        /// Gets the event handlers that occur when a player triggers a mana effect. This event can be canceled.
        /// </summary>
        /// <value>The event handlers that occur when a player triggers a mana effect.</value>
        EventHandlerCollection<PlayerManaEffectEvent> PlayerManaEffect { get; }

        /// <summary>
        /// Gets the event handlers that occur when a player changes teams. This event can be canceled.
        /// </summary>
        /// <value>The event handlers that occur when a player changes teams.</value>
        EventHandlerCollection<PlayerTeamEvent> PlayerTeam { get; }

        /// <summary>
        /// Gets the event handlers that occur when a player sends their UUID. This event can be canceled.
        /// </summary>
        /// <value>The event handlers that occur when a player sends their UUID.</value>
        EventHandlerCollection<PlayerUuidEvent> PlayerUuid { get; }

        /// <summary>
        /// Gets the event handlers that occur when a player uses a teleportation potion. This event can be canceled.
        /// </summary>
        /// <value>The event handlers that occur when a player uses a teleportation potion.</value>
        EventHandlerCollection<PlayerTeleportEvent> PlayerTeleportEvent { get; }

        /// <summary>
        /// Gets the event handlers that occur when a player chats. This event can be canceled.
        /// </summary>
        /// <value>The event handlers that occur when a player chats.</value>
        EventHandlerCollection<PlayerChatEvent> PlayerChat { get; }

        /// <summary>
        /// Gets the event handlers that occur when a player has left.
        /// </summary>
        /// <value>The event handlers that occur when a player has left.</value>
        EventHandlerCollection<PlayerQuitEvent> PlayerQuit { get; }
    }

    /// <summary>
    /// Provides extensions for the <see cref="IPlayerService"/> interface.
    /// </summary>
    public static class PlayerServiceExtensions {
        /// <summary>
        /// Broadcasts a <paramref name="packet"/> to all active players.
        /// </summary>
        /// <param name="playerService">The player service.</param>
        /// <param name="packet">The packet.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="playerService"/> or <paramref name="packet"/> are <see langword="null"/>.
        /// </exception>
        public static void BroadcastPacket(this IPlayerService playerService, Packet packet) {
            if (playerService is null) {
                throw new ArgumentNullException(nameof(playerService));
            }

            if (packet is null) {
                throw new ArgumentNullException(nameof(packet));
            }

            var players = playerService.Players;
            for (var i = 0; i < players.Count; ++i) {
                players[i].SendPacket(packet);
            }
        }

        /// <summary>
        /// Broadcasts a <paramref name="message"/> to all active players with the given <paramref name="color"/>.
        /// </summary>
        /// <param name="playerService">The player service.</param>
        /// <param name="message">The message.</param>
        /// <param name="color">The color. The alpha component is ignored.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="playerService"/> or <paramref name="message"/> are <see langword="null"/>.
        /// </exception>
        public static void BroadcastMessage(this IPlayerService playerService, string message, Color color) {
            if (playerService is null) {
                throw new ArgumentNullException(nameof(playerService));
            }

            if (message is null) {
                throw new ArgumentNullException(nameof(message));
            }

            var players = playerService.Players;
            for (var i = 0; i < players.Count; ++i) {
                players[i].SendMessage(message, color);
            }
        }
    }
}
