using Core.Entities;

namespace Web.ViewModel
{
    public class OfferViewModel
    {
        public Offer Offer { get; set; } 
        public IEnumerable<Car> Cars { get; set; }

        public Booking Booking { get; set; }

        public TimeOnly PickUpTime {  get; set; }
        public TimeOnly DropOffTime {  get; set; }
    }
}
