---
tags: [DSE, capa, presentacion, winforms, tema2]
---
# Capa de Presentación (Forms)

Proyecto `Restaurant.Presentacion`. Es **lo que ve y toca el usuario** (el mozo 🖥️). Hecha con
**Windows Forms** (Tema 2). Habla con la [[Capa de Negocio (BLL)]].

## Formularios del sistema
- `FrmLogin` — inicio de sesión
- `FrmPrincipal` — menú principal (MDI) → ver [[Programa y MDI]]
- `FrmCategoria`, `FrmPlato`, `FrmMesa`, `FrmEmpleado`, `FrmCliente` — mantenimientos (CRUD)
- `FrmPedido` — comanda maestro-detalle
- `FrmFacturacion` — boleta/factura (usa `DataView`)
- `FrmReporteVentas` — reporte por fechas

## Para entender un Form, 4 sub-temas
1. [[Anatomía de un Formulario]] — los 2 archivos y `partial class`
2. [[Archivo Designer]] — cómo se construyen los controles
3. [[Archivo de lógica del Form]] — campos, constructor y `Load`
4. [[Eventos del Formulario]] — Guardar, Eliminar, clic en la grilla

Extras: [[ComboBox enlazado]] · [[Programa y MDI]]

## 🔗 Relaciones
- Le pide datos a: [[Capa de Negocio (BLL)]]
- Muestra/transporta: [[Capa de Entidades]]
- Recibe el dato final del: [[Flujo de datos]]
- Tema del curso: [[Temas del curso (T1-T6)]] (Tema 2)
- Volver al [[Índice]]
