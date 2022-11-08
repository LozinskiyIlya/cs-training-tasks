using System;

/*
 *  Задание 5. Стек (generics)
    Реализуйте Стек (LIFO)
    Стек должен быть обобщенным типом (generic)
    Стек должен обладать стандартной функциональностью
    • void Push(T); - добавляет значение в стек (в вершину)
    • T Pop(); - возвращает значение из вершины стека и удаляет его из стека
    • T Top(); - возвращает значение из вершины стека, не удаляя его из стека
    • Свойство int Count; - возвращает количество значений в стеке
    В основном классе (Program) создайте обобщенный метод, создающий и заполняющий стек
    некоторым количеством объектов с какими-то значениями по умолчанию (например 1,2,3…)
    Создайте код для “тестирования” вашего стека
    Потребуйте от типа T, чтобы он реализовывал ICloneable, и реализуйте T Top() так, чтобы он
    возвращал копию объекта, а не сам объект
 */

namespace Homework.Task4
{
    interface IStack<T>
    {
        void Push(T t);
        T Pop();
        T Top();
        int Count { get; }

    }
    public class Stack<T> : IStack<T> where T : ICloneable
    {
        protected class Item
        {
            private T value;

            public Item prev;
            public T Value => value;

            public Item(Item prev, T value)
            {
                this.prev = prev;
                this.value = value;
            }
        }

        private Item head;
        private int size;
        public int Count => size;

        public Stack()
        {
            size = 0;
            head = null;
        }

        public void Push(T t)
        {
            Item temp = head;
            head = new Item(temp, t);
            size++;
        }

        public T Pop()
        {
            if (head is null)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            T res = head.Value;
            head = head.prev;
            size--;
            return res;
        }

        public T Top()
        {
            if (head is null)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return (T)head.Value.Clone();
        }

        public static void Fill<S>(Stack<S> stack, S[] arr) where S : ICloneable
        {
            for (int i = 0; i < arr.Length; i++)
            {
                stack.Push(arr[i]);
            }
        }

    }
}
