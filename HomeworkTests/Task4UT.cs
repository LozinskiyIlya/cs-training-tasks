using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Homework.Task4;

namespace HomeworkTests
{
    [TestClass]
    public class Task4UT

    {
        // **************** //
        //  Initialization  //
        // **************** //

        [TestMethod("Init works")]
        public void InitWorks()
        {
            Stack<string> a = new Stack<string>();
            var b = a;
            Assert.AreEqual(a, b);
        }

        [TestMethod("Empty stack")]
        public void EmptyStack()
        {
            Stack<string> s = new Stack<string>();
            Assert.AreEqual(0, s.Count);
            Assert.ThrowsException<InvalidOperationException>(() => s.Pop());
            Assert.ThrowsException<InvalidOperationException>(() => s.Top());
        }


        // ********* //
        //    Push   //
        // ********* //

        [TestMethod("Push works")]
        public void PushWorks()
        {
            Stack<string> s = new Stack<string>();
            s.Push("1");
            Assert.AreEqual(1, s.Count);

        }

        [TestMethod("Push several items")]
        public void PushSeveralItems()
        {
            var items = 10;
            Stack<string> s = new Stack<string>();
            for (int i = 0; i < items; i++)
            {
                s.Push(i.ToString());
            }
            Assert.AreEqual(items, s.Count);
        }


        // **********//
        //    Top    //
        // ********* //

        [TestMethod("Can Top after Push")]
        public void CanTopAfter()
        {
            Stack<string> s = new Stack<string>();
            s.Push("1");
            Assert.AreEqual("1", s.Top());

        }

        [TestMethod("Top does not change size")]
        public void SizeUnchanged()
        {
            Stack<string> s = new Stack<string>();
            s.Push("1");
            s.Top();
            Assert.AreEqual(1, s.Count);
        }

        [TestMethod("Subsequent calls return same item")]
        public void SubsequentCalls()
        {
            Stack<string> s = new Stack<string>();

            s.Push("1");
            Assert.AreEqual(s.Top(), s.Top());
        }

        class TestItem : ICloneable
        {
            public int field;

            public TestItem(int f)
            {
                field = f;
            }
            public object Clone()
            {
                return new TestItem(field);
            }
        }


        [TestMethod("Top returns clone")]
        public void TopReturnsClone()
        {
            var item = new TestItem(1);
            var stack = new Stack<TestItem>();
            stack.Push(item);
            var it = stack.Top();
            it.field = 3;
            Assert.AreEqual(1, stack.Top().field);
        }


        // **********//
        //    Pop    //
        // ********* //

        [TestMethod("Can Pop after Push")]
        public void CanPopAfter()
        {
            Stack<string> s = new Stack<string>();

            s.Push("1");
            Assert.AreEqual("1", s.Pop());
        }

        [TestMethod("Pop changes size")]
        public void SizeChanged()
        {
            Stack<string> s = new Stack<string>();

            s.Push("1");
            s.Pop();
            Assert.AreEqual(0, s.Count);
        }

        [TestMethod("Subsequent calls return different items")]
        public void SubsequentCallsNotEqual()
        {
            Stack<string> s = new Stack<string>();
            s.Push("1");
            s.Push("2");
            Assert.AreNotEqual(s.Pop(), s.Pop());
        }

        [TestMethod("Can Pop in loop")]
        public void PopInLoop()
        {
            var items = 10;
            Stack<string> s = new Stack<string>();
            int i = 0;
            for (; i < items; i++)
            {
                s.Push(i.ToString());
            }
            Assert.AreEqual(items, s.Count);
            while (s.Count > 0)
            {
                s.Pop();
            }
            Assert.ThrowsException<InvalidOperationException>(() => s.Pop());
        }


        // **********//
        //    Fill   //
        // ********* //


        [TestMethod("Fill works")]
        public void FillWorks()
        {
            Stack<string> s = new Stack<string>();
            Stack<string>.Fill(s, new string[] { "1", "2", "3" });
            Assert.AreEqual("3", s.Pop());
            Assert.AreEqual("2", s.Pop());
            Assert.AreEqual("1", s.Pop());
        }
    }
}
