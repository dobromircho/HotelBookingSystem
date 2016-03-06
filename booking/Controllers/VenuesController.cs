using System;
namespace HotelBookingSystem.Controllers
{
    using Infrastructure;
    using Models;
    using System.Linq;

    public class VenuesController : Controller
    {
        public VenuesController(IHotelBookingSystemData data, User user)
            : base(data, user)
        {
        }

        public IView All()
        {
            var venues = this.Data.RepositoryWithVenues.GetAll();
            return this.View(venues);
        }

        public IView Details(int id)
        {
            this.Authorize(Roles.User, Roles.VenueAdmin);
            var venue = this.Data.RepositoryWithVenues.Get(id);
            if (venue == null)
            {
                return this.NotFound(string.Format("The venue with ID {0} does not exist.", id));
            }

            return this.View(venue);
        }

        public IView Rooms(int id)
        {
            // TODO: Implement me
            throw new NotImplementedException();
        }

        public IView Add(string name, string address, string description)
        {
            var newVenue = new Venue(name, address, description, this.CurrentUser);
            this.Data.RepositoryWithVenues.Add(newVenue);
            return this.View(newVenue);
        }
    }
}