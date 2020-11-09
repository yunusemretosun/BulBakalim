using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class GameManger : MonoBehaviour
{
    [SerializeField]
    private GameObject karePrefab;
    
    [SerializeField]
    private GameObject sonucPanel;

    [SerializeField]
    private Transform karelerPaneli;

    [SerializeField]
    private Text sorularTxt;

    private GameObject[] karelerDizisi = new GameObject[25];

    [SerializeField]
    private Transform soruPaneli;

    [SerializeField]
    private Sprite[] kareSprites;
    List<int> valueList = new List<int>();

    [SerializeField]
    private AudioSource audioSource;

    public AudioClip butonSesi;
    public AudioClip dogruSesi;
    public AudioClip kaybetmeSesi;
    public AudioClip kazanmaSesi;

    int bolen, bolunen, kacinciSoru, butonDegeri;
    private int dogrusonuc;
    bool isClicked;
    int kalanhp;
    string sorununZorlukDerecesi;

    HpManager hp;
    ResultManager rm;
    GameObject gecerliKare;
    

    private void Awake()
    {
        sonucPanel.GetComponent<RectTransform>().localScale = Vector3.zero;
        kalanhp = 3;

        hp = Object.FindObjectOfType<HpManager>();
        hp.KalanHitPoint(kalanhp);
        rm = Object.FindObjectOfType<ResultManager>();

        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        isClicked = false;
        soruPaneli.GetComponent<RectTransform>().localScale = Vector3.zero;
        KareleriOlustur();
        Invoke("SoruPaneliAc",2f);
    }

    
    public void KareleriOlustur()
    {
        for (int i = 0; i < karelerDizisi.Length; i++)
        {
            GameObject kare = Instantiate(karePrefab, karelerPaneli);
            kare.transform.GetChild(1).GetComponent<UnityEngine.UI.Image>().sprite = kareSprites[Random.Range(0, kareSprites.Length)];
            kare.transform.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => ButtonClicked());
            karelerDizisi[i] = kare;
        }
        BolumDegerleriniGetir();
        StartCoroutine(DoFadeRoutine());
    }

    void ButtonClicked()
    {
        if (isClicked)
        {
            
            butonDegeri = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text);
            gecerliKare = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            if (CheckResult(butonDegeri))
            {

                gecerliKare.transform.GetChild(1).GetComponent<UnityEngine.UI.Image>().enabled = true;
                gecerliKare.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().enabled = false;
                gecerliKare.transform.GetComponent<UnityEngine.UI.Button>().interactable = false;
                rm.PuanArttir(sorununZorlukDerecesi);
                valueList.RemoveAt(kacinciSoru);
                if (valueList.Count != 0)
                {
                    audioSource.PlayOneShot(dogruSesi);
                    SoruPaneliAc();
                }
                else
                {
                    audioSource.PlayOneShot(kazanmaSesi);
                    OyunBitti();
                }

            }
            else
            {
                audioSource.PlayOneShot(butonSesi);
                kalanhp--;
                if (kalanhp > 0)
                {
                    
                    hp.KalanHitPoint(kalanhp);
                }
                else
                {
                    hp.KalanHitPoint(kalanhp);
                    isClicked = false;
                    audioSource.PlayOneShot(kaybetmeSesi);
                    OyunBitti();

                }
            }

        }

    }
    bool CheckResult(int btnval)
    {
        if (btnval == dogrusonuc)
            return true;
        else
            return false;    
    }
    IEnumerator DoFadeRoutine()
    {
        foreach (var kare  in karelerDizisi)
        {
            kare.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
            yield return new WaitForSeconds(0.07f);
        }
    }

    void BolumDegerleriniGetir()
    {
        foreach (var kare in karelerDizisi)
        {
            int randsayi = Random.Range(1, 13);
            kare.transform.GetChild(0).GetComponent<Text>().text = randsayi.ToString();
            valueList.Add(randsayi);
        }
    }

    void SoruPaneliAc()
    {  SoruyuSor();
        isClicked = true;
        soruPaneli.GetComponent<RectTransform>().DOScale(1,0.5f);
      
    }

    void SoruyuSor()
    {
        bolen = Random.Range(2, 11);
        kacinciSoru = Random.Range(0, valueList.Count);
        dogrusonuc = valueList[kacinciSoru];
        bolunen = bolen * dogrusonuc;
        
        if (bolunen <=30)
        {
            sorununZorlukDerecesi = "kolay";
        }
        else if(bolunen>30 && bolunen<=60 ){
            sorununZorlukDerecesi = "orta";
        }
        else
        {
            sorununZorlukDerecesi = "zor";
        }
            
        sorularTxt.text = bolunen.ToString() + ":" + bolen.ToString();
    }

    void OyunBitti()
    {
        sonucPanel.GetComponent<RectTransform>().DOScale(1, 0.5f);
    }
    
}
