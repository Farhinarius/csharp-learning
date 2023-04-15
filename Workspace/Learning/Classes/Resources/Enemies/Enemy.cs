namespace Workspace.Learning.Classes.Resources.Enemies
{
    public abstract class Enemy
    {
        public float Health { get; private set; }

        public float MaxHealth { get; private set; }

        public float AttackDamage { get; private set; }

        protected Enemy(float health = 3, float attackDamage = 1)
        {
            Health = health;
            AttackDamage = attackDamage;
        }

        public virtual void Heal(float amount = 1) => Health += amount;                 // can be overriden - standard implementation 

        public abstract void Attack();      // must be overriden - protocol
        
        public virtual void LevelUp(float updatedMaxHealth, float updatedAttackDamage)  // can be overriden - standard implementation 
        {
            MaxHealth = updatedMaxHealth;
            AttackDamage = updatedAttackDamage;
        }
        
    }
}