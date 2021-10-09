using System;

namespace Workspace.Learning.ObjectsEssence.Resources.Enemies
{
    public class Lizard : Enemy
    {
        public Lizard(int health = 5, int defaultAttackDamage = 2) 
            : base(health, defaultAttackDamage)
        { }

        public override void Heal(float amount = 1) => Health += amount;

        public override void Attack() =>
            Console.WriteLine($"You have taken {DefaultAttackDamage} amount of damage");
        
    }
}