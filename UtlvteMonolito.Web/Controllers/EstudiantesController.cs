using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UtlvteMonolito.Web.Data;
using UtlvteMonolito.Web.Models;

namespace UtlvteMonolito.Web.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstudiantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Estudiantes (Listar)
        public async Task<IActionResult> Index()
        {
            var estudiantes = await _context.Estudiantes.ToListAsync();
            return View(estudiantes);
        }

        // GET: Estudiantes/Details/5 (Ver detalle)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var estudiante = await _context.Estudiantes
                .FirstOrDefaultAsync(m => m.Id == id);

            if (estudiante == null) return NotFound();

            return View(estudiante);
        }

        // GET: Estudiantes/Create (Vista de registro)
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estudiantes/Create (Guardar estudiante)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cedula,Nombres,Apellidos,CorreoInstitucional,Carrera,FechaRegistro,EstadoActivo")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudiante);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Estudiante registrado correctamente.";
                return RedirectToAction(nameof(Index));
            }
            return View(estudiante);
        }

        // GET: Estudiantes/Edit/5 (Vista de edición)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null) return NotFound();

            return View(estudiante);
        }

        // POST: Estudiantes/Edit/5 (Guardar cambios)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cedula,Nombres,Apellidos,CorreoInstitucional,Carrera,FechaRegistro,EstadoActivo")] Estudiante estudiante)
        {
            if (id != estudiante.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudiante);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Datos del estudiante actualizados correctamente.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudianteExists(estudiante.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(estudiante);
        }

        // GET: Estudiantes/Delete/5 (Vista de confirmación de eliminación)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var estudiante = await _context.Estudiantes
                .FirstOrDefaultAsync(m => m.Id == id);

            if (estudiante == null) return NotFound();

            return View(estudiante);
        }

        // POST: Estudiantes/Delete/5 (Confirmar eliminación)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante != null)
            {
                _context.Estudiantes.Remove(estudiante);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Estudiante eliminado correctamente.";
            }
            return RedirectToAction(nameof(Index));
        }

        private bool EstudianteExists(int id)
        {
            return _context.Estudiantes.Any(e => e.Id == id);
        }
    }
}