using System;

namespace Workspace.Learning.ObjectsEssence.Resources.Enemies
{
    public class Spider : Enemy
    {
        public Spider(float health = 7, float defaultAttackDamage = 3) 
            : base(health, defaultAttackDamage)
        { }

        public override void Heal(float amount = 1) => _health += amount;

        public override void Attack() =>
            Console.WriteLine($"You have taken {_defaultAttackDamage} amount of damage");
    }
}