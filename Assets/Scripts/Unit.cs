namespace CompositePattern {
    public class Unit : IUnit {
        public string UnitName { get; private set; }
        public Vector2 Position { get; private set; }
        public float Health { get; private set; }

        public Unit(string name, Vector2 position, float health) {
            UnitName = name;
            Position = position;
            Health = health;
        }

        public void Move(Vector2 newPosition) {
            Position = newPosition;
        }

        public override string ToString() {
            return $"{UnitName} at ({Position.X:f1}, {Position.Y:f1}) " +
                $"with {Health:f1} HP";
        }
    }
}
