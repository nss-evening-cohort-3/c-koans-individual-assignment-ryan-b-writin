using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace DotNetKoans.CSharp
{
    public class AboutArrays : Koan
    {
        [Koan(1)]
        public void CreatingArrays()
        {
            var empty_array = new object[] { };
            Assert.Equal(typeof(FillMeIn), empty_array.GetType());

            //Note that you have to explicitly check for subclasses
            Assert.True(typeof(Array).IsAssignableFrom(empty_array.GetType()));

            Assert.Equal(FILL_ME_IN, empty_array.Length);
        }

        [Koan(2)]
        public void ArrayLiterals()
        {
            //You don't have to specify a type if the arguments can be inferred
            var array = new [] { 42 };
            Assert.Equal(typeof(int[]), array.GetType());
            Assert.Equal(new int[] { 42 }, array);

            //Are arrays 0-based or 1-based?
            Assert.Equal(42, array[((int)FILL_ME_IN)]);

            //This is important because...
            Assert.True(array.IsFixedSize);

            //...it means we can't do this: array[1] = 13;
            Assert.Throws(typeof(FillMeIn), delegate() { array[1] = 13; });

            //This is because the array is fixed at length 1. You could write a function
            //which created a new array bigger than the last, copied the elements over, and
            //returned the new array. Or you could do this:
            List<int> dynamicArray = new List<int>();
            dynamicArray.Add(42);
            Assert.Equal(array, dynamicArray.ToArray());

            dynamicArray.Add(13);
            Assert.Equal((new int[] { 42, (int)FILL_ME_IN}), dynamicArray.ToArray());
        }

        [Koan(3)]
        public void AccessingArrayElements()
        {
            var array = new[] { "peanut", "butter", "and", "jelly" };

            Assert.Equal(FILL_ME_IN, array[0]);
            Assert.Equal(FILL_ME_IN, array[3]);
            
            //This doesn't work: Assert.Equal(FILL_ME_IN, array[-1]);
        }

        [Koan(4)]
        public void SlicingArrays()
        {
            var array = new[] { "peanut", "butter", "and", "jelly" };

			Assert.Equal(new string[] { (string)FILL_ME_IN, (string)FILL_ME_IN }, array.Take(2).ToArray());
			Assert.Equal(new string[] { (string)FILL_ME_IN, (string)FILL_ME_IN }, array.Skip(1).Take(2).ToArray());
        }
    }
}
