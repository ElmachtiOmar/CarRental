using Core.Entities;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Web.ViewModel;

namespace Web.Controllers
{
    public class OfferController : Controller
    {
        private readonly MongoUnitOfWork _unitOfWork;

        public OfferController(MongoUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        public async Task<IActionResult> Index(Booking booking, string PickUpTime, string CollectionTime)
        {
            var filteredOffers = await _unitOfWork.OfferRepository.GetOffersByLocationAsync(booking.PickUpLocation);
            return View(filteredOffers);
        }

        public async Task<IActionResult> Create()
        {
            var cars = await _unitOfWork.CarRepository.GetAllAsync();

            if (cars == null || !cars.Any())
            {
                return Problem("No cars available.");
            }

            var viewModel = new OfferViewModel
            {
                Offer = new Offer(), // A new offer object for the form
                Cars = cars // The list of cars for the dropdown
            };
            
            return View(viewModel); // Pass the view model to the view
        }





        [HttpPost]
        public async Task<IActionResult> Create(OfferViewModel model)
        {
                // Find the Car object from the Cars list using the Car Id from the view model
                var selectedCarId = model.Offer.Car?.Id; // Get the Car Id from the bound model
                var car = await _unitOfWork.CarRepository.GetByIdAsync(selectedCarId); // Fetch the Car
                model.Offer.Car = car;




                if (string.IsNullOrEmpty(model.Offer.Id))
                {
                    model.Offer.Id = null; // Explicitly set to null to ensure auto-generation
                }

                // Insert the new Offer into the repository
                await _unitOfWork.OfferRepository.InsertAsync(model.Offer);

                return RedirectToAction("Index");
            


        }



        [HttpPost]
        public async Task<IActionResult> Edit(string id, Offer offer)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.OfferRepository.UpdateAsync(id, offer);

                return RedirectToAction("Index");
            }
            return View(offer);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var offer = await _unitOfWork.OfferRepository.GetByIdAsync(id);
            if (offer == null)
            {
                return NotFound();
            }
            return View(offer);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _unitOfWork.OfferRepository.DeleteAsync(id);

            return RedirectToAction("Index");
        }


    }
}
