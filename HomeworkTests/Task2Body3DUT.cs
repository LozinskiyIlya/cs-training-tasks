using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using Homework.Task2;

namespace HomeworkTests
{
    [TestClass]
    public class Task2Body3DUT

    {
        // ************** //
        //  Polymorphism  //
        // ************** //
        [TestMethod("Can use descendants")]
        public void CanUseDescendants()
        {
            Body3D s = new Sphere(1);
            Body3D p = new Parallelepiped(1, 1, 1);
            Body3D t = new Tetrahedron(1);

            List<Body3D> bodies = new List<Body3D>()
            {
                new Parallelepiped(1,1,1),
                new Sphere(1),
                new Tetrahedron(1)
            };

            bodies.ForEach(b =>
            {
                b.Perimeter();
                b.SurfaceArea();
                b.Volume();
                Assert.AreEqual("Body3D", b.GetType().BaseType.Name);
                Assert.IsInstanceOfType(b, typeof(Body3D));
            });
        }

        // ***********//
        // Properties //
        // ********** //

        [TestMethod("Parallelepiped Props")]
        public void ParallelepipedProps()
        {
            var p = new Parallelepiped(1, 1, 1);
            Assert.AreEqual(1, p.Volume());
            Assert.AreEqual(6, p.SurfaceArea());
            Assert.AreEqual(12, p.Perimeter());

            p = new Parallelepiped(0, 0, 0);
            Assert.AreEqual(0, p.Volume());
            Assert.AreEqual(0, p.SurfaceArea());
            Assert.AreEqual(0, p.Perimeter());
        }

        [TestMethod("Sphere Props")]
        public void SphereProps()
        {
            var s = new Sphere(1);
            Assert.AreEqual((decimal)(Math.PI * Math.Pow(1, 3) * 4 / 3), s.Volume());
            Assert.AreEqual((decimal)(Math.PI * Math.Pow(1, 2) * 4), s.SurfaceArea());
            Assert.AreEqual(0, s.Perimeter());

            s = new Sphere(0);
            Assert.AreEqual(0, s.Volume());
            Assert.AreEqual(0, s.SurfaceArea());
            Assert.AreEqual(0, s.Perimeter());
        }
    }
}
