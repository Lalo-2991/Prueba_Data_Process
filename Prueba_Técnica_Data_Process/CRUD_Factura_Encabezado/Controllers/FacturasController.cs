using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_Factura_Encabezado.Models;

namespace CRUD_Factura_Encabezado.Controllers
{
    public class FacturasController : Controller
    {
        private readonly FactEncabezadoContext _context;

        public FacturasController(FactEncabezadoContext context)
        {
            _context = context;
        }

        // GET: Facturas
        public async Task<IActionResult> Index()
        {
            var factEncabezadoContext = _context.Encabezado.Include(e => e.IdEfectoComprobanteNavigation).Include(e => e.IdFormaPagoNavigation).Include(e => e.IdMetodoPagoNavigation).Include(e => e.IdMonedaNavigation);
            List<Encabezado> lstEncabezados = await factEncabezadoContext.ToListAsync();
            return View(lstEncabezados);
        }

        // GET: Facturas/Detalles/5
        public async Task<IActionResult> Detalles(int? id)
        {
            if (id == null || _context.Encabezado == null)
            {
                return NotFound();
            }

            var encabezado = await _context.Encabezado
                .Include(e => e.IdEfectoComprobanteNavigation)
                .Include(e => e.IdFormaPagoNavigation)
                .Include(e => e.IdMetodoPagoNavigation)
                .Include(e => e.IdMonedaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (encabezado == null)
            {
                return NotFound();
            }

            return View(encabezado);
        }

        // GET: Facturas/Agregar
        public IActionResult Agregar()
        {
            ViewData["IdEfectoComprobante"] = new SelectList(_context.EfectoComprobante, "IdEfectoComprobante", "NombreEfectoComprobante");
            ViewData["IdFormaPago"] = new SelectList(_context.FormaPago, "IdFormaPago", "NombreFormaPago");
            ViewData["IdMetodoPago"] = new SelectList(_context.MetodoPago, "IdMetodoPago", "NombreMetodoPago");
            ViewData["IdMoneda"] = new SelectList(_context.Moneda, "IdMoneda", "NombreMoneda");
            return View();
        }

        // POST: Facturas/Agregar
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Agregar([Bind("Id,Factura,Emisor,FolioFiscal,FechaEmision,FechaCertificacion,LugarExpedicion,IdMetodoPago,IdFormaPago,IdMoneda,IdEfectoComprobante")] Encabezado oEncabezado)
        {
            ModelState.Remove("IdEfectoComprobanteNavigation");
            ModelState.Remove("IdFormaPagoNavigation");
            ModelState.Remove("IdMetodoPagoNavigation");
            ModelState.Remove("IdMonedaNavigation");
            if (ModelState.IsValid)
            {
                _context.Add(oEncabezado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEfectoComprobante"] = new SelectList(_context.EfectoComprobante, "IdEfectoComprobante", "NombreEfectoComprobante", oEncabezado.IdEfectoComprobante);
            ViewData["IdFormaPago"] = new SelectList(_context.FormaPago, "IdFormaPago", "NombreFormaPago", oEncabezado.IdFormaPago);
            ViewData["IdMetodoPago"] = new SelectList(_context.MetodoPago, "IdMetodoPago", "NombreMetodoPago", oEncabezado.IdMetodoPago);
            ViewData["IdMoneda"] = new SelectList(_context.Moneda, "IdMoneda", "NombreMoneda", oEncabezado.IdMoneda);
            return View(oEncabezado);
        }

        // GET: Facturas/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null || _context.Encabezado == null)
            {
                return NotFound();
            }

            var encabezado = await _context.Encabezado.FindAsync(id);
            if (encabezado == null)
            {
                return NotFound();
            }
            ViewData["IdEfectoComprobante"] = new SelectList(_context.EfectoComprobante, "IdEfectoComprobante", "NombreEfectoComprobante", encabezado.IdEfectoComprobante);
            ViewData["IdFormaPago"] = new SelectList(_context.FormaPago, "IdFormaPago", "NombreFormaPago", encabezado.IdFormaPago);
            ViewData["IdMetodoPago"] = new SelectList(_context.MetodoPago, "IdMetodoPago", "NombreMetodoPago", encabezado.IdMetodoPago);
            ViewData["IdMoneda"] = new SelectList(_context.Moneda, "IdMoneda", "NombreMoneda", encabezado.IdMoneda);
            return View(encabezado);
        }

        // POST: Facturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id,Factura,Emisor,FolioFiscal,FechaEmision,FechaCertificacion,LugarExpedicion,IdMetodoPago,IdFormaPago,IdMoneda,IdEfectoComprobante")] Encabezado encabezado)
        {
            if (id != encabezado.Id)
            {
                return NotFound();
            }

            ModelState.Remove("IdEfectoComprobanteNavigation");
            ModelState.Remove("IdFormaPagoNavigation");
            ModelState.Remove("IdMetodoPagoNavigation");
            ModelState.Remove("IdMonedaNavigation");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(encabezado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EncabezadoExists(encabezado.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEfectoComprobante"] = new SelectList(_context.EfectoComprobante, "IdEfectoComprobante", "NombreEfectoComprobante", encabezado.IdEfectoComprobante);
            ViewData["IdFormaPago"] = new SelectList(_context.FormaPago, "IdFormaPago", "NombreFormaPago", encabezado.IdFormaPago);
            ViewData["IdMetodoPago"] = new SelectList(_context.MetodoPago, "IdMetodoPago", "NombreMetodoPago", encabezado.IdMetodoPago);
            ViewData["IdMoneda"] = new SelectList(_context.Moneda, "IdMoneda", "NombreMoneda", encabezado.IdMoneda);
            return View(encabezado);
        }

        // GET: Facturas/Eliminar/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.Encabezado == null)
            {
                return NotFound();
            }

            var encabezado = await _context.Encabezado
                .Include(e => e.IdEfectoComprobanteNavigation)
                .Include(e => e.IdFormaPagoNavigation)
                .Include(e => e.IdMetodoPagoNavigation)
                .Include(e => e.IdMonedaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (encabezado == null)
            {
                return NotFound();
            }

            return View(encabezado);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("ConfirmacionEliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminacion(int id)
        {
            if (_context.Encabezado == null)
            {
                return Problem("Entity set 'FactEncabezadoContext.Encabezado'  is null.");
            }
            var encabezado = await _context.Encabezado.FindAsync(id);
            if (encabezado != null)
            {
                _context.Encabezado.Remove(encabezado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EncabezadoExists(int id)
        {
          return (_context.Encabezado?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
