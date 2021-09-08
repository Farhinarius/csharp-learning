using System;

namespace Workspace.Learning.ObjectsEssence.Resources.Enemies
{
    public class Lizard : Enemy
    {
        public Lizard(int health = 5, int defaultAttackDamage = 2) 
            : base(health, defaultAttackDamage)
        { }

        public override void Heal(float amount = 1) => _health += amount;

        public override void Attack() =>
            Console.WriteLine($"You have taken {_defaultAttackDamage} amount of damage");
        
    }
}