﻿namespace Orion.Networking.Packets {
    /// <summary>
    /// Indicates the type of a <see cref="Packet"/>.
    /// </summary>
    public enum PacketType : byte {
#pragma warning disable 1591
        Connect = 1,
        Disconnect = 2,
        ContinueConnection = 3,
        UpdatePlayerInfo = 4,
        UpdatePlayerInventorySlot = 5,
        FinishConnection = 6,
        UpdateWorldInfo = 7,
        RequestWorldSection = 8,
        UpdateClientStatus = 9,
        UpdateWorldSection = 10,
        SyncTileFrames = 11,
        SpawnPlayer = 12,
        UpdatePlayer = 13,
        UpdatePlayerStatus = 14,
        UpdatePlayerHp = 16,
        ModifyTile = 17,
        UpdateTime = 18,
        ToggleDoor = 19,
        UpdateSquareOfTiles = 20,
        UpdateItem = 21,
        UpdateItemOwner = 22,
        UpdateNpc = 23,
        DamageNpcWithSelectedItem = 24,
        UpdateProjectile = 27,
        DamageNpc = 28,
        RemoveProjectile = 29,
        UpdatePlayerPvpStatus = 30,
        RequestChestContents = 31,
        UpdateChestContentsSlot = 32,
        UpdatePlayerChest = 33,
        ModifyChest = 34,
        ShowHealEffect = 35,
        UpdatePlayerZones = 36,
        RequestServerPassword = 37,
        ContinueConnectionWithServerPassword = 38,
        RemoveItemOwner = 39,
        UpdatePlayerTalkingToNpc = 40,
        UpdatePlayerItemAnimation = 41,
        UpdatePlayerMp = 42,
        ShowManaEffect = 43,
        UpdatePlayerTeam = 45,
        RequestSign = 46,
        UpdateSign = 47,
        UpdateLiquid = 48,
        FirstSpawnPlayer = 49,
        UpdatePlayerBuffs = 50,
        PerformAction = 51,
        UnlockTile = 52,
        AddNpcBuff = 53,
        UpdateNpcBuffs = 54,
        AddPlayerBuff = 55,
        UpdateNpcName = 56,
        UpdateBiomeStats = 57,
        PlayHarpNote = 58,
        ActivateWiring = 59,
        UpdateNpcHome = 60,
        SummonBossOrInvasion = 61,
        ShowPlayerDodge = 62,
        PaintBlock = 63,
        PaintWall = 64,
        TeleportEntity = 65,
        HealOtherPlayer = 66,
        UpdateUuid = 68,
        RequestOrUpdateChestName = 69,
        CatchNpc = 70,
        ReleaseNpc = 71,
        UpdateTravelingMerchantInventory = 72,
        PerformTeleportationPotion = 73,
        UpdateAnglerQuest = 74,
        CompleteAnglerQuest = 75,
        UpdateAnglerQuestsCompleted = 76,
        CreateTemporaryAnimation = 77,
        UpdateInvasion = 78,
        PlaceObject = 79,
        UpdateOtherPlayerChest = 80,
        CreateCombatText = 81,
        NetManager = 82,
        UpdateNpcKills = 83,
        UpdatePlayerStealth = 84,
        MoveItemIntoChest = 85,
        UpdateTileEntity = 86,
        PlaceTileEntity = 87,
        AlterItem = 88,
        PlaceItemFrame = 89,
        UpdateInstancedItem = 90,
        UpdateEmoteBubble = 91,
        IncrementNpcCoins = 92,
        RemovePortal = 95,
        TeleportPlayerThroughPortal = 96,
        NotifyNpcKill = 97,
        NotifyEventProgression = 98,
        UpdatePlayerMinionTarget = 99,
        TeleportNpcThroughPortal = 100,
        UpdatePillarShields = 101,
        LevelUpNebulaArmor = 102,
        UpdateMoonLordCountdown = 103,
        UpdateNpcShopSlot = 104,
        ToggleGemLock = 105,
        ShowPoofOfSmoke = 106,
        ShowChat = 107,
        ShootFromCannon = 108,
        RequestMassWireOperation = 109,
        ConsumeWires = 110,
        ToggleBirthdayParty = 111,
        ShowTreeEffect = 112,
        StartOldOnesArmyInvasion = 113,
        EndOldOnesArmyInvasion = 114,
        UpdatePlayerMinionTargetNpc = 115,
        UpdateOldOnesArmyInvasion = 116,
        HurtPlayer = 117,
        KillPlayer = 118,
        ShowCombatText = 119,
#pragma warning restore 1591
    }
}
