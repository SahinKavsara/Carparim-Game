using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class sonucManager : MonoBehaviour
{
    [SerializeField]
    private Image sonucImage;

    [SerializeField]
    private Text dogruText,yanlisText,puanText;

    [SerializeField]
    private GameObject tekrarOynaButon,anaMenuButon;

    float sureTimer;
    bool resimAcilsinMi;

    gameManager gameManager;

    private void Awake()
    {
        gameManager=Object.FindObjectOfType<gameManager>();
    }

    private void OnEnable()
    {
        sureTimer = 0;
        resimAcilsinMi = true;

        dogruText.text = "";
        yanlisText.text = "";
        puanText.text = "";

        tekrarOynaButon.GetComponent<RectTransform>().localScale = Vector3.zero;
        anaMenuButon.GetComponent<RectTransform>().localScale = Vector3.zero;
    
        StartCoroutine(ResimAcRoutine());
    }

    

    IEnumerator ResimAcRoutine()
    {
        while(resimAcilsinMi)
        {
            sureTimer+=0.30f;
            sonucImage.fillAmount = sureTimer;
            yield return new WaitForSeconds(0.1f);
            
            if (sureTimer >= 1)
            {
                sureTimer = 1;
                resimAcilsinMi =false;

                dogruText.text = gameManager.dogruAdet.ToString()+" DOÐRU";
                yanlisText.text = gameManager.yanlisAdet.ToString() + " YANLIÞ";
                puanText.text = gameManager.toplamPuan.ToString() + " PUAN";

                tekrarOynaButon.GetComponent<RectTransform>().DOScale(1, 0.3f);
                anaMenuButon.GetComponent<RectTransform>().DOScale(1, 0.3f);
            }
        }
    }


    public void TekrarOyna()
    {
        SceneManager.LoadScene("ikinciMenuLevel");
    }
    
    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene("MenuLevel");
    }

}
