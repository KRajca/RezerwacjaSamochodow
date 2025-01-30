using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RezerwacjaSamochodow.Models;

[Authorize(Roles = "Admin")]
public class CarsController : Controller
{
    private readonly ApplicationDbContext _context;

    public CarsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Wyświetla listę wszystkich samochodów
    public async Task<IActionResult> Index()
    {
        return View(await _context.Cars.ToListAsync());
    }

    // Wyświetla szczegóły wybranego samochodu
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var car = await _context.Cars.FirstOrDefaultAsync(m => m.Id == id);
        if (car == null) return NotFound();
        return View(car);
    }

    // Wyświetla formularz do tworzenia nowego samochodu
    public IActionResult Create()
    {
        return View();
    }

    // Tworzy nowy samochód w bazie danych
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Brand,Model,Year,PricePerDay")] Car car)
    {
        if (ModelState.IsValid)
        {
            _context.Add(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(car);
    }

    // Wyświetla formularz do edytowania samochodu
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var car = await _context.Cars.FindAsync(id);
        if (car == null) return NotFound();
        return View(car);
    }

    // Edytuje dane samochodu w bazie danych
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,Model,Year,PricePerDay")] Car car)
    {
        if (id != car.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(car);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(car.Id)) return NotFound();
                else throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(car);
    }

    // Wyświetla stronę potwierdzenia usunięcia samochodu
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var car = await _context.Cars.FirstOrDefaultAsync(m => m.Id == id);
        if (car == null) return NotFound();
        return View(car);
    }

    // Usuwa samochód z bazy danych
    [HttpPost, ActionName("DeleteConfirmed")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var car = await _context.Cars.FindAsync(id);
        _context.Cars.Remove(car);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // Sprawdza, czy samochód o danym id istnieje
    private bool CarExists(int id)
    {
        return _context.Cars.Any(e => e.Id == id);
    }
}
