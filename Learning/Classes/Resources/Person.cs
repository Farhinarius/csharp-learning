namespace Learning.Classes.Resources
{
    public class Person
    {
        public string SSN { get; init; }
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person() { }
        public Person(string firstName, string lastName, int age, string ssn = default)
        {
            Age = age;
            FirstName = firstName;
            LastName = lastName;
            SSN = ssn;
        }

        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}, Age: {Age}";
        }

        // implemet ToString().GetHashHode() if your model don't have specific unique identifier
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        // implement id.GetHashCode() if your model have unique identifier
        //public override int GetHashCode()
        //{
        //    return SSN is not null ? SSN.GetHashCode() : base.GetHashCode();
        //}
    }
}