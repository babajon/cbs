using Infrastructure.Events;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Read;
using MongoDB.Driver;
using Newtonsoft.Json;
using Events.External;
using System.Collections.Generic;
using System;
using System.Linq;
using Read.TextMessageRecievedFeatures;
using Read.HealthRiskFeatures;

namespace Web
{
    [Route("api/testdatagenerator")]
    public class TestDataGeneratorController
    {
        private IEventEmitter _eventEmitter;
        private IMongoDatabase _database;

        public TestDataGeneratorController(IEventEmitter eventEmitter, IMongoDatabase database)
        {
            _eventEmitter = eventEmitter;
            _database = database;
        }

        [HttpGet("all")]
        public void CreateAll()
        {
            CreateDataCollectors();
            CreateHealthRisks();
            CreateTextMessages();
        }

        [HttpGet("datacollectors")]
        public void CreateDataCollectors()
        {
            var _collection = _database.GetCollection<DataCollector>("DataCollector");
            _collection.DeleteMany(v => true);

            var dataCollectors = JsonConvert.DeserializeObject<DataCollectorAdded[]>(File.ReadAllText("./TestData/DataCollectors.json"));
            foreach (var dataCollector in dataCollectors)
                _eventEmitter.Emit("DataCollectorAdded", dataCollector);
        }


        [HttpGet("producejsonfortextmessages")]
        public void ProduceJsonForTextMessages()
        {
            var events = new List<TextMessageReceived>();
            var randomizer = new Random();

            var keywords = new[] { "" };

            var numbers = new[] {
                "",         // missing
                "11111111", // DataCollector #1
                "22222222", // DataCollector #2
                "33333333", // DataCollector #3
                "00000000"  // Non existing data collector
            };

            var healthRiskIds = new[]
            {
                1,
                5,
                8,
                24,
                37
            };

            for (int i = 0; i < 100; i++)
            {
                var message = randomizer.NextDouble() < 0.9 ? CreateValidMessage(healthRiskIds) : CreateInvalidMessage();

                var textMessage = new TextMessageReceived()
                {
                    Id = Guid.NewGuid(),
                    Keyword = keywords[randomizer.Next(keywords.Length)],
                    OriginNumber = numbers[randomizer.Next(keywords.Length)],
                    Sent = DateTimeOffset.Now.AddSeconds(-randomizer.NextDouble() * 60 * 60 * 24 * 7 * 26), // last 26 weeks
                    ReceivedAtGatewayNumber = "0123456789",
                    Message = message
                };

                // Create location for half the messages
                if (randomizer.NextDouble() > 0.5)
                {
                    textMessage.Latitude = -80d + randomizer.NextDouble() * 80d;    // Latitude between -80 and 80 degrees
                    textMessage.Longitude = randomizer.NextDouble() * 360d;         // Longitude between 0 and 360 degrees
                }

                events.Add(textMessage);
            }

            File.WriteAllText("./TestData/TextMessagesReceived.json", JsonConvert.SerializeObject(events, Formatting.Indented));
        }

        private string CreateInvalidMessage()
        {
            Random randomizer = new Random();
            if (randomizer.NextDouble() < 0.5)
                return "1#2#1#1#2#1";
            else
                return "Hello! My report is #1#0#0#2#3#0#2#3#0#2#3#0#2#3#0";
        }

        private string CreateValidMessage(int[] healthRiskIds)
        {
            Random randomizer = new Random();

            if (randomizer.NextDouble() > 0.7)
            {
                // Aggregate event: health risk # males under 5 # males over 5 # female under 5 # female over 5
                var incidents = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 3 };
                return $"{healthRiskIds[randomizer.Next(healthRiskIds.Length)]}#{incidents[randomizer.Next(incidents.Length)]}#{incidents[randomizer.Next(incidents.Length)]}#{incidents[randomizer.Next(incidents.Length)]}#{incidents[randomizer.Next(incidents.Length)]}";
            }
            else
            {
                // Single event: healt risk # sex # age
                return $"{healthRiskIds[randomizer.Next(healthRiskIds.Length)]}#{randomizer.Next(2) + 1}#{randomizer.Next(70) + 1}";
            }
        }


        [HttpGet("textmessages")]
        public void CreateTextMessages()
        {
            var _collection = _database.GetCollection<ReceivedTextMessage>("TextMessages");
            _collection.DeleteMany(v => true);

            var textMessagesEvents = JsonConvert.DeserializeObject<TextMessageReceived[]>(File.ReadAllText("./TestData/TextMessagesReceived.json"));
            foreach (var @event in textMessagesEvents)
                _eventEmitter.Emit("TextMessageReceived", @event);
        }

        [HttpGet("healthrisks")]
        public void CreateHealthRisks()
        {
            var _collection = _database.GetCollection<HealthRisk>("HealthRisks");
            _collection.DeleteMany(v => true);

            var healthRisks = JsonConvert.DeserializeObject<HealthRiskCreated[]>(File.ReadAllText("./TestData/HealthRisks.json"));
            foreach (var healthRisk in healthRisks)
                _eventEmitter.Emit("HealthRiskCreated", healthRisk);
        }
    }
}