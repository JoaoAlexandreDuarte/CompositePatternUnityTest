using UnityEngine;
using UnityEngine.EventSystems;

public class SelectableIUnit : MonoBehaviour, IPointerClickHandler {

    // Class that runs the game
    private TestGame game;
    // Renderer
    private Renderer myRenderer;
    // Material to show it it's selected or not
    [SerializeField]
    private Material unselectedMaterial;
    [SerializeField]
    private Material selectedMaterial;

    // Initializes variables
    void Awake() {
        // Gets the test gameobject
        game = FindObjectOfType<TestGame>().GetComponent<TestGame>();
        // Sets the name, position and hp of the unit
        GetComponentInParent<Unit>().UnitName = name;
        GetComponentInParent<Unit>().Position = transform.position;
        GetComponentInParent<Unit>().Health = 100f;
        myRenderer = GetComponent<Renderer>();
        game.AddToAllSelected(this.gameObject);
    }

    // When the player clicks on an IUnit
    public void OnPointerClick(PointerEventData eventData) {
        // Adds the IUnit to the currentSelected
        game.AddToCurrentSelected(this.gameObject);
    }

    // When te IUnit is selected
    public void OnSelect() {
        // Sets the material to the selected material
        myRenderer.material = selectedMaterial;
    }

    // When the IUnit is deselected
    public void OnDeselect() {
        // Sets the material to the unselected material
        myRenderer.material = unselectedMaterial;
    }
}
