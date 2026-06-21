using System;
using System.Data;
using Restaurant.Datos;

namespace Restaurant.Negocio
{
    public class ReporteBLL
    {
        private readonly ReporteDAO _dao = new ReporteDAO();

        public DataTable VentasPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            if (fechaInicio > fechaFin)
                throw new ApplicationException("La fecha de inicio no puede ser mayor que la fecha fin.");
            return _dao.VentasPorFecha(fechaInicio, fechaFin);
        }

        public DataTable PlatosMasVendidos(DateTime fechaInicio, DateTime fechaFin)
        {
            if (fechaInicio > fechaFin)
                throw new ApplicationException("La fecha de inicio no puede ser mayor que la fecha fin.");
            return _dao.PlatosMasVendidos(fechaInicio, fechaFin);
        }

        public DataTable VentasPorEmpleado(DateTime fechaInicio, DateTime fechaFin)
        {
            if (fechaInicio > fechaFin)
                throw new ApplicationException("La fecha de inicio no puede ser mayor que la fecha fin.");
            return _dao.VentasPorEmpleado(fechaInicio, fechaFin);
        }

        public DataTable ReporteClientes(DateTime fechaInicio, DateTime fechaFin)
        {
            if (fechaInicio > fechaFin)
                throw new ApplicationException("La fecha de inicio no puede ser mayor que la fecha fin.");
            return _dao.ReporteClientes(fechaInicio, fechaFin);
        }
    }
}
