﻿using System.IO;

namespace fefek5.SerializableGuid.Runtime
{
    public static class BinaryReaderExtensions
    {
        public static SerializableGuid Read(this BinaryReader reader) =>
            new(reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32());
    }
}
