using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Simple Time manager. Requires GameTimerManager attached to game object in scene.
/// </summary>
public class GameTimer {

    private static double gameTime = 0;
    private static System.DateTime EndTime{ get;  set;}
    public static System.TimeSpan Time { get; protected set; }

    private static GameTimerManager mgr; // Easy reference to manager instance

    // Private constructor to ensure only one copy exists
    private GameTimer () { }
	
    /// <summary>Adds points to total Time</summary>
    /// <remarks>
    /// You can also use a negative number as a shortcut to the Subtract method
    /// </remarks>
    /// <param name="pointsToAdd">Number of points to add</param>
    public static void Start () {
        gameTime = 2.0;
        EndTime = System.DateTime.Now + System.TimeSpan.FromMinutes(gameTime);
        if (MgrSet()) {
            // Make sure we don't go negative unless we're supposed to
            mgr.Updated(); // Let the manager know we've changed the Time
        }
    }
   
    /// <summary>Sets Time to 0 and updates manager</summary>
    public static bool TimerDone () {
        if(EndTime < System.DateTime.Now){
            return true;
        }else{
            return false;
        }
    }
 
    /// <summary>Sets Time to 0 and updates manager</summary>
    public static void Update () {
        if(TimerDone()){
            if(gameTime > 0){
                SumScore.SaveHighScore();
                gameTime = 0;
                
                SceneManager.LoadScene("Menu");//SceneManager.GetActiveScene().buildIndex + 1);
            }
        }else{
            Time = EndTime - System.DateTime.Now;
            if (MgrSet()) {
                // Make sure we don't go negative unless we're supposed to
                mgr.Updated(); // Let the manager know we've changed the Time
            }
        }
        
    }
 
    /// <summary>Checks and sets references needed for the script</summary>
    /// <returns>True if successful, false if failed</returns>
    static bool MgrSet () {
        if (mgr == null) {
            mgr = GameTimerManager.instance; // Set instance reference
            if (mgr == null) {
                // Throw error message if we can't link
                Debug.LogError("<b>GameTimerManager.instance</b> cannot be found. Make sure object is active in inspector.");
                return false;
            }
        }
        return true;
    }


}
