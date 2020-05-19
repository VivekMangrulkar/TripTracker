using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripTracker.BackService.Models
{
    public class Repository
    {
        private List<Trip> MyTrips = new List<Trip>
        {
            new Trip
            {
                Id = 1,
                Name = "India",
                StartDarte = new DateTime(2020,03,12),
                EndDate = new DateTime(2020, 03, 20)
            },
            new Trip
            {
                Id = 2,
                Name = "Sydney",
                StartDarte = new DateTime(2020,06,15),
                EndDate = new DateTime(2020, 06, 20)
            },
             new Trip
            {
                Id = 2,
                Name = "Melbourne",
                StartDarte = new DateTime(2020,07,03),
                EndDate = new DateTime(2020, 07, 05)
            }
        };

        public List<Trip> Get()
        {
            return MyTrips;
        }

        public Trip Get(int id)
        {
            return MyTrips.First(t => t.Id == id);
        }

        public void AddTrip(Trip newTrip)
        {
            MyTrips.Add(newTrip);
        }

        public void Update(Trip tripToUpdate)
        {
            MyTrips.Remove(MyTrips.First(t => t.Id == tripToUpdate.Id));
            MyTrips.Add(tripToUpdate);
        }

        public void Remove(int id)
        {
            MyTrips.Remove(MyTrips.First(t => t.Id == id));
        }
    }
}
