using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResultManager : MonoBehaviour
{
    private int puanArtisi, toplamPuan;

    [SerializeField]
    private Text resultText;

    void Start()
    {
        //resultText.text = toplamPuan.ToString();
    }

   public void PuanArttir(string zorlukSeviyesi)
    {
        switch (zorlukSeviyesi)
        {
            case "kolay":
                puanArtisi = 5;
    
                break;
            
            case "orta":
                puanArtisi = 10;
     
                break;
            
            case "zor":
                puanArtisi = 20;
              
                break;
            
            
        }
        toplamPuan += puanArtisi;
        resultText.text = toplamPuan.ToString();
    }

}
