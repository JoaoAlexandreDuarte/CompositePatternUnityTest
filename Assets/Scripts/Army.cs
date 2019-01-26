using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Army : MonoBehaviour, IUnit {
    //IUnit properties are readonly

    public List<IUnit> army = new List<IUnit>();

    // Returns the name of the army as "group of x" units
    public string UnitName => "Group of " + army.Count + " units";

    // Returns the median position of all the units
    public Vector2 Position {
        get {
            float x = 0;
            float y = 0;

            // Loops through all the units in the army to get the total sum
            // of positions of the units
            foreach (IUnit u in army) {
                x += u.Position.x;
                y += u.Position.y;
            }

            // Returns a vector with the centre of the positions of all 
            // units
            return new Vector2(x / army.Count, y / army.Count);
        }
    }

    // Returns the average Health, by taking all the unit's health and 
    // dividing by the total amout of units
    public float Health => army.Sum(unit => unit.Health) / army.Count;

    // Moves the army to the given position, and each unit with a relative
    // vector position equal to the starting one
    public void Move(Vector2 newPosition) {

        // Gets the new movement vector by subtracting the oldPos from the
        // newPos
        Vector2 movementVector = newPosition - Position;

        // Move a unity using the new movementVector
        foreach (IUnit unit in army) {
            unit.Move(unit.Position + movementVector);
        }
    }
}

