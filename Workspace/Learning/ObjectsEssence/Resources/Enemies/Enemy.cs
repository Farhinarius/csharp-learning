namespace Workspace.Learning.ObjectsEssence.Resources.Enemies
{
    public abstract class Enemy
    {
        protected float _health;

        protected float _defaultAttackDamage;

        protected Enemy(float health = 3, float defaultAttackDamage = 1)
        {
            _health = health;
            _defaultAttackDamage = defaultAttackDamage;
        }

        public virtual void Heal(float amount = 1) => _health += amount;

        public abstract void Attack();

        // type check example
        public static void Upgrade(Enemy enemy)
        {
            // non empty variable case
            // switch (enemy)
            // {
            //     case Lizard l:
            //         break;
            //     case Spider s:
            //         break;
            // }
            
            // empty variables case
            switch (enemy)
            {
                case Lizard _:
                    break;
                case Spider _:
                    break;
            }
        }
    }
}