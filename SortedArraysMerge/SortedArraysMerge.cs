// Two preprocessor options- ARRAY and LIST to be used inside the merging fucntion
#define ARRAY

using System;
using System.Diagnostics;
using System.Collections.Generic;

// Just checking some algorithm to merge 2 sorted arrays
namespace SortedArraysMerge
{
    internal class SortedArraysMerge
    {
        static void Main(string[] args)
        {
            int[] a1 = { 0, 10, 20, 23, 40, 50, 120 };
            int[] a2 = { 6, 7, 100 };

            Debug.WriteLine($"\n1st array: ");
            for (int i = 0; i < a1.Length; i++)
            {
                Debug.Write(a1[i] + " ");
            }

            Debug.WriteLine($"\n\n2nd array: ");
            for (int i = 0; i < a2.Length; i++)
            {
                Debug.Write(a2[i] + " ");
            }

            int[] a3 = MergeArrays(a1, a2);

            Debug.WriteLine($"\nMerged array: ");
            for (int i = 0; i < a3.Length; i++)
            {
                Debug.Write(a3[i] + " ");
            }
            Debug.WriteLine($"\n");
        }

        static int[] MergeArrays(int[] array1, int[] array2)
        {
            // Array to contain 2 merged arrays
#if ARRAY
            int[] mergedArr = new int[array1.Length + array2.Length];
            int mPtr = 0;
#endif
            int a1Ptr = 0;
            int a2Ptr = 0;

#if LIST
            List<int> merged = new List<int>();
#endif
            while ((a1Ptr < array1.Length) || (a2Ptr < array2.Length))
            {
                // If we reached the end of the 1st array, add an element from the 2nd
                if (a1Ptr == array1.Length)
                {
#if ARRAY
                    mergedArr[mPtr]= array2[a2Ptr];
                    mPtr++;
#elif LIST
                    merged.Add(array2[a2Ptr]);
#endif
                    a2Ptr++;
                }

                // If we reached the end of the 2nd array, add an elemnt from the 1st
                else if (a2Ptr == array2.Length)
                {
#if ARRAY
                    mergedArr[mPtr] = array1[a1Ptr];
                    mPtr++;
#elif LIST
                    merged.Add(array1[a1Ptr]);
#endif
                    a1Ptr++;
                }
                else if (array1[a1Ptr] < array2[a2Ptr])
                {
#if ARRAY
                    mergedArr[mPtr] = array1[a1Ptr];
                    mPtr++;
#elif LIST
                    merged.Add(array1[a1Ptr]);
#endif
                    a1Ptr++;
                }
                else
                {
#if ARRAY
                    mergedArr[mPtr] = array2[a2Ptr];
                    mPtr++;
#elif LIST
                    merged.Add(array2[a2Ptr]);
#endif
                    a2Ptr++;
                }
            }
#if ARRAY
            return mergedArr;
#elif LIST
            return merged.ToArray();
#endif
        }
    }
}
