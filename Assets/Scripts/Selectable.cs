using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Selectable : MonoBehaviour, ISelectHandler, IPointerClickHandler,
    IDeselectHandler {

    // All the selectables
    public static List<Selectable> allSelectables =
        new List<Selectable>();
    // The current selected ones
    public static List<Selectable> currentlySelected =
        new List<Selectable>();

    // Renderer
    private Renderer myRenderer;

    // Material to show it it's selected or not
    [SerializeField]
    private Material unselectedMaterial;
    [SerializeField]
    private Material selectedMaterial;

    // On awake adds the object to all the objects
    void Awake() {
        allSelectables.Add(this);
        myRenderer = GetComponent<Renderer>();
    }

    public void OnPointerClick(PointerEventData eventData) {
        // Selects the object it clicks
        OnSelect(eventData);
    }

    public void OnSelect(BaseEventData eventData) {

        if (!Input.GetKey(KeyCode.LeftControl) &&
            !Input.GetKey(KeyCode.RightControl)) {
            // Deselects all to start a new selection
            DeselectAll(eventData);
        }
        
        currentlySelected.Add(this);
        myRenderer.material = selectedMaterial;
    }

    public void OnDeselect(BaseEventData eventData) {
        myRenderer.material = unselectedMaterial;
    }

    public static void DeselectAll(BaseEventData eventData) {
        // Deselects all the currently selecteds
        foreach (Selectable s in currentlySelected) {
            s.OnDeselect(eventData);
        }
        currentlySelected.Clear();
    }
}
