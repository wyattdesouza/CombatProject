using UnityEngine;

namespace Prototypes
{
    public abstract class AIBAse : MonoBehaviour
    {
        [SerializeField, Range(0f, 100f)] protected float _totalHealth;
        [SerializeField] private ParticleSystem _deathParticle;

        public abstract void TakeDamage();

        
        public void KillMe()
        {
            _deathParticle.Play();
            BuffPlayer();
        }

        protected virtual void BuffPlayer()
        {
            // If we need it
        }
    }


    public class Goblin : AIBAse
    {
        private float _damageToTake = 5;
        private ParticleSystem _damageParticle;
        
        
        public override void TakeDamage()
        {
            _totalHealth = 5;
            _totalHealth -= _damageToTake;
            _damageParticle.Play();
        }
        
        
        protected override void BuffPlayer()
        {
            // If we need it
        }
    }
}