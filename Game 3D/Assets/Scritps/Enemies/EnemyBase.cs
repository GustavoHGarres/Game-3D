using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Animation;

namespace Enemy
{

   public class EnemyBase : MonoBehaviour, IDamageable
   {
        public Collider collider;
        public Flashcolor flashcolor;
        public ParticleSystem particleSystem;

        public float startLie = 10f;
        [SerializeField] private float _currentLife;

        [Header("Animation")]
        [SerializeField] private AnimationBase _animationBase;

        [Header("Start Animation")]
        public float startAnimationDuration = .2f;
        public Ease startAnimationEase = Ease.OutBack;
        public bool startWithBornAnimation = true;

        private void Awake()
        {
            Init();
        }

        protected void ResetLife()
        {
            _currentLife = startLie;
        }

        protected virtual void Init()
        {
            ResetLife();
            if(startWithBornAnimation)
               BornAnimation();
               PlayAnimationByTrigger(AnimationType.ATTACK);
        }


        protected virtual void Kill()
        {
           OnKill();
        }

        protected virtual void OnKill()
        { 
           if(collider != null) collider.enabled = false;
           Destroy(gameObject, 3f);
           PlayAnimationByTrigger(AnimationType.DEATH);
        }

        public void OnDamage(float f)
        {
        
            if(flashcolor != null) flashcolor.Flash();
            if(particleSystem != null) particleSystem.Emit(15);

            transform.position -= transform.forward; // Quando recebe impacto do projetil desloca o inimigo para frente;

            _currentLife -= f;

            if(_currentLife <= 0)
            {
                Kill();
            }
        }

        #region Animation

        private void BornAnimation()
        {
            transform.DOScale(0, startAnimationDuration).SetEase(startAnimationEase).From();
        }

        public void PlayAnimationByTrigger(AnimationType animationType)
        {
            _animationBase.PlayAnimationByTrigger(animationType);
        }

        #endregion

        public void Damage(float damage)
        {
            // throw new System.NotImplementedException(); //Lembra o implemento da interface
            Debug.Log("Damage");
            OnDamage(damage);
        }

        public void Damage(float damage, Vector3 dir) // Quando recebe impacto do projetil desloca o inimigo para frente;
        {
            OnDamage(damage);
            //transform.DOMove(transform.postion - dir, .1f); //Rever não aceito o codigo transform.
        }

        private void OnCollisionEnter(Collision collision)
        {
            Player p = collision.transform.GetComponent<Player>();

            if (p != null) //Se o player bateu no inimigo;
            {
                p.Damage(1); //Vem da Lista FlashColor
            }
        }
   }

}
