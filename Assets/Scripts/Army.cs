using System.Collections.Generic;
using System.Linq;

namespace CompositePattern {
    public class Army : List<IUnit>, IUnit {
        //IUnit properties are readonly

        // Returns the name of the army as "group of x" units
        public string UnitName => "Group of " + this.Count + " units";

        // Returns the median position of all the units
        public Vector2 Position {
            get {
                float x = 0;
                float y = 0;

                // Loops through all the units in the army to get the total sum
                // of positions of the units
                foreach (IUnit u in this) {
                    x += u.Position.X;
                    y += u.Position.Y;
                }

                // Returns a vector with the centre of the positions of all 
                // units
                return new Vector2(x / this.Count, y / this.Count);
            }
        }

        // Returns the average Health, by taking all the unit's health and 
        // dividing by the total amout of units
        public float Health => this.Sum(unit => unit.Health) / this.Count;

        // Constructor to call the base class (List<IUnit>)
        public Army() : base() {

        }

        // Moves the army to the given position, and each unit with a relative
        // vector position equal to the starting one
        public void Move(Vector2 newPosition) {

            // Gets the new movement vector by subtracting the oldPos from the
            // newPos
            Vector2 movementVector = newPosition - Position;

            // Move a unity using the new movementVector
            foreach (IUnit unit in this) {
                unit.Move(unit.Position + movementVector);
            }
        }
    }
}
