using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{
   
   public GunBase gunBaseR;
   public GunBase gunBaseT;
   public GunBase gunBaseY;
   

   protected override void Init()
   {
       base.Init();

       inputs.GamePlay.Shoot.performed += cts => StartShoot();
       inputs.GamePlay.Shoot.performed += cts => CancelShoot();
   }

   private void StartShoot()
   {
    gunBaseR.StartShoot();
    gunBaseT.StartShoot();
    gunBaseY.StartShoot();
    
    Debug.Log("Start Shoot");
   }

   private void CancelShoot()
   {
    Debug.Log("Stop Shoot");
    gunBaseR.StopShoot();
    gunBaseT.StopShoot();
    gunBaseY.StopShoot();
   }
}
