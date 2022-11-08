using System;
using Task2;

/*
    Задание 4.1. Очередь (ссылочные типы)
    Реализуйте очередь в виде списка, содержащую комплексные числа
    Реализуйте методы
    • void Enqueue(Complex с) – помещает комплексное число в конец очереди
    • Complex Dequeue( ) – получает комплексное число из начала очереди и удаляет его из
    очереди
    • Complex Peek( ) – возвращает комплексное число, находящееся в начале очереди (не
    удаляет его)
    • Свойство int Count доступное только для чтения, возвращающее кол-во элементов в
    очереди
    • void Print( ) - метод, распечатывающий содержимое очереди.
    где Complex – класс комплексных чисел, со свойствами Re и Im и переопределённым
    методом ToString()
    Примечание:
    • Не разрешается использовать классы из пространства имен System.Collections и его
    производных
 */
namespace Homework.Task3
{
    interface IQueue
    {
        int Count { get; }
        void Enqueue(Complex с);
        Complex Peek();
        Complex Dequeue();
        void Print();
    }

    public class Queue : IQueue

    {
        private sealed class Item
        {
            internal Complex complex;
            internal Item next;

            internal Item(Complex complex, Item next)
            {
                this.complex = complex;
                this.next = next;
            }
        }

        private Item tail;
        private int size;
        public int Count => size;

        public Queue()
        {
            tail = null;
            size = 0;
        }

        public Complex Dequeue()
        {
            if (tail == null)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            Complex r;
            if (size == 1)
            {
                r = tail.complex;
                tail = null;
                size--;
                return r;
            }
            var temp = tail;
            int c = 0;
            while (c++ < size - 2)
            {
                temp = temp.next;
            }
            r = temp.next.complex;
            temp.next = null;
            size--;
            return r;
        }

        public Complex Peek()
        {
            if (tail == null)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            var temp = tail;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            return temp.complex;
        }

        public void Enqueue(Complex c)
        {
            if (tail == null)
            {
                tail = new Item(c, null);
            }
            else
            {
                var temp = new Item(tail.complex, tail.next);
                tail = new Item(c, temp);
            }
            size++;
        }

        public void Print()
        {
            Console.Write("[");
            if (tail != null)
            {
                var temp = tail;
                while (true)
                {
                    Console.Write(temp.complex.ToString());
                    if(temp.next == null)
                    {
                        Console.WriteLine("]");
                        return;
                    }
                    else
                    {
                        temp = temp.next;
                        Console.Write(", ");
                    }
                }
            }
            Console.WriteLine("]");
        }
    }
}
