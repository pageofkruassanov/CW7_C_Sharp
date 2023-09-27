using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW6_C_Sharp
{
    internal class Matrix2D<T> where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>
    {
        static int _seed;
        private T[,] _array;

        static Matrix2D()
        {
            _seed = 0;
        }
        public Matrix2D(T[,] array)
        {
            _array = array;
        }
        public Matrix2D(int column, int row)
        {
            _array = new T[column, row];
        }
        public void SetRandomNumbers(T min, T max)
        {
            Random rand = new Random(++_seed);

            for (int i = 0; i < _array.GetLength(0); i++)
            {
                for (int j = 0; j < _array.GetLength(1); j++)
                {
                    if (typeof(T) == typeof(int) || typeof(T) == typeof(double))
                    {
                        dynamic minValue = (dynamic)min;
                        dynamic maxValue = (dynamic)max;
                        dynamic randomValue = (typeof(T) == typeof(int)) ? rand.Next(minValue, maxValue) : minValue + (maxValue - minValue) * rand.NextDouble();
                        _array[i, j] = (T)randomValue;
                    }
                    else
                    {
                        throw new ArgumentException("Unsupported type T");
                    }
                }
            }
        }

        public T this[int firstIndex, int secondIndex]
        {
            get
            {
                if ((firstIndex >= 0 && firstIndex < _array.GetLength(0)) && (secondIndex >= 0 && secondIndex < _array.GetLength(1)))
                    return (T)Convert.ChangeType(_array[firstIndex, secondIndex], typeof(T));
                throw new ArgumentException("Error / Not correct index");
            }
            set
            {
                if ((firstIndex >= 0 && firstIndex < _array.GetLength(0)) && (secondIndex >= 0 && secondIndex < _array.GetLength(1)))
                {
                    _array[firstIndex, secondIndex] = (T)Convert.ChangeType(value, typeof(T));
                }
                else
                {
                    throw new ArgumentException("Error / Not correct index");
                }
            }
        }
        T[,] GetMatrix2D()
        {
            return _array;
        }
        public static Matrix2D<T> operator +(Matrix2D<T> a, Matrix2D<T> b)
        {
            if (a._array.GetLength(0) != b._array.GetLength(0))
                throw new ArgumentException("Error / Not correct index");
            else if (a._array.GetLength(1) != b._array.GetLength(1))
                throw new ArgumentException("Error / Not correct index");

            Matrix2D<T> newMatrix = new Matrix2D<T>(a._array.GetLength(0), a._array.GetLength(1));
            for (int i = 0; i < newMatrix.GetMatrix2D().GetLength(0); i++)
            {
                for (int j = 0; j < newMatrix.GetMatrix2D().GetLength(1); j++)
                {
                    newMatrix._array[i, j] = (dynamic)a._array[i, j] + b._array[i, j];
                }
            }
            return newMatrix;
        }

        public static bool operator ==(Matrix2D<T> a, Matrix2D<T> b)
        {
            T sumA = (dynamic)0, sumB = (dynamic)0;
            for (int i = 0; i < a._array.GetLength(0); i++)
            {
                for (int j = 0; j < a._array.GetLength(1); j++)
                {
                    sumA += (dynamic)a._array[i, j];
                }
            }
            for (int i = 0; i < b._array.GetLength(0); i++)
            {
                for (int j = 0; j < b._array.GetLength(1); j++)
                {
                    sumB += (dynamic)b._array[i, j];
                }
            }
            if ((dynamic)sumA == sumB)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(Matrix2D <T>a, Matrix2D<T> b)
        {
            int sumA = 0, sumB = 0;
            for (int i = 0; i < a._array.GetLength(0); i++)
            {
                for (int j = 0; j < a._array.GetLength(1); j++)
                {
                    sumA += (dynamic)a._array[i, j];
                }
            }
            for (int i = 0; i < b._array.GetLength(0); i++)
            {
                for (int j = 0; j < b._array.GetLength(1); j++)
                {
                    sumB += (dynamic)b._array[i, j];
                }
            }
            if (sumA != sumB)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator >(Matrix2D<T> a, Matrix2D<T> b)
        {
            int sumA = 0, sumB = 0;
            for (int i = 0; i < a._array.GetLength(0); i++)
            {
                for (int j = 0; j < a._array.GetLength(1); j++)
                {
                    sumA += (dynamic)a._array[i, j];
                }
            }
            for (int i = 0; i < b._array.GetLength(0); i++)
            {
                for (int j = 0; j < b._array.GetLength(1); j++)
                {
                    sumB += (dynamic)b._array[i, j];
                }
            }
            if (sumA > sumB)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator <(Matrix2D<T> a, Matrix2D<T> b)
        {
            int sumA = 0, sumB = 0;
            for (int i = 0; i < a._array.GetLength(0); i++)
            {
                for (int j = 0; j < a._array.GetLength(1); j++)
                {
                    sumA += (dynamic)a._array[i, j];
                }
            }
            for (int i = 0; i < b._array.GetLength(0); i++)
            {
                for (int j = 0; j < b._array.GetLength(1); j++)
                {
                    sumB += (dynamic)b._array[i, j];
                }
            }
            if (sumA < sumB)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < _array.GetLength(0); i++)
            {
                for (int j = 0; j < _array.GetLength(1); j++)
                {
                    sb.Append(this[i, j]);
                    if (j < _array.GetLength(0) - 1)
                        sb.Append(' ');
                }
                sb.Append('\n');
            }
            return $"Array: {sb.ToString()}";
        }
    }
}
