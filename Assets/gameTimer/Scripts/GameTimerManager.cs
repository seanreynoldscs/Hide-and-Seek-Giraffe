using UnityEngine;
using UnityEngine.UI;

/// <summary>Manager for GameTimer accessible from inspector</summary>
/// <remarks>
/// Attach to game object in scene. 
/// This is a singleton so only one instance can be active at a time.
/// </remarks>
public class GameTimerManager : MonoBehaviour {

    public static GameTimerManager instance = null;  // Static instance for singleton

    public Text field; // Text field displaying current score

    void Awake() {
        // Ensure only one instance is running
        if (instance == null)
            instance = this; // Set instance to this object
        else
            Destroy(gameObject); // Kill yo self
        // Make sure the linked references didn't go missing
        if (field == null)
            Debug.LogError("Missing reference to 'field' on <b>GameTimerManager</b> component");
        Debug.Log("GameTimerManager running");
    }
    void Update(){
        GameTimer.Update();
    }

    /// <summary>Notify this manager of a change in score</summary>
    public void Updated () { 
        field.text = GameTimer.Time.ToString(@"mm\:ss"); // Post new score to text field
    }

 

}
