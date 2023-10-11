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
using Microsoft.AspNetCore.Mvc.Infrastructure;
using AutoMapper;
using NuGet.Protocol;
using Microsoft.Data.SqlClient;

namespace CRUDMVCCarsRental.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarsRentalDbContext _context;
        private readonly IMapper _mapper;

        public CarsController(CarsRentalDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cars = await _context.Cars.Where(x => !x.Deleted).ToListAsync();
            var viewModel = _mapper.Map<List<CarsViewModel>>(cars);

            return viewModel != null ?
                View(viewModel) :
                Problem("Entity set 'CarsRentalDbContext.Cars'  is null.");
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<CarsViewModel>(car);

            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCarInputModel input)
        {
            var newCar = _mapper.Map<Car>(input);

            _context.Add(newCar);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Cars == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<EditCarInputModel>(car));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EditCarInputModel input)
        {
            var carToUpdate = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
            
            if (carToUpdate == null)
            {
                return NotFound();
            }

            carToUpdate.Update
                (input.RegistrationDate, input.Model, input.FabricationYear, input.ModelYear, input.RentValuePerDay, input.Engine);

            _context.Cars.Update(carToUpdate);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Cars == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<CarsViewModel>(car));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Cars == null)
            {
                return Problem("Entity set 'CarsRentalDbContext.Cars'  is null.");
            }
            var car = await _context.Cars.FindAsync(id);

            car.Delete();
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> CarRentHistory(Guid id)
        {
            if(id == null || _context.Cars == null)
            {
                return NotFound();
            }

            var rents = await _context.Rents.Where(x => x.CarId == id).ToListAsync();
            var viewModel = _mapper.Map<List<RentsViewModel>>(rents).OrderBy(x => x.EndingDate);

            return View(viewModel);
        }
    }
}
