using CrewModel.Entities;
using Crew = CrewModel.Entities.Crew;

namespace CrewGrpcService.Datastore;

public static class CrewDatastore {
    public static List<CrewModel.Entities.Crew> Crew = new() {
        new Commander() {
            CrewMemberId = 1,
            Health = 100
        },
        new Guard() {
            CrewMemberId = 2,
            Health = 500
        },
        new Mechanic() {
            CrewMemberId = 3,
            Health = 50
        },
        new Droid() {
            CrewMemberId = 4,
            Health = 10
        },
        new Guard() {
            CrewMemberId = 5,
            Health = 500
        }
    };
    
    public static List<CrewModel.Entities.Logbook> Logbook = new() {
        new Logbook() {
            LogId = 1,
            AuthorMemberId = 3,
            AuthorMember = Crew.SingleOrDefault(c=>c.CrewMemberId == 3),
            Content = "09.10.2022 15:38 - Rear thrusters are damaged. Estimated fix time: 17:00",
            Title = "09.10.2022 15:38 - Rear thruster damage"
        },
        new Logbook() {
            LogId = 2,
            AuthorMemberId = 5,
            AuthorMember = Crew.SingleOrDefault(c=>c.CrewMemberId == 5),
            Content = "08.08.2022 - Spotted several Intruders in sector 3a. They have heavy weapons. Locked them in and arrested them using laser barriers.",
            Title = "08.08.2022 - Intruders in sector 3a"
        },
        new Logbook() {
            LogId = 3,
            AuthorMemberId = 1,
            AuthorMember = Crew.SingleOrDefault(c=>c.CrewMemberId == 1),
            Content = "02.08.2022 - Arrived on Earth in the Milchstrasse galaxy. Total flight time was 17 minutes.",
            Title = "02.08.2022 - Arrived on Earth"
        }
    };
}
