using System;

namespace AnimalWorld
{
    public abstract class ContinentFactory
    {
        public abstract Herbivore CreateHerbivore();

        public abstract Carnivore CreateCarnivore();
    }

    public class AfricaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new WildeBeest();
        }

        public override Carnivore CreateCarnivore()
        {
            return new Lion();
        }
    }

    public class AmericaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Bison();
        }

        public override Carnivore CreateCarnivore()
        {
            return new Wolf();
        }
    }

    public abstract class Herbivore
    {

    }

    public abstract class Carnivore
    {
        public abstract void Eat(Herbivore herbivore);
    }

    public class WildeBeest : Herbivore
    {

    }

    public class Lion : Carnivore
    {
        public override void Eat(Herbivore herbivore)
        {
            Console.WriteLine($"{this.GetType().Name} eats {herbivore.GetType().Name}");
        }
    }

    public class Bison : Herbivore
    {

    }

    public class Wolf : Carnivore
    {
        public override void Eat(Herbivore herbivore)
        {
            Console.WriteLine($"{this.GetType().Name} eats {herbivore.GetType().Name}");
        }
    }

    public class AnimalWorld
    {
        private Herbivore _herbivore;
        private Carnivore _carnivore;

        public AnimalWorld(ContinentFactory continentFactory)
        {
            _herbivore = continentFactory.CreateHerbivore();
            _carnivore = continentFactory.CreateCarnivore();
        }

        public void RunFoodChain()
        {
            _carnivore.Eat(_herbivore);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            ContinentFactory africaFactory = new AfricaFactory();
            AnimalWorld africaAnimalWorld = new AnimalWorld(africaFactory);
            africaAnimalWorld.RunFoodChain();

            ContinentFactory americaFactory = new AmericaFactory();
            AnimalWorld americaAnimalWorld = new AnimalWorld(americaFactory);
            americaAnimalWorld.RunFoodChain();
        }
    }
}