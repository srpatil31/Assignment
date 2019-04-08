using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrawingTool.UnitTests
{
    [TestClass]
    public class CanvasTest
    {
        [TestMethod]
        public void TestCreateCanvas()
        {
            Canvas canvas = new Canvas(20, 4);
            canvas.Create();
            Assert.AreEqual(canvas.Render(),
            "......................\n" +
            ".                    .\n" +
            ".                    .\n" +
            ".                    .\n" +
            ".                    .\n" +
            "......................");
        }

        [TestMethod]
        public void TestDrawLine()
        {
            Canvas canvas = new Canvas(3, 5);
            canvas.Create();
            canvas.Draw(new Coordinates(1, 2, 4, 2), 'x','L');
            Assert.AreEqual(canvas.Render(),
                ".....\n" +
                ". x .\n" +
                ". x .\n" +
                ". x .\n" +
                ". x .\n" +
                ".   .\n" +
                ".....");
        }

        [TestMethod]
        public void TestDrawRectangle()
        {
            Canvas canvas = new Canvas(8, 4);
            canvas.Create();
            canvas.Draw(new Coordinates(2, 1, 6, 3), 'x','R');
            Assert.AreEqual(canvas.Render(),
                "..........\n" +
                ". xxxxx  .\n" +
                ". x   x  .\n" +
                ". xxxxx  .\n" +
                ".        .\n" +
                "..........");
        }

        [TestMethod]
        public void TestBucketFill()
        {
            Canvas canvas = new Canvas(8, 4);
            canvas.Create();
            canvas.Draw(new Coordinates(2, 1, 6, 3), 'x', 'R');
            canvas.BucketFill(3, 2, 'C');
            Assert.AreEqual(canvas.Render(),
        "..........\n" +
                ". xxxxx  .\n" +
                ". xCCCx  .\n" +
                ". xxxxx  .\n" +
                ".        .\n" +
                "..........");
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestCanvasDrawFailure()
        {
            Canvas canvas = new Canvas(8, 4);
            canvas.Draw(new Coordinates(2, 1, 9, 10), 'x', 'R');

        }

        [TestMethod]
        [ExpectedException(typeof(CanvasException))]
        public void TestCanvasFailure()
        {
            Canvas canvas = new Canvas();
            canvas.Draw(new Coordinates(2, 1, 9, 10), 'x', 'R');

        }
    }
}
