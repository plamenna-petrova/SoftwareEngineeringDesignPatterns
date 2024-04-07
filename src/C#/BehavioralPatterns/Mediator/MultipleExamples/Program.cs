using MultipleExamples.CommunicationHub.Mediators;
using MultipleExamples.CommunicationHub.Participants;
using MultipleExamples.CQRS;
using System;
using System.Collections.Generic;

namespace MultipleExamples
{
    public class Program
    {
        static void Main(string[] args)
        {
            ExecuteChainReactionExample();
            Console.WriteLine("================================  ||||||  ================================");
            ExecuteCommunicationHubExample();
            Console.WriteLine("================================  ||||||  ================================");
            ExecuteCQRSExample();
        }

        private static void ExecuteChainReactionExample()
        {
            var mediator = new ChainReactionExample.Mediator();
            var dropdown = mediator.Dropdown;

            dropdown.SelectValue("Manual");
            dropdown.SelectValue("Auto");
        }

        private static void ExecuteCommunicationHubExample()
        {
            var Alice = new User("Alice");
            var Bob = new User("Bob");
            var Jim = new User("Jim");
            var Tom = new User("Tom");

            var temperatureSensor = new Sensor("temperature");
            var windSensor = new Sensor("wind");
            var humiditySensor = new Sensor("humidity");

            var accelerometerSensor = new AccelerometerSensor();
            var sensorCommandHub = new SensorCommandMediator();

            sensorCommandHub.Groups.Add(new Group()
            {
                Participants = new List<Participant>()
                {
                    accelerometerSensor,
                    humiditySensor,
                    temperatureSensor,
                    Jim,
                    Bob,
                    Tom
                }
            });

            accelerometerSensor.Mediator = sensorCommandHub;

            var directHub = new DirectMediator();
            var groupHub = new GroupMediator();
            var broadcastHub = new BroadcastMediator();

            Alice.Mediator = directHub;
            Bob.Mediator = broadcastHub;
            Jim.Mediator = directHub;
            Tom.Mediator = directHub;

            broadcastHub.Participants.AddRange(new Participant[] { Alice, Bob, Jim });

            groupHub.Groups.Add(new Group() { Participants = new List<Participant>() { Alice, Bob, temperatureSensor } });
            groupHub.Groups.Add(new Group() { Participants = new List<Participant>() { humiditySensor, Jim, Bob } });

            temperatureSensor.Mediator = groupHub;
            humiditySensor.Mediator = groupHub;
            windSensor.Mediator = broadcastHub;

            Bob.Send(Alice, "a message");
            Alice.Send(Bob, "another message");

            temperatureSensor.ValueChanged(3.5m);
            windSensor.ValueChanged(2);
            humiditySensor.ValueChanged(10);

            accelerometerSensor.ValueChanged(0.5);

            Bob.Send(temperatureSensor, "measure");

            Tom.Send(humiditySensor, "measure");
            Jim.Send(accelerometerSensor, "measure");
        }

        private static void ExecuteCQRSExample()
        {
            ProductsController productsController = new ProductsController(new Mediator(new Dictionary<Type, Type>()
            {
                { typeof(CreateProductCommand), typeof(CreateProductCommandHandler) },
                { typeof(GetProductsRequest), typeof(GetProductsRequestHandler) }
            }));

            productsController.CreateProduct("Product 1", 100);

            var products = productsController.GetProducts();
        }
    }
}
