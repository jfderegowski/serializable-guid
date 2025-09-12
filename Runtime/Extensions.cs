using System;
using System.IO;

namespace fefek5.SerializableGuidVariable.Runtime
{
    public static class Extensions
    {
        public static SerializableGuid ToSerializableGuid(this Guid guid) => new(guid);

        public static Guid ToGuid(this SerializableGuid serializableGuid)
        {
            var bytes = new byte[16];
            
            Buffer.BlockCopy(BitConverter.GetBytes(serializableGuid.Part1), 0, bytes, 0, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(serializableGuid.Part2), 0, bytes, 4, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(serializableGuid.Part3), 0, bytes, 8, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(serializableGuid.Part4), 0, bytes, 12, 4);
            
            return new Guid(bytes);
        }
        
        public static SerializableGuid ReadBinary(this BinaryReader reader) =>
            new(reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32());
        
        public static void WriteBinary(this BinaryWriter writer, SerializableGuid guid)
        {
            writer.Write(guid.Part1);
            writer.Write(guid.Part2);
            writer.Write(guid.Part3);
            writer.Write(guid.Part4);
        }
    }
}