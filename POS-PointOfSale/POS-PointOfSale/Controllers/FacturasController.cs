using POS_PointOfSale.Models;
using POS_PointOfSale.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS_PointOfSale.Controllers
{
    public class FacturasController : Controller
    {

        POS_PointOfSaleContext db = new POS_PointOfSaleContext();
        // GET: Facturas
        public ActionResult NuevaFactura()
        {
            var facturaView = new FacturaView();
            facturaView.Cliente = new Cliente();
            facturaView.Inventarios = new List<InventarioOrden>();
            Session["facturaView"] = facturaView;

            var lista = (db.Clientes.ToList());
            lista.Add(new Cliente { cl_cedula = 0, cl_nombre = "[Seleccione un Cliente]" });
            lista = lista.OrderBy(c => c.cl_nombre).ToList();
            ViewBag.cl_cedula = new SelectList(lista, "cl_cedula", "cl_nombre");

            return View(facturaView);


           
        }
        [HttpPost]
        public ActionResult NuevaFactura(FacturaView facturaView)
        {
            facturaView = Session["facturaView"] as FacturaView;

            var cl_cedula = int.Parse(Request["cl_cedula"]);
            if (cl_cedula == 0)
            {
                var lista = (db.Clientes.ToList());
                lista.Add(new Cliente { cl_cedula = 0, cl_nombre = "[Seleccione un Cliente]" });
                lista = lista.OrderBy(c => c.cl_nombre).ToList();
                ViewBag.cl_cedula = new SelectList(lista, "cl_cedula", "cl_nombre");
                ViewBag.Error = "Debe seleccionar un cliente";
                return View(facturaView);

            }
            //verificar si existe
            var cliente = db.Clientes.Find(cl_cedula);
            if (cliente == null)
            {
                 var lista = (db.Clientes.ToList());
                lista.Add(new Cliente { cl_cedula = 0, cl_nombre = "[Seleccione un Cliente]" });
                lista = lista.OrderBy(c => c.cl_nombre).ToList();
                ViewBag.cl_cedula = new SelectList(lista, "cl_cedula", "cl_nombre");
                ViewBag.Error = "Debe seleccionar un cliente";
                return View(facturaView);
            }
            //si hay productos
            if (facturaView.Inventarios.Count == 0)
            {
                var lista = (db.Clientes.ToList());
                lista.Add(new Cliente { cl_cedula = 0, cl_nombre = "[Seleccione un Cliente]" });
                lista = lista.OrderBy(c => c.cl_nombre).ToList();
                ViewBag.cl_cedula = new SelectList(lista, "cl_cedula", "cl_nombre");
                ViewBag.Error = "Debe seleccionar un Producto";
                return View(facturaView);
            }


            int facturaID = 0;
            

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    //grabar orden
                    var factura = new Factura
                    {
                        ft_Cliente = cl_cedula,
                        ft_fecha = DateTime.Now.Date,
                        ft_estampa = DateTime.Now.TimeOfDay,
                        FacturaEstados = FacturaEstados.Pendiente
                    };
                    db.Facturas.Add(factura);
                    db.SaveChanges();
                    var i = 1;

                    //recuperar el ultimo consecutivo para generar la orden
                    facturaID = db.Facturas.ToList().Select(o => o.ft_numero).Max();

                    foreach (var item in facturaView.Inventarios)
                    {
                        var DetalleFactura = new DetalleFactura
                        {
                            df_numeroLinea = i++,
                            df_codArticulo = item.in_codArticulo,
                            df_descripcion = item.in_descripcion,
                            df_precio = item.in_precio,
                            df_cantidad = item.Cantidad,
                            df_subtotal = item.SubTotal,
                            df_descuento = item.Descuento,
                            df_total = item.Total,
                            df_factura = facturaID
                        };
                        db.DetalleFacturas.Add(DetalleFactura);
                        db.SaveChanges();
                    }
                    transaction.Commit();


                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    ViewBag.Error = "Error: " + ex.Message;
                    var listaC = (db.Clientes.ToList());
                    listaC.Add(new Cliente { cl_cedula = 0, cl_nombre = "[Seleccione un Cliente]" });
                    listaC = listaC.OrderBy(c => c.cl_nombre).ToList();
                    ViewBag.cl_cedula = new SelectList(listaC, "cl_cedula", "cl_nombre");
                    return View(facturaView);               
                }

            }


            ViewBag.Message = string.Format("La orden: {0}, grabada ok", facturaID);

            var listaCU = (db.Clientes.ToList());
            listaCU.Add(new Cliente { cl_cedula = 0, cl_nombre = "[Seleccione un Cliente]" });
            listaCU = listaCU.OrderBy(c => c.cl_nombre).ToList();
            ViewBag.cl_cedula = new SelectList(listaCU, "cl_cedula", "cl_nombre");

            facturaView = new FacturaView();
            facturaView.Cliente = new Cliente();
            facturaView.Inventarios = new List<InventarioOrden>();
            Session["facturaView"] = facturaView;

            return View(facturaView);
        }

        public ActionResult AddProducto()
        {
            var lista = (db.Inventarios.ToList());
            lista.Add(new InventarioOrden { in_codArticulo = 0, in_descripcion = "[Seleccione un Producto]" });
            lista = lista.OrderBy(c => c.in_descripcion).ToList();
            ViewBag.in_codArticulo = new SelectList(lista, "in_codArticulo", "in_descripcion");
            return View();
        }
        [HttpPost]
        public ActionResult AddProducto(InventarioOrden inventarioOrden)
        {
            //convierte el producto seleccionado en una lista
            var facturaView = Session["facturaView"] as FacturaView;

            var in_codArticulo = int.Parse(Request["in_codArticulo"]);
            //verificar si selecciono
            if (in_codArticulo == 0)
            {
                var lista = (db.Inventarios.ToList());
                lista.Add(new InventarioOrden { in_codArticulo = 0, in_descripcion = "[Seleccione un Producto]" });
                lista = lista.OrderBy(c => c.in_descripcion).ToList();
                ViewBag.in_codArticulo = new SelectList(lista, "in_codArticulo", "in_descripcion");
                ViewBag.Error = "Debe Seleccionar un producto";
                return View(inventarioOrden);
            }
            //verificar si existe
            var inventario = db.Inventarios.Find(in_codArticulo);
            if (inventario == null)
            {
                var lista = (db.Inventarios.ToList());
                lista.Add(new InventarioOrden { in_codArticulo = 0, in_descripcion = "[Seleccione un Producto]" });
                lista = lista.OrderBy(c => c.in_descripcion).ToList();
                ViewBag.in_codArticulo = new SelectList(lista, "in_codArticulo", "in_descripcion");
                ViewBag.Error = "El Producto no existe";
                return View(inventarioOrden);
            }

            //buscar si ya existe
            inventarioOrden = facturaView.Inventarios.Find(p => p.in_codArticulo == in_codArticulo);
            if (inventarioOrden == null)
            {

                inventarioOrden = new InventarioOrden
                {
                    in_descripcion = inventario.in_descripcion ,
                    in_precio = inventario.in_precio,
                    in_codArticulo = inventario.in_codArticulo,
                    Cantidad = float.Parse(Request["Cantidad"]),                    
                    Descuento = float.Parse(Request["Descuento"])

                };
                facturaView.Inventarios.Add(inventarioOrden);
            }
            else
            {
                inventarioOrden.Cantidad += float.Parse(Request["Cantidad"]);
            }

            var listaC = (db.Clientes.ToList());
            listaC.Add(new Cliente { cl_cedula = 0, cl_nombre = "[Seleccione un Cliente]" });
            listaC = listaC.OrderBy(c => c.cl_nombre).ToList();
            ViewBag.cl_cedula = new SelectList(listaC, "cl_cedula", "cl_nombre");


            return View("NuevaFactura", facturaView);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}


