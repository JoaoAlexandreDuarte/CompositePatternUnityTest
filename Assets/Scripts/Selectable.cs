using UnityEngine;
using UnityEngine.EventSystems;

public class Selectable : MonoBehaviour, ISelectHandler, IPointerClickHandler,
    IDeselectHandler {

    // All the selectables
    public static Army allSelectables = new Army();
    // The current selected ones
    [SerializeField]
    public static Army currentlySelected = new Army();

    // Renderer
    private Renderer myRenderer;

    // If it's a unit that moves or not
    private bool isUnit;

    // Material to show it it's selected or not
    [SerializeField]
    private Material unselectedMaterial;
    [SerializeField]
    private Material selectedMaterial;

    // On awake adds the object to all the objects
    void Awake() {
        // Checks if the object is a unit
        isUnit = GetComponentInParent<Unit>() != null;
        if (isUnit) {
            // If it's a unit sets it's values and adds it to the 
            // currentselected
            GetComponentInParent<Unit>().UnitName = name;
            GetComponentInParent<Unit>().Position = transform.position;
            GetComponentInParent<Unit>().Health = 100f;
            allSelectables.Add(GetComponentInParent<Unit>());
            myRenderer = GetComponent<Renderer>();
        }
    }

    public void OnPointerClick(PointerEventData eventData) {
        // Selects the object it clicks
        OnSelect(eventData);
    }

    public void OnSelect(BaseEventData eventData) {
        if (isUnit) {

            if (!Input.GetKey(KeyCode.LeftControl) &&
                !Input.GetKey(KeyCode.RightControl)) {
                // Deselects all to start a new selection
                DeselectAll(eventData);
            }

            // Print stats
            Debug.Log("Selecting-> " +
                GetUnitStats(GetComponentInParent<Unit>()));

            // Adds the selected unit to the Army
            currentlySelected.Add(GetComponentInParent<Unit>());
            myRenderer.material = selectedMaterial;
        } else {
            // Moves the selected units
            currentlySelected.Move(
                (eventData as PointerEventData).pointerCurrentRaycast.worldPosition);

            // Prints the stats

            // If there's nothing to move
            if (currentlySelected.Count == 0) {
                Debug.Log("Tried to move to: " +
                    (eventData as PointerEventData).pointerCurrentRaycast.worldPosition);
            } else if (currentlySelected.Count == 1) {
                // If there's only 1 unit to move
                Debug.Log("Moving-> " + GetUnitStats(currentlySelected[0]));
            } else {
                // If there's 2 or more to move
                Debug.Log("Moving-> " + GetUnitStats(currentlySelected));
            }

        }
    }

    // Deselects the given unit
    public void OnDeselect(BaseEventData eventData) {
        myRenderer.material = unselectedMaterial;
    }

    // Deselects all the units
    public static void DeselectAll(BaseEventData eventData) {
        // Deselects all the currently selecteds
        foreach (Unit unit in currentlySelected) {
            unit.GetComponentInParent<Selectable>().OnDeselect(eventData);
        }
        currentlySelected.Clear();
    }

    // Prints the unit stats
    private string GetUnitStats(IUnit unit) {
        return "Unit: " + unit.UnitName + ", Position: " +
            unit.Position + ", HP: " + unit.Health;
    }
}
