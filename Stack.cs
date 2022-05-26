using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev23
{
   public class Stack<T> : IEnumerable<T>
    {
        private T[] data;
        private int size;

        public Stack(int size)
        {
            data = new T[size];
        }

        public Stack() :this(1000)
        {
        }

        public void Push(T item)
        {
            if (size == data.Length)
            {
                throw new InvalidOperationException("Stack'ta daha fazla yer yok");
            }
            data[size++] = item;
        }

        public T Pop()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("Stack boş"); 
            }
            return data[--size];
        }

        public T Peak()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("Stackte veri kalmadı");
            }
            return data[size - 1];
        }

        public int Size()
        {
            return size;
        }

        public IEnumerable<T> Get()
        {
            for (int i = size - 1; i>=0; i--)
            {
                yield return data[i];
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
