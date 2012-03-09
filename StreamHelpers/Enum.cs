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
//using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace Gibbed.IO
{
    public static partial class StreamHelpers
    {
        #region Cache
        private enum EnumUnderlyingType
        {
            Unknown,
            S8, U8,
            S16, U16,
            S32, U32,
            S64, U64,
        }

        private static class EnumTypeCache
        {
            /*private static Dictionary<Type, EnumUnderlyingType> _Lookup;

            static EnumTypeCache()
            {
                _Lookup = new Dictionary<Type, EnumUnderlyingType>();
            }*/

            private static EnumUnderlyingType TranslateType(Type type)
            {
                if (type.IsEnum == true)
                {
                    var underlyingType = Enum.GetUnderlyingType(type);

                    if (underlyingType == typeof(sbyte)) return EnumUnderlyingType.S8;
                    if (underlyingType == typeof(byte)) return EnumUnderlyingType.U8;
                    if (underlyingType == typeof(short)) return EnumUnderlyingType.S16;
                    if (underlyingType == typeof(ushort)) return EnumUnderlyingType.U16;
                    if (underlyingType == typeof(int)) return EnumUnderlyingType.S32;
                    if (underlyingType == typeof(uint)) return EnumUnderlyingType.U32;
                    if (underlyingType == typeof(long)) return EnumUnderlyingType.S64;
                    if (underlyingType == typeof(ulong)) return EnumUnderlyingType.U64;
                }
                
                return EnumUnderlyingType.Unknown;
            }

            public static EnumUnderlyingType Get(Type type)
            {
                /*if (Lookup.ContainsKey(type) == true)
                {
                    return Lookup[type];
                }*/

                return /*Lookup[type] =*/ TranslateType(type);
            }
        }
        #endregion
        #region ReadValueEnum
        public static T ReadValueEnum<T>(this Stream stream, Endian endian)
        {
            var type = typeof(T);

            object value;
            switch (EnumTypeCache.Get(type))
            {
                case EnumUnderlyingType.S8: value = stream.ReadValueS8(); break;
                case EnumUnderlyingType.U8: value = stream.ReadValueU8(); break;
                case EnumUnderlyingType.S16: value = stream.ReadValueS16(endian); break;
                case EnumUnderlyingType.U16: value = stream.ReadValueU16(endian); break;
                case EnumUnderlyingType.S32: value = stream.ReadValueS32(endian); break;
                case EnumUnderlyingType.U32: value = stream.ReadValueU32(endian); break;
                case EnumUnderlyingType.S64: value = stream.ReadValueS64(endian); break;
                case EnumUnderlyingType.U64: value = stream.ReadValueU64(endian); break;
                default: throw new NotSupportedException();
            }

            return (T)Enum.ToObject(type, value);
        }

        public static T ReadValueEnum<T>(this Stream stream)
        {
            return stream.ReadValueEnum<T>(Endian.Little);
        }
        #endregion
        #region WriteValueEnum
        public static void WriteValueEnum<T>(this Stream stream, object value, Endian endian)
        {
            var type = typeof(T);
            switch (EnumTypeCache.Get(type))
            {
                case EnumUnderlyingType.S8: stream.WriteValueS8((sbyte)value); break;
                case EnumUnderlyingType.U8: stream.WriteValueU8((byte)value); break;
                case EnumUnderlyingType.S16: stream.WriteValueS16((short)value, endian); break;
                case EnumUnderlyingType.U16: stream.WriteValueU16((ushort)value, endian); break;
                case EnumUnderlyingType.S32: stream.WriteValueS32((int)value, endian); break;
                case EnumUnderlyingType.U32: stream.WriteValueU32((uint)value, endian); break;
                case EnumUnderlyingType.S64: stream.WriteValueS64((long)value, endian); break;
                case EnumUnderlyingType.U64: stream.WriteValueU64((ulong)value, endian); break;
                default: throw new NotSupportedException();
            }
        }

        public static void WriteValueEnum<T>(this Stream stream, object value)
        {
            stream.WriteValueEnum<T>(value, Endian.Little);
        }
        #endregion
        #region Obsolete
        [Obsolete("use Endian enum instead of boolean to represent endianness")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static T ReadValueEnum<T>(this Stream stream, bool littleEndian)
        {
            return stream.ReadValueEnum<T>(littleEndian == true ? Endian.Little : Endian.Big);
        }

        [Obsolete("use Endian enum instead of boolean to represent endianness")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void WriteValueEnum<T>(this Stream stream, object value, bool littleEndian)
        {
            stream.WriteValueEnum<T>(value, littleEndian == true ? Endian.Little : Endian.Big);
        }
        #endregion
    }
}
