using System;
using Craft.Net.Server.Worlds;
using System.Linq;

namespace Craft.Net.Server.Packets
{
    public class LoginPacket : Packet
    {
        public int EntityId;
        public string LevelType;
        public GameMode GameMode;
        public Dimension Dimension;
        public Difficulty Difficulty;
        public byte MaxPlayers;

        public LoginPacket()
        {
        }

        public LoginPacket(int EntityId, string LevelType,
                           GameMode GameMode, Dimension Dimension,
                           Difficulty Difficulty, byte MaxPlayers)
        {
            this.EntityId = EntityId;
            this.LevelType = LevelType;
            this.GameMode = GameMode;
            this.Dimension = Dimension;
            this.Difficulty = Difficulty;
            this.MaxPlayers = MaxPlayers;
        }

        public override byte PacketID
        {
            get
            {
                return 0x1;
            }
        }

        public override int TryReadPacket(byte[] Buffer, int Length)
        {
            return 1;
        }

        public override void HandlePacket(MinecraftServer Server, ref MinecraftClient Client)
        {
            // TODO: Send world, etc
        }

        public override void SendPacket(MinecraftServer Server, MinecraftClient Client)
        {
            byte[] buffer = new byte[] { PacketID }
                .Concat(CreateInt(EntityId))
                .Concat(CreateString(LevelType))
                .Concat(new byte[]
                {
                    (byte)GameMode,
                    (byte)Dimension,
                    (byte)Difficulty,
                    0, MaxPlayers
                }).ToArray();
            Client.SendData(buffer);
        }
    }
}

