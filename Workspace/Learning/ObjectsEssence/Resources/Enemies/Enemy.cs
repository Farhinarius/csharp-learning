namespace Workspace.Learning.ObjectsEssence.Resources.Enemies
{
    public abstract class Enemy
    {
        protected float Health;

        protected readonly float DefaultAttackDamage;

        protected Enemy(float health = 3, float defaultAttackDamage = 1)
        {
            Health = health;
            DefaultAttackDamage = defaultAttackDamage;
        }

        public virtual void Heal(float amount = 1) => Health += amount;

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