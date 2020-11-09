using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HpManager : MonoBehaviour
{
    [SerializeField]
    private GameObject hp3, hp2, hp1;

   

   public void KalanHitPoint(int kalanHp)
    {
        switch (kalanHp)
        {
            case 3:
                    hp3.SetActive(true);
                    hp2.SetActive(true);
                    hp1.SetActive(true);
                break;
            case 2:
                    hp3.SetActive(false);
                    hp2.SetActive(true);
                    hp1.SetActive(true);

                break;
            case 1:
                    hp3.SetActive(false);
                    hp2.SetActive(false);
                    hp1.SetActive(true);

                break;
            case 0:
                    hp3.SetActive(false);
                    hp2.SetActive(false);
                    hp1.SetActive(false);
                    

                break;

        }
    }
}
