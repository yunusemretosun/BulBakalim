using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startbtn, exitbtn;   
    
    void Start()
    {
        FadeOut();
    }

     void FadeOut()
    {
        startbtn.GetComponent<CanvasGroup>().DOFade(1, 0.8f);
        exitbtn.GetComponent<CanvasGroup>().DOFade(1, 0.8f).SetDelay(0.5f);
    }

   
    public void Exit()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("GameLevel");    
    }
}
