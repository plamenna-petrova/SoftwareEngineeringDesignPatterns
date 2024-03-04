using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GenericSerializablePrototype
{
    [Serializable()]
    public class ReferenceTypeClass
    {
        public string ID { get; set; }
    }

    [Serializable()]
    public abstract class Prototype<T>
    {
        public T Clone() => (T) MemberwiseClone();

        public T DeepCopy()
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(memoryStream, this);
            memoryStream.Seek(0, SeekOrigin.Begin);
            T memorySteamDeserializationCopy = (T) binaryFormatter.Deserialize(memoryStream);
            memoryStream.Close();
            return memorySteamDeserializationCopy;
        }
    }

    [Serializable()]
    public class ConcretePrototype : Prototype<ConcretePrototype>
    {
        public string ValueType { get; set; }

        public ReferenceTypeClass DummyReference { get; set; }

        public override string ToString() => $"Value type: {ValueType}, Dummy Reference ID: {DummyReference.ID}";
    }

    public class Program
    {
        static void Main(string[] args)
        {
            ConcretePrototype firstConcretePrototype = new ConcretePrototype
            {
                ValueType = "1",
                DummyReference = new ReferenceTypeClass() { ID = "1" }
            };

            ConcretePrototype secondConcretePrototype = firstConcretePrototype.Clone();
            ConcretePrototype thirdConcretePrototype = firstConcretePrototype.DeepCopy();

            secondConcretePrototype.ValueType = "2";
            secondConcretePrototype.DummyReference.ID = "2";

            Console.WriteLine(firstConcretePrototype.ToString());
            Console.WriteLine(secondConcretePrototype.ToString());
            Console.WriteLine(thirdConcretePrototype.ToString());
        }
    }
}
