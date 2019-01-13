using UnityEngine;

public interface IUnit {
    string UnitName { get; }
    Vector2 Position { get; }
    float Health { get; }

    void Move(Vector2 newPosition);
}
