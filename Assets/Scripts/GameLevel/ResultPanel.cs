using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResultPanel : MonoBehaviour
{
   
    public void RestartGame()
    {
        SceneManager.LoadScene("GameLevel");
       
    }
    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene("MenuLevel");
    }

}
