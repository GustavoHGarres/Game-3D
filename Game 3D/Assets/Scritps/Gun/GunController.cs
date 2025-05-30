using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
   
    public GameObject[] guns;
    public int _currentGun;
    
   void Start()
  {
    
        _currentGun = 0;
        AtivarArma(guns[_currentGun]);
  }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) TrocarArma(0);
        if(Input.GetKeyDown(KeyCode.T)) TrocarArma(1);
        if(Input.GetKeyDown(KeyCode.Y)) TrocarArma(2);
    }

    public void TrocarArma(int newIndice)
    {
    if(newIndice >= 0 && newIndice < guns.Length)
    {
        DesativarArma(guns[_currentGun]);
        _currentGun = newIndice;
        AtivarArma(guns[_currentGun]);
    }
    }

    public void AtivarArma(GameObject gun)
    {
        gun.SetActive(true);
    }

    public void DesativarArma(GameObject gun)
    {
        gun.SetActive(false);
    }
}
