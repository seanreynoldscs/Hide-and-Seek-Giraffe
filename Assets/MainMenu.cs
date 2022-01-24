using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    public void PlayHideAndSeekGiraffeGame(){
        SceneManager.LoadScene("Game");//SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void ResetHighScore(){
        SumScore.ClearHighScore();
    }



}
