using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using ProductosDB.Entities;

namespace ProductosDB
{
    public class Repositorio
    {
        SqlConnection _CtxProductos = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionProductos"].ConnectionString);

        public List<Productos> GetProductos()
        {
            List<Productos> Lista = new List<Productos>();

            Lista = _CtxProductos.Query<Productos>("SELECT Id, Nombre, TipoProductoId, Proveedor, CreadoEl, CreadoPor, ModificadoEn, ModificadoPor FROM Productos").ToList();

            return Lista;
        }

        public List<TipoProducto> GetTipoProducto()
        {
            List<TipoProducto> Lista = _CtxProductos.Query<TipoProducto>("SELECT Id, Descripcion FROM TipoProducto").ToList();

            return Lista;
        }

        public Respuesta InsertProducto(Productos producto)
        {
            Respuesta result = new Respuesta();

            try
            {
                var sql = @"INSERT INTO Productos (Nombre, TipoProductoId, Proveedor, CreadoEl, CreadoPor, ModificadoEn, ModificadoPor) 
                            VALUES (@Nombre, @TipoProductoId, @Proveedor, GETDATE(), @CreadoPor, GETDATE(), @ModificadoPor);
                            SELECT CAST(SCOPE_IDENTITY() as int)";

                result.Id = _CtxProductos.Query<int>(sql, producto).Single();
                result.Exitoso = true;
                result.Mensaje = "Se insertó correctamente el producto";
            }
            catch (Exception e)
            {
                result.Exitoso = false;
                result.Mensaje = e.Message;
            }

            return result;
        }

        public Respuesta ActualizarProducto(Productos producto)
        {
            Respuesta result = new Respuesta();

            try
            {
                var sql = @"UPDATE Productos SET 
                            Nombre = @Nombre, 
                            TipoProductoId = @TipoProductoId, 
                            Proveedor = @Proveedor, 
                            ModificadoEn = GETDATE(), 
                            ModificadoPor = @ModificadoPor 
                            WHERE Id = @Id";

                _CtxProductos.Execute(sql, new
                {
                    Nombre = producto.Nombre,
                    TipoProductoId = producto.TipoProductoId,
                    Proveedor = producto.Proveedor,
                    ModificadoPor = producto.ModificadoPor,
                    Id = producto.Id
                });

                result.Exitoso = true;
                result.Mensaje = "Se actualizó correctamente el producto";
            }
            catch (Exception e)
            {
                result.Exitoso = false;
                result.Mensaje = e.Message;
            }

            return result;
        }

        public Respuesta EliminarProducto(int idProducto)
        {
            Respuesta result = new Respuesta();

            try
            {
                var sql = @"DELETE FROM Productos WHERE Id = @Id";

                _CtxProductos.Execute(sql, new { Id = idProducto });

                result.Exitoso = true;
                result.Mensaje = "Se eliminó correctamente el producto";
            }
            catch (Exception e)
            {
                result.Exitoso = false;
                result.Mensaje = e.Message;
            }

            return result;
        }
    }
}
