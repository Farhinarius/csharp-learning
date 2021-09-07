using System;

namespace Workspace.Resources
{
    public struct Rectangle
    {
        private readonly ShapeInfo _rectInfo;

        private int _rectTop, _rectLeft, _rectBottom, _rectRight;

        public Rectangle(string shapeInfo, int top, int left, int bottom, int right)
        {
            _rectInfo = new ShapeInfo(shapeInfo);
            _rectTop = top;
            _rectLeft = left;
            _rectBottom = bottom;
            _rectRight = right;
        }

        public void Display()
        {
            Console.WriteLine("String = {0}, Top = {1}, Left = {2}, " +
                              "Bottom = {3}, Right = {4}", _rectInfo.Info, _rectTop, _rectLeft, _rectBottom,
                _rectRight);
        }
    }
}