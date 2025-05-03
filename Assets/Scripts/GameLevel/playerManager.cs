using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class playerManager : MonoBehaviour
{
    [SerializeField]
    private Transform gun;

    [SerializeField]
    private GameObject[] mermiPrefab;

    [SerializeField]
    private Transform mermiYeri;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip topClik;

    float ikiMermiArasiSure=200f;
    float sonrakiAtisSuresi;

    public bool rotaDegissinMi;

    private void Start()
    {
        rotaDegissinMi = false;
    }
   


    float aci; float donusHizi=5f;
    void RotateDegistir()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gun.transform.position;
        aci = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        if(aci<53 && aci>-53)
        {
            Quaternion rotation = Quaternion.AngleAxis(aci, Vector3.forward);
            gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, rotation, donusHizi * Time.deltaTime);
        }

       

        

        if (Input.GetMouseButtonDown(0))
        {
           
            if (Time.time > sonrakiAtisSuresi)
            {
                sonrakiAtisSuresi= Time.time+ikiMermiArasiSure/1000;
                MermiAt();
            }
        }
        

    }

    void MermiAt()
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(topClik);
        }
        
        GameObject mermi = Instantiate(mermiPrefab[Random.Range(0,mermiPrefab.Length)], mermiYeri.position, mermiYeri.rotation) as GameObject;

    }

    void Update()
    {
        if (rotaDegissinMi)
        {
            RotateDegistir();
        }
    }
}
