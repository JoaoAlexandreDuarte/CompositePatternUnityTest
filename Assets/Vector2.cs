namespace CompositePattern {
    public class Vector2 {
        public float X { get; }
        public float Y { get; }

        public Vector2(float x, float y) {
            X = x;
            Y = y;
        }

        // Operator overloads

        // Sum
        public static Vector2 operator +(Vector2 v1, Vector2 v2) {
            return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
        }

        // Subtraction
        public static Vector2 operator -(Vector2 v1, Vector2 v2) {
            return new Vector2(v1.X - v2.X, v1.Y - v2.Y);
        }

        public override string ToString() {
            return "X: " + X + ", Y: " + Y;
        }
    }
}
