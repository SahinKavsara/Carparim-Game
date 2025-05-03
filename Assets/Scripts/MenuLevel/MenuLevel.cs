using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuLevel : MonoBehaviour
{
    [SerializeField]
    private GameObject MenuPanel;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip buttonClik;

    [SerializeField]
    private GameObject sesPaneli;

    bool sesPaneliAcikMi;
    void Start()
    {
        sesPaneliAcikMi = false;

        sesPaneli.GetComponent<RectTransform>().localPosition = new Vector3(-14,-132,0);

        MenuPanel.GetComponent<CanvasGroup>().DOFade(1, 0.2f);
        MenuPanel.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);
    }

    public void ikinciLeveleGec() 
    {
        if(PlayerPrefs.GetInt("sesDurumu")==1)
        {
            audioSource.PlayOneShot(buttonClik);
            
        }


        SceneManager.LoadScene("ikinciMenuLevel");
    }
    
    public void ayarlariYap()
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(buttonClik);
            AudioSource audioSource1 = GetComponent<AudioSource>();
            audioSource.Play();
        }

        if (!sesPaneliAcikMi)
        {
            sesPaneli.GetComponent<RectTransform>().DOLocalMoveY(-320, 0.5f);
            sesPaneliAcikMi = true;
        }
        else
        {
            sesPaneli.GetComponent<RectTransform>().DOLocalMoveY(-146, 0.5f);
            sesPaneliAcikMi = false;
        }
    }
    public void oyundanCik()
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(buttonClik);
        }
        Application.Quit();
    }
}
