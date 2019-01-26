using UnityEngine;
using UnityEngine.EventSystems;

public class TestGame : MonoBehaviour {
    // Instance of the army
    [SerializeField]
    private GameObject armyPrefab;
    // All the selectables
    private Army allSelectables;
    // The current selected ones
    private Army currentlySelected;

    // Initializes variables
    void Awake() {
        // Instantiates 2 Armies
        GameObject newArmy = Instantiate(armyPrefab);
        newArmy.name = "All Selected";
        allSelectables = newArmy.GetComponent<Army>();

        newArmy = Instantiate(armyPrefab);
        newArmy.name = "Currently Selected";
        currentlySelected = newArmy.GetComponent<Army>();
    }

    // Adds an IUnit to allSelectables
    public void AddToAllSelected(GameObject unit) {
        // If the army doesn't already have the IUnit adds it
        if (!allSelectables.army.Contains(unit.GetComponent<IUnit>())) {
            allSelectables.army.Add(unit.GetComponent<IUnit>());
        }
    }

    // Adds an IUnit to currentlySelecteds
    public void AddToCurrentSelected(GameObject unit) {
        // Gets the IUnit component in the gameobject
        IUnit iUnit = unit.GetComponent<IUnit>();

        // Checks if the player is pressing Control key in order to add 
        // multiple IUnits
        if (!Input.GetKey(KeyCode.LeftControl) &&
                !Input.GetKey(KeyCode.RightControl)) {
            // Deselects all to start a new selection
            DeselectAll();
        }

        // If the army doesn't already have the IUnit adds it
        if (!currentlySelected.army.Contains(iUnit)) {
            currentlySelected.army.Add(iUnit);
            unit.GetComponent<SelectableIUnit>().OnSelect();
        }
    }

    // Moves IUnits
    public void MoveIUnits(BaseEventData eventData) {
        // Moves the selected units
        currentlySelected.Move(
            (eventData as PointerEventData).pointerCurrentRaycast.worldPosition);

        // Prints the stats -- UI Simulator --

        // If there's nothing to move
        if (currentlySelected.army.Count == 0) {
            Debug.Log("Tried to move to: " +
                (eventData as PointerEventData).pointerCurrentRaycast.worldPosition);
        } else if (currentlySelected.army.Count == 1) {
            // If there's only 1 unit to move
            Debug.Log("Moving-> " + GetUnitStats(currentlySelected.army[0]));
        } else {
            // If there's 2 or more to move
            Debug.Log("Moving-> " + GetUnitStats(currentlySelected));
        }
    }
    
    // Deselects all currently Selected units
    private void DeselectAll() {
        // Deselects all the currently selecteds
        foreach (Unit unit in currentlySelected.army) {
            unit.GetComponent<SelectableIUnit>().OnDeselect();
        }
        currentlySelected.army.Clear();
    }

    // Prints the unit stats
    private string GetUnitStats(IUnit unit) {
        return "Unit: " + unit.UnitName + ", Position: " +
            unit.Position + ", HP: " + unit.Health;
    }
}
