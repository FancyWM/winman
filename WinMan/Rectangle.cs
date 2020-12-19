using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMan
{
    public struct Rectangle : IEquatable<Rectangle>
    {
        public int Left { get; }
        public int Top { get; }
        public int Right { get; }
        public int Bottom { get; }
        public int Width => Right - Left;
        public int Height => Bottom - Top;

        public Point TopLeft => new Point(Left, Top);
        public Point BottomRight => new Point(Right, Bottom);
        public Point TopRight => new Point(Right, Top);
        public Point BottomLeft => new Point(Left, Bottom);
        public Point Size => new Point(Width, Height);

        public static Rectangle OffsetAndSize(int left, int top, int width, int height)
        {
            return new Rectangle(left, top, left + width, top + height);
        }

        public Rectangle(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        public bool Contains(Point pt)
        {
            return Left <= pt.X
                && pt.X <= Right
                && Top <= pt.Y
                && pt.Y <= Bottom;
        }

        public bool Equals(Rectangle other)
        {
            return Left == other.Left
                && Top == other.Top
                && Right == other.Right
                && Bottom == other.Bottom;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public static bool operator ==(Rectangle lhs, Rectangle rhs)
        {
            return lhs.Equals(rhs);
        }
        public static bool operator !=(Rectangle lhs, Rectangle rhs)
        {
            return !lhs.Equals(rhs);
        }

        public override int GetHashCode()
        {
            int hashCode = -1819631549;
            hashCode = hashCode * -1521134295 + Left.GetHashCode();
            hashCode = hashCode * -1521134295 + Top.GetHashCode();
            hashCode = hashCode * -1521134295 + Right.GetHashCode();
            hashCode = hashCode * -1521134295 + Bottom.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"(L={Left}, T={Top}, R={Right}, B={Bottom}, W={Width}, H={Height})";
        }
    }
}
