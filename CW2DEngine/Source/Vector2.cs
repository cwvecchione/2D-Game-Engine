using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW2DEngine.Source
{
    internal class Vector2
    {
        public float x { get; set; }
        public float y { get; set; }

        public Vector2()
        {
            x = Zero().x;
            y = Zero().y;
        }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2 Zero()
        {
            return new Vector2(0, 0);
        }

        public Vector2 Normalize()
        {
            if(x == 0 && y == 0) return this;

            float num = (float)Math.Sqrt(x * x + y * y);
            float num1 = 1f / num;

            return new Vector2(x * num1, y * num1);
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x - b.x, a.y - b.y);
        }

        public static Vector2 operator *(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x * b.x, a.y * b.y);
        }

        public static Vector2 operator /(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x / b.x, a.y / b.y);
        }

        public static implicit operator SFML.System.Vector2f(Vector2 v)
        {
            return new SFML.System.Vector2f(v.x, v.y);
        }

        public static implicit operator nkast.Aether.Physics2D.Common.Vector2(Vector2 v)
        {
            return new nkast.Aether.Physics2D.Common.Vector2(v.x, v.y);
        }

    }
}
