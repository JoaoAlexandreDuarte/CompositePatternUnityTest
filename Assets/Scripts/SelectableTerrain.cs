using UnityEngine;
using UnityEngine.EventSystems;

public class SelectableTerrain : MonoBehaviour, IPointerClickHandler {
    // Class that runs the game
    private TestGame game;

    //Initializes variables
    void Awake() {
        game = FindObjectOfType<TestGame>().GetComponent<TestGame>();
    }

    // When the player clicks on terrain
    public void OnPointerClick(PointerEventData eventData) {
        // Selects the object it clicks
        game.MoveIUnits(eventData);
    }
}
