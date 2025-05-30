using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
   public ProjectileBase prefabProjectile; // Para esta linha funcionar, o script ProjectileBase precisa existir;

   public Transform positionToShoot;
   public float timeBetweenShoot = .3f;
   public float speed = 50f;

   private Coroutine _currentCoroutine;

  // public KeyCode keyCode = KeyCode.Z;

   //void Update() // Sai quando entra o novo sistema de Inputs;
  // {
      // if(Input.GetKeyDown(keyCode))
       //{
            //_currentCoroutine = StartCoroutine(StartShoot());
      // }

       //else if (Input.GetKeyDown(keyCode))
      // {
           // if(_currentCoroutine != null)
            //StopCoroutine(_currentCoroutine);
       //}  
   //}

   protected virtual IEnumerator ShootCoroutine()
   {
        while(true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    
   }

   public virtual void Shoot()
   {
       var projectile = Instantiate(prefabProjectile);
       projectile.transform.position = positionToShoot.position;
       projectile.transform.rotation = positionToShoot.rotation; // O projetil rotaciona junto a posição do personagem;
       projectile.speed = speed;
   }

   public void StartShoot()
   {
       StopShoot();
       _currentCoroutine = StartCoroutine(ShootCoroutine());
   }

   public void StopShoot()
   {
       if(_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);
   }

}
