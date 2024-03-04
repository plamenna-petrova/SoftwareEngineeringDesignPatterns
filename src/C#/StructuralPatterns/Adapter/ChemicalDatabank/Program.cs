using System;
using System.Text;

namespace ChemicalDatabank
{
    public class Compound
    {
        protected float BoilingPoint { get; set; }

        protected float MeltingPoint { get; set; }

        protected double MolecularWeight { get; set; }

        protected string MolecularFormula { get; set; }

        public virtual void Display() => Console.WriteLine("\nCompound: Unknown: -------");
    }

    public class RichCompound : Compound
    {
        private string chemical;

        private ChemicalDatabank chemicalDatabank;

        public RichCompound(string chemical)
        {
            this.chemical = chemical;
        }

        public override void Display()
        {
            chemicalDatabank = new ChemicalDatabank();

            BoilingPoint = chemicalDatabank.GetCriticalPoint(chemical, "B");
            MeltingPoint = chemicalDatabank.GetCriticalPoint(chemical, "M");
            MolecularWeight = chemicalDatabank.GetMolecularWeight(chemical);
            MolecularFormula = chemicalDatabank.GetMolecularStructure(chemical);

            var stringBuilder = new StringBuilder()
                .AppendLine($"Compound :  {new string('-', 7)} {chemical}")
                .AppendLine($" Formula : {MolecularFormula}")
                .AppendLine($" Weight : {MolecularWeight}")
                .AppendLine($" Melting Point: {MeltingPoint}")
                .AppendLine($" Boiling Point: {BoilingPoint}");

            Console.WriteLine(stringBuilder.ToString());
        }
    }

    public class ChemicalDatabank
    {
        public float GetCriticalPoint(string compound, string point)
        {
            float criticalPoint = default;

            switch (point)
            {
                case "B":
                    criticalPoint = compound.ToLower() switch
                    {
                        "water" => 100.0f,
                        "benzene" => 80.1f,
                        "ethanol" => 78.3f,
                        _ => 0f,
                    };
                    break;
                case "M":
                    criticalPoint = compound.ToLower() switch
                    {
                        "water" => 0.0f,
                        "benzene" => 5.5f,
                        "ethanol" => -114.1f,
                        _ => 0f,
                    };
                    break;
                default:
                    break;
            }

            return criticalPoint;
        }

        public string GetMolecularStructure(string compound)
        {
            return compound.ToLower() switch
            {
                "water" => "H20",
                "benzene" => "C6H6",
                "ethanol" => "C2H50H",
                _ => "",
            };
        }

        public double GetMolecularWeight(string compound)
        {
            return compound.ToLower() switch
            {
                "water" => 18.015,
                "benzene" => 78.1134,
                "ethanol" => 46.0688,
                _ => 0d,
            };
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Compound unknownCompound = new Compound();
            unknownCompound.Display();

            Console.WriteLine();

            Compound water = new RichCompound("Water");
            water.Display();
            Compound benzene = new RichCompound("Benzene");
            benzene.Display();
            Compound ethanol = new RichCompound("Ethanol");
            ethanol.Display();

            Console.ReadKey();
        }
    }
}
