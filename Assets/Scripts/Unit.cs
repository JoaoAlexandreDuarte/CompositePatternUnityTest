using UnityEngine;

public class Unit : MonoBehaviour, IUnit {
    public string UnitName { get; set; }
    public Vector2 Position { get; set; }
    public float Health { get; set; }

    public void Move(Vector2 newPosition) {
        transform.position = newPosition;
    }

    public override string ToString() {
        return $"{UnitName} at ({Position.x:f1}, {Position.y:f1}) " +
            $"with {Health:f1} HP";
    }
}
