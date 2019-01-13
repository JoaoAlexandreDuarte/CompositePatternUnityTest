using System;
using UnityEngine;

public class Program {
    static void Main(string[] args) {

        //// Creates units
        //Unit knight = new Unit("Knight", new Vector2(15, 15), 100);
        //Unit archer = new Unit("Archer", new Vector2(10, 10), 70);
        //Unit mage = new Unit("Mage", new Vector2(5, 5), 50);

        //// Creates the army
        //Army army = new Army {
        //        knight,
        //        archer,
        //        mage
        //    };

        ////Creates new units and a new army
        //Unit peasant = new Unit("Peasant", new Vector2(-10, -10), 20);
        //Unit farmer = new Unit("Farmer", new Vector2(-5, -5), 30);
        //Army smallArmy = new Army {
        //        peasant,
        //        farmer
        //    };

        //// Check position for the group and for each unit
        //PrintUnitStats(army);
        //Console.WriteLine("--");
        //foreach (IUnit unit in army) {
        //    PrintUnitStats(unit);
        //}

        //Console.WriteLine("\n\n");
        //// Check position for the group and for each unit
        //PrintUnitStats(smallArmy);
        //Console.WriteLine("--");
        //foreach (IUnit unit in smallArmy) {
        //    PrintUnitStats(unit);
        //}

        //// Create a new army and put both armies in together with a new 
        //// unit
        //Army batallion = new Army {
        //        army,
        //        smallArmy,
        //        new Unit("Scout", new Vector2(0, 0), 10)
        //    };

        //Console.WriteLine("\n\n");
        //// Check position for the group and for each unit
        //PrintUnitStats(batallion);
        //Console.WriteLine("--");
        //foreach (IUnit unit in batallion) {
        //    PrintUnitStats(unit);
        //}

        //// Move the batallion
        //batallion.Move(new Vector2(100, 100));

        //Console.WriteLine("\n\n");
        //// Check position for the group and for each unit
        //PrintUnitStats(batallion);
        //Console.WriteLine("--");
        //foreach (IUnit unit in batallion) {
        //    PrintUnitStats(unit);
        //}

        //// Move a single army in the batallion
        //army.Move(new Vector2(0, 0));

        //Console.WriteLine("\n\n");
        //// Check position for the group and for each unit
        //PrintUnitStats(batallion);
        //Console.WriteLine("--");
        //foreach (IUnit unit in batallion) {
        //    PrintUnitStats(unit);
        //}
    }

    public static void PrintUnitStats(IUnit unit) {
        Console.WriteLine("Unit: " + unit.UnitName + ", Position: " +
            unit.Position + ", HP: " + unit.Health);
    }
}
