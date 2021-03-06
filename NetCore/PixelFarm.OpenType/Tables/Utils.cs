﻿//Apache2, 2014-2016, Samuel Carlsson, WinterDev

using System;
using System.Text;
using System.IO;
namespace NOpenType
{
    static class Utils
    {
        public static string TagToString(uint tag)
        {
            byte[] bytes = BitConverter.GetBytes(tag);
            Array.Reverse(bytes);
            return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }
        public static short[] ReadInt16Array(BinaryReader reader, int nRecords)
        {
            short[] arr = new short[nRecords];
            int i = 0;
            for (int n = nRecords - 1; n >= 0; --n)
            {
                arr[i++] = reader.ReadInt16();
            }

            return arr;
        }
        public static ushort[] ReadUInt16Array(BinaryReader reader, int nRecords)
        {
            ushort[] arr = new ushort[nRecords];
            int i = 0;
            for (int n = nRecords - 1; n >= 0; --n)
            {
                arr[i++] = reader.ReadUInt16();
            } 
            return arr;
        }

        public static T[] CloneArray<T>(T[] original, int newArrLenExtend = 0)
        {
            int orgLen = original.Length;
            T[] newClone = new T[orgLen + newArrLenExtend];
            Array.Copy(original, newClone, orgLen);
            return newClone;
        }
        public static T[] ConcatArray<T>(T[] arr1, T[] arr2)
        {
            T[] newArr = new T[arr1.Length + arr2.Length];
            Array.Copy(arr1, 0, newArr, 0, arr1.Length);
            Array.Copy(arr2, 0, newArr, arr1.Length, arr2.Length);
            return newArr;
        }
#if DEBUG
        public static bool dbugIsDiff(GlyphPointF[] set1, GlyphPointF[] set2)
        {
            int j = set1.Length;
            if (j != set2.Length)
            {
                //yes, diff
                return true;
            }
            for (int i = j - 1; i >= 0; --i)
            {
                if (!set1[i].IsEqualsWith(set2[i]))
                {
                    //yes, diff
                    return true;
                }
            }
            //no, both are the same
            return false;
        }
#endif

    }
}