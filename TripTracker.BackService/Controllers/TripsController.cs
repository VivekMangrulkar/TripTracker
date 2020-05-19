using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripTracker.BackService.Models;

namespace TripTracker.BackService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripsController : Controller
    {
        private Repository _repository;

        public TripsController(Repository repository)
        {
            _repository = repository;
        }             

        [HttpGet]
        public IEnumerable<Trip> Get()
        {
            return _repository.Get();
        }

        [HttpGet("{id}")]
        public Trip Get(int id)
        {
            return _repository.Get(id);
        }

        [HttpPost]
        public void Post([FromBody]Trip value)
        {
            _repository.AddTrip(value);
        }

        [HttpPut("{id}")]
        public void Put([FromBody]Trip value)
        {
            _repository.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Remove(id);
        }
    }
}
