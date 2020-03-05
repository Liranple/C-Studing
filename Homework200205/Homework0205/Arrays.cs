using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework0205
{
    class Arrays
    {
        public void Sort<T>(T[] array, bool select = true) where T : IComparable
        {
            T n;
            T m;
            switch (select)
            {
                case true:
                    for (int i = 0; i < array.Length; i++)
                    {
                        for (int j = i; j < array.Length; j++)
                        {
                            n = array[i];
                            m = array[j];
                            if (array[i].CompareTo(array[j]) > 0)
                            {
                                array[i] = array[j];
                                array[j] = n;
                            }
                        }
                    }
                    break;
                case false:
                    for (int i = 0; i < array.Length; i++)
                    {
                        for (int j = i; j < array.Length; j++)
                        {
                            n = array[i];
                            m = array[j];
                            if (array[i].CompareTo(array[j]) < 0)
                            {
                                array[i] = array[j];
                                array[j] = n;
                            }
                        }
                    }
                    break;
            }
        }
    }
}
