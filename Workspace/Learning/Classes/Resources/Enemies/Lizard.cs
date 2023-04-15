using System;

namespace Workspace.Learning.Classes.Resources.Enemies
{
    public class Lizard : Enemy
    {
        private float _defenseValue;

        public Lizard(float defenseValue = 1, float health = 5, float attackDamage = 2)
            : base(health, attackDamage)
        {
            _defenseValue = defenseValue;
        }

        public override void Attack() =>
            Console.WriteLine($"You have taken {AttackDamage} amount of damage");

        public void UseShield() => Console.WriteLine($"Acquired shield: {_defenseValue}");
    }
}