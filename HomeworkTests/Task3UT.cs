using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Homework.Task3;
using Task2;

namespace HomeworkTests
{
    [TestClass]
    public class Task3UT

    {
        // **************** //
        //  Initialization  //
        // **************** //

        [TestMethod("Init works")]
        public void InitWorks()
        {
            Queue a = new Queue();
            var b = a;
            Assert.AreEqual(a, b);
        }

        [TestMethod("Empty queue")]
        public void EmptyQueue()
        {
            Queue q = new Queue();
            Assert.AreEqual(0, q.Count);
            Assert.ThrowsException<InvalidOperationException>(() => q.Dequeue());
            Assert.ThrowsException<InvalidOperationException>(() => q.Peek());
        }


        // ********//
        // Enqueue //
        // ******* //

        [TestMethod("Enqueue works")]
        public void EnqueueWorks()
        {
            Queue q = new Queue();
            q.Enqueue(new Complex(0, 0));
            Assert.AreEqual(1, q.Count);

        }

        [TestMethod("Enqueue several items")]
        public void EnqueueSeveralItems()
        {
            var items = 10;
            Queue q = new Queue();
            Complex c = new Complex(0, 0);
            for (int i = 0; i < items; i++)
            {
                if (items % 2 == 0)
                {
                    q.Enqueue(Complex.Zero());
                }
                else
                {
                    q.Enqueue(c);
                }
            }
            Assert.AreEqual(items, q.Count);
        }


        // **********//
        //    Peek   //
        // ********* //

        [TestMethod("Can Peek after Enqueue")]
        public void CanPeekAfter()
        {
            Queue q = new Queue();
            Complex c = new Complex(0, 0);
            q.Enqueue(c);
            Assert.AreEqual(c, q.Peek());

        }

        [TestMethod("Peek does not change size")]
        public void SizeUnchanged()
        {
            Queue q = new Queue();
            Complex c = new Complex(0, 0);
            q.Enqueue(c);
            q.Peek();
            Assert.AreEqual(1, q.Count);
        }

        [TestMethod("Subsequent calls return same item")]
        public void SubsequentCalls()
        {
            Queue q = new Queue();
            Complex c = new Complex(0, 0);
            q.Enqueue(c);
            Assert.AreEqual(q.Peek(), q.Peek());
        }


        // ********//
        // Dequeue //
        // ******* //

        [TestMethod("Can Dequeue after Enqueue")]
        public void CanDequeueAfter()
        {
            Queue q = new Queue();
            Complex c = new Complex(0, 0);
            q.Enqueue(c);
            Assert.AreEqual(c, q.Dequeue());

        }

        [TestMethod("Dequeue changes size")]
        public void SizeChanged()
        {
            Queue q = new Queue();
            Complex c = new Complex(0, 0);
            q.Enqueue(c);
            q.Dequeue();
            Assert.AreEqual(0, q.Count);
        }

        [TestMethod("Subsequent calls return different items")]
        public void SubsequentCallsNotEqual()
        {
            Queue q = new Queue();
            q.Enqueue(new Complex(0, 0));
            q.Enqueue(new Complex(1, 1));
            Assert.AreNotEqual(q.Dequeue(), q.Dequeue());
        }

        [TestMethod("Can Dequeue in loop")]
        public void DequeueInLoop()
        {
            var items = 10;
            Queue q = new Queue();
            int i = 0;
            for (; i < items; i++)
            {
                q.Enqueue(new Complex(i, i * i));
            }
            Assert.AreEqual(items, q.Count);
            while (q.Count > 0)
            {
                q.Dequeue();
            }
            Assert.ThrowsException<InvalidOperationException>(() => q.Dequeue());
        }


        // ********//
        //  Print  //
        // ******* //

        [TestMethod("Prints empty queue")]
        public void PrintsEmptyQueue()
        {
            Queue q = new Queue();
            q.Print();
        }

        [TestMethod("Prints queue")]
        public void PrintsQueue()
        {
            var items = 10;
            Queue q = new Queue();
            for (int i = 0; i < items; i++)
            {
                q.Enqueue(new Complex(i, i * i));
            }
            q.Print();
        }
    }
}
