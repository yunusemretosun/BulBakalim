using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AlphaPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject apanel;
    // Start is called before the first frame update
    void Start()
    {
        apanel.GetComponent<CanvasGroup>().DOFade(0, 3f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
