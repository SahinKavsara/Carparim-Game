using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class altMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject altMenuPanel;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip buttonClik;

    void Start()
    {
        if (altMenuPanel != null)
        {
            altMenuPanel.GetComponent<CanvasGroup>().DOFade(1, 1f);
        }
    }

    public void HangiOyunAcilsin(string hangiOyun)
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(buttonClik);
        }

        PlayerPrefs.SetString("hangiOyun",hangiOyun);
        SceneManager.LoadScene("GameLevel");
    }

    public void GeriDon()
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(buttonClik);
        }

        SceneManager.LoadScene("MenuLevel");
    }
}
