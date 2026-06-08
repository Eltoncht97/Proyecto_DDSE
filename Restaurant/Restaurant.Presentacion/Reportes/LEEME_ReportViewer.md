# Reporte RDLC con ReportViewer (Tema 6)

El formulario **FrmReporteVentas** muestra el reporte de ventas en un `DataGridView`
para que la solución **compile y se ejecute sin dependencias externas**. El archivo
de diseño `ReporteVentas.rdlc` se incluye como artefacto del Tema 6.

Para mostrar el reporte con el visor **ReportViewer** (tal como se enseña en el Tema 6),
sigue estos pasos en Visual Studio:

## 1. Agregar el paquete ReportViewer
Menú **Proyecto → Administrar paquetes NuGet** en `Restaurant.Presentacion` e instala:

```
Microsoft.ReportingServices.ReportViewerControl.Winforms
```

> Este paquete requiere `.NET Framework 4.7.2` o superior. Si tu proyecto está en
> 4.5, Visual Studio te pedirá reorientar (retarget) el proyecto de presentación.

## 2. Colocar el control en el formulario
Arrastra un control **ReportViewer** al `FrmReporteVentas` (por ejemplo `reportViewer1`)
y marca `ReporteVentas.rdlc` con **Acción de compilación = Recurso incrustado**
(Embedded Resource).

## 3. Cargar el reporte (código del Tema 6)
Reemplaza el cuerpo de `btnGenerar_Click` por:

```csharp
using Microsoft.Reporting.WinForms;

private void btnGenerar_Click(object sender, EventArgs e)
{
    DataTable dt = _bll.VentasPorFecha(dtpDesde.Value.Date, dtpHasta.Value.Date);

    // 1. Origen de datos del reporte
    ReportDataSource fuente = new ReportDataSource("DataSetVentas", dt);

    // 2. Configurar el ReportViewer
    reportViewer1.LocalReport.ReportEmbeddedResource =
        "Restaurant.Presentacion.Reportes.ReporteVentas.rdlc";
    reportViewer1.LocalReport.DataSources.Clear();
    reportViewer1.LocalReport.DataSources.Add(fuente);

    // 3. Renderizar
    reportViewer1.RefreshReport();
}
```

El nombre del DataSet del RDLC (`DataSetVentas`) debe coincidir exactamente con el
primer parámetro de `ReportDataSource`, tal como indica la buena práctica del Tema 6.
