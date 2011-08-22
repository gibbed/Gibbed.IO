/* Copyright (c) 2011 Rick (rick 'at' gibbed 'dot' us)
 * 
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would
 *    be appreciated but is not required.
 * 
 * 2. Altered source versions must be plainly marked as such, and must not
 *    be misrepresented as being the original software.
 * 
 * 3. This notice may not be removed or altered from any source
 *    distribution.
 */

using System;
using System.IO;

namespace Gibbed.IO
{
    public static partial class StreamHelpers
    {
        public static Guid ReadValueGuid(this Stream stream, bool littleEndian)
        {
            Int32 a = stream.ReadValueS32(littleEndian);
            Int16 b = stream.ReadValueS16(littleEndian);
            Int16 c = stream.ReadValueS16(littleEndian);
            byte[] d = new byte[8];
            stream.Read(d, 0, d.Length);
            return new Guid(a, b, c, d);
        }

        public static Guid ReadValueGuid(this Stream stream)
        {
            return stream.ReadValueGuid(true);
        }

        public static void WriteValueGuid(this Stream stream, Guid value, bool littleEndian)
        {
            byte[] data = value.ToByteArray();
            stream.WriteValueS32(BitConverter.ToInt32(data, 0), littleEndian);
            stream.WriteValueS16(BitConverter.ToInt16(data, 4), littleEndian);
            stream.WriteValueS16(BitConverter.ToInt16(data, 6), littleEndian);
            stream.Write(data, 8, 8);
        }

        public static void WriteValueGuid(this Stream stream, Guid value)
        {
            stream.WriteValueGuid(value, true);
        }
    }
}
