using System;

namespace Learning.Classes.Resources.Enemies
{
    public class Spider : Enemy
    {
        private float _poisonDamage;

        public Spider(float poisonDamage = 1, float health = 7, float attackDamage = 3)
            : base(health, attackDamage)
        {
            _poisonDamage = poisonDamage;
        }

        public override void Attack() =>
            Console.WriteLine($"You have taken {AttackDamage} amount of damage and {_poisonDamage} poison amount of damage");
    }
}