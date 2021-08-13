namespace SlotMachine.Slots
{
    public class Symbol
    {
        public string Name { get; set; }
        public decimal Coefficient { get; set; }
        public bool Wildcard { get; set; }
        public decimal ChanceToAppear { get; set; }

        public bool IsWildcard()
        {
            return Wildcard;
        }
    }

    public class Apple : Symbol
    {
        public Apple()
        {
            Name = "A";
            Coefficient = 0.4m;
            Wildcard = false;
            ChanceToAppear = 0.45m;
        }
    }

    public class Banana : Symbol
    {
        public Banana()
        {
            Name = "B";
            Coefficient = 0.6m;
            Wildcard = false;
            ChanceToAppear = 0.35m;
        }
    }

    public class Pineapple : Symbol
    {
        public Pineapple()
        {
            Name = "P";
            Coefficient = 0.8m;
            Wildcard = false;
            ChanceToAppear = 0.15m;
        }
    }
    public class Wildcard : Symbol
    {
        public Wildcard()
        {
            Name = "*";
            Coefficient = 0m;
            Wildcard = true;
            ChanceToAppear = 0.05m;
        }
    }
}
