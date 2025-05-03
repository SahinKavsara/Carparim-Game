using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerManager : MonoBehaviour
{
    [SerializeField]
    private Text sureText;

    [SerializeField]
    private GameObject sonucPaneli;

    [SerializeField]
    private GameObject sonuclarObje,zamanObje,dogruYanlisObje,puanObje,playerObje;

    int kalanSure;
    bool sureSaysinMi;
    void Start()
    {
        kalanSure = 30;
        sureSaysinMi = true;

        sonucPaneli.SetActive(false);

        sonuclarObje.SetActive(true);
        zamanObje.SetActive(true);
        dogruYanlisObje.SetActive(true);
        puanObje.SetActive(true);
        playerObje.SetActive(true);

        StartCoroutine(SureTimerRoutine());
    }

    IEnumerator SureTimerRoutine()
    {
        while(sureSaysinMi)
        {
          yield return new WaitForSeconds(1f);

            if (kalanSure < 10)
            {
                sureText.text="0"+kalanSure.ToString();
            }
            else
            {
                sureText.text=kalanSure.ToString();
            }

            if (kalanSure <= 0)
            {
                sureSaysinMi = false;
                sureText.text= "0";
                EkraniTemizle();
                sonucPaneli.SetActive(true);
            }
            kalanSure--;
        }
    }

    private void EkraniTemizle()
    {
      
        sonuclarObje.SetActive(false);
        zamanObje.SetActive(false);
        dogruYanlisObje.SetActive(false);
        puanObje.SetActive(false);
        playerObje.SetActive(false);
    }

}
