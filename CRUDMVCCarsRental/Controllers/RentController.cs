﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDMVCCarsRental.Data;
using CRUDMVCCarsRental.Entities;
using CRUDMVCCarsRental.Models;
using AutoMapper;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Dependency;

namespace CRUDMVCCarsRental.Controllers
{
    public class RentController : Controller
    {
        private readonly CarsRentalDbContext _context;
        private readonly IMapper _mapper;
        private static DateTime startDate;
        private static DateTime endDate;

        public RentController(CarsRentalDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Search(RentInputModel input)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RentInputModel input)
        {
            try
            {
                if (input.StartingDate >= input.EndingDate)
                {
                    throw new Exception("A data de aluguel deve ser maior que a de devolução!");
                }

                if (input.StartingDate <= DateTime.Now)
                {
                    throw new Exception("A data do aluguel deve ser maior que a data atual!");
                }

                var findRents = await _context.Rents
                    .Where(x => x.EndingDate >= input.StartingDate && !x.Canceled).ToListAsync();

                var cars = await _context.Cars.Where(x => !x.Deleted).ToListAsync();

                if (cars == null)
                {
                    return NotFound();
                }

                foreach (var item in findRents)
                {
                    var carToRemove = cars.FirstOrDefault(x => x.Id == item.CarId);

                    cars.Remove(carToRemove);
                }

                var viewModel = _mapper.Map<List<CarsViewModel>>(cars);

                startDate = input.StartingDate;
                endDate = input.EndingDate;

                return View(viewModel);
            }
            catch(Exception exception)
            {
                return Problem(exception.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> ConfirmRent(Guid? id)
        {
            if (id == null || _context.Rents == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            var rent = new Rent();

            rent.StartingDate = startDate;
            rent.EndingDate = endDate;
            rent.CalculateDaysRented();
            rent.CalculateValueOfRent(car.RentValuePerDay);
            rent.CarId = car.Id;

            var viewModel = _mapper.Map<RentsViewModel>(rent);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmRent(Guid carId, RentsViewModel input)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(x => x.Id == carId);
            var rent = _mapper.Map<Rent>(input);
            rent.Id = Guid.NewGuid();
            if (rent == null || car == null)
                return NotFound();

            _context.Add(rent);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Created));
        }

        public IActionResult Created()
        {
            return View();
        }
    }
}
