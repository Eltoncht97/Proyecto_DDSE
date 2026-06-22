---
tags: [DSE, mapa, codigo, navegacion, MOC]
---
# 🗺️ Mapa de Código — ¿Dónde está cada cosa?

Índice navegable de **todo el código** del sistema. Sirve para encontrar al instante dónde está el
código de cualquier **ventana**, **botón**, regla de negocio, acceso a datos o procedimiento almacenado.

> [!tip] Cómo leer las rutas
> - Las rutas son **relativas a** `restaurant/src/Restaurant/` y tienen el formato `archivo:línea`.
>   Ejemplo: `Restaurant.Presentacion/FrmUsuario.cs:97` = archivo `FrmUsuario.cs`, **línea 97**.
> - Desde este vault, el código está en la carpeta hermana: `../Restaurant/...`.
> - En **Visual Studio / VS Code** abre el archivo y pulsa **Ctrl+G** para saltar a la línea.
> - Cada ventana tiene **2 archivos**: `FrmX.cs` (lógica, eventos) y `FrmX.Designer.cs` (controles y diseño).
>   El código de un **botón** casi siempre está en el `.cs` (su método `..._Click`). Ver [[Anatomía de un Formulario]].

## 🔎 Atajos rápidos

| Si busco… | Voy a… |
|---|---|
| El código de un **botón** de una ventana | la sección de esa ventana → tabla **“Botones y acciones”** |
| Qué ventana abre un **menú** | [[#🚀 Arranque y navegación]] → tabla **Menús → ventana** |
| Qué ve cada **rol** | [[#🔐 Permisos por rol]] |
| Una **regla/validación** o el cálculo del **total / IGV** | [[#🧠 Capa de Negocio (BLL)]] |
| Qué **procedimiento almacenado** usa un método | [[#🗄️ Capa de Datos (DAO)]] |
| Dónde se **define un SP** en el `.sql` | [[#🛢️ Base de datos (procedimientos y tablas)]] |
| Los **estilos** o los **iconos** de botones | [[#🎨 Estilos e iconos]] |

> Conceptos relacionados: [[Arquitectura multicapa]] · [[Capa de Presentación (Forms)]] · [[Capa de Negocio (BLL)]] · [[Capa de Datos (DAO)]] · [[Flujo de datos]]

---

## 🚀 Arranque y navegación

**Flujo de arranque:** `Program.Main` (`Restaurant.Presentacion/Program.cs:12`) habilita estilos
(`Program.cs:14-15`) → muestra `FrmLogin` con `login.ShowDialog()` (`Program.cs:17-19`). El login válido
guarda el usuario en `Program.UsuarioActual` (campo estático `Program.cs:9`, asignado en `FrmLogin.cs:37`).
Si el diálogo devuelve `OK`, se ejecuta `Application.Run(new FrmPrincipal())` (`Program.cs:21`). Luego
`FrmPrincipal_Load` (`FrmPrincipal.cs:18`) muestra usuario/rol y aplica permisos. Ver [[Programa y MDI]].

**Menús → ventana que abren** (todos los handlers están en `Restaurant.Presentacion/FrmPrincipal.cs`):

| Ítem de menú | Handler (archivo:línea) | Abre ventana |
|---|---|---|
| Mantenimientos → Categorías | `FrmPrincipal.cs:159` | FrmCategoria |
| Mantenimientos → Platos (Carta) | `FrmPrincipal.cs:160` | FrmPlato |
| Mantenimientos → Mesas | `FrmPrincipal.cs:161` | FrmMesa |
| Mantenimientos → Empleados | `FrmPrincipal.cs:162` | FrmEmpleado |
| Mantenimientos → Clientes | `FrmPrincipal.cs:163` | FrmCliente |
| Mantenimientos → Usuarios | `FrmPrincipal.cs:164` | FrmUsuario |
| Cocina → Pedidos | `FrmPrincipal.cs:165` | FrmCocinero |
| Operaciones → Registrar Pedido | `FrmPrincipal.cs:166` | FrmPedido |
| Operaciones → Facturación | `FrmPrincipal.cs:167` | FrmFacturacion |
| Reportes → Reporte de Ventas | `FrmPrincipal.cs:168` | FrmReporteVentas |
| Reportes → Platos más vendidos | `FrmPrincipal.cs:169` | FrmReportePlatosVendidos |
| Reportes → Ventas por Empleado | `FrmPrincipal.cs:170` | FrmReporteEmpleados |
| Reportes → Reporte de Clientes | `FrmPrincipal.cs:171` | FrmReporteClientes |
| Salir | `FrmPrincipal.cs:173` | (no abre; `Application.Exit()`) |

**Helpers de FrmPrincipal:** `AbrirHijo` abre/activa la ventana MDI (`FrmPrincipal.cs:144`) ·
`AplicarFondo` pinta el fondo (`FrmPrincipal.cs:84`) · `AplicarPermisos` (`FrmPrincipal.cs:36`).

### 🔐 Permisos por rol

Lógica en `AplicarPermisos()` (`Restaurant.Presentacion/FrmPrincipal.cs:36`); los menús raíz se ocultan si
no tienen hijos visibles vía `TieneHijoVisible()` (`FrmPrincipal.cs:77`).

| Rol | Qué ve | Notas |
|---|---|---|
| **Administrador** | Todo (los 6 mantenimientos, Operaciones, los 4 Reportes y Cocina) | Acceso completo (`FrmPrincipal.cs:45-64`) |
| **Cajero** | Clientes, Mesas, Registrar Pedido, Facturación y los 4 Reportes | Sin Categorías/Platos/Empleados/Usuarios ni Cocina |
| **Mozo** | Clientes, Mesas, Registrar Pedido | Sin Facturación, sin Reportes, sin Cocina |
| **Cocinero** | Solo Cocina → Pedidos | Abre `FrmCocinero` automáticamente al entrar (`FrmPrincipal.cs:73-74`) |

---

## 🪟 Ventanas (una sección por formulario)

> Carpeta de todas las ventanas: `Restaurant.Presentacion/`. Patrón común: el `Load` estiliza con
> [[Tema Moderno|TemaModerno]], el clic en la grilla (`dgvLista_CellClick`) carga la fila al formulario y
> `btnGuardar` decide entre **Registrar** (alta) o **Modificar** (edición) según `_idActual`/`_idPedido`.

### FrmLogin — inicio de sesión
- **Archivos:** `Restaurant.Presentacion/FrmLogin.cs` · `FrmLogin.Designer.cs`
- **BLL:** `UsuarioBLL` (`FrmLogin.cs:12`) · **Se abre:** automático al arranque (`Program.cs:17-19`)

| Botón | Variable | Handler (archivo:línea) | Qué hace |
|---|---|---|---|
| Ingresar | btnIngresar | `FrmLogin.cs:32` | `_bll.IniciarSesion(usuario, clave)` → guarda `Program.UsuarioActual`, `DialogResult.OK` |
| Cancelar | btnCancelar | `FrmLogin.cs:49` | `DialogResult.Cancel` y cierra |

Otros: `FrmLogin_Load` (`FrmLogin.cs:19`). Controles: `txtUsuario` (`Designer.cs:53`), `txtClave` (PasswordChar, `Designer.cs:68`).

### FrmCategoria — CRUD de categorías
- **Archivos:** `Restaurant.Presentacion/FrmCategoria.cs` · `FrmCategoria.Designer.cs` · **BLL:** `CategoriaBLL` (`FrmCategoria.cs:12`)

| Botón | Variable | Handler (archivo:línea) | Qué hace |
|---|---|---|---|
| ✏️ Nuevo | btnNuevo | `FrmCategoria.cs:81` | `LimpiarFormulario()` |
| 💾 Guardar | btnGuardar | `FrmCategoria.cs:86` | `_bll.Registrar` (si `_idActual==0`) o `_bll.Modificar`, luego `Listar()` |
| 🗑️ Eliminar | btnEliminar | `FrmCategoria.cs:120` | Confirma y `_bll.Eliminar(_idActual)` (baja lógica) |
| ❌ Cancelar | btnCancelar | `FrmCategoria.cs:145` | `LimpiarFormulario()` |

Otros: `FrmCategoria_Load` (`:20`) · `dgvLista_CellClick` (`:70`) · `Listar` (`:45`) · `LimpiarFormulario` (`:61`).
Controles: `txtNombre`, `txtDescripcion`, `chkEstado`, `dgvLista`.

### FrmCliente — CRUD de clientes
- **Archivos:** `Restaurant.Presentacion/FrmCliente.cs` · `FrmCliente.Designer.cs` · **BLL:** `ClienteBLL` (`FrmCliente.cs:12`)

| Botón | Variable | Handler (archivo:línea) | Qué hace |
|---|---|---|---|
| ✏️ Nuevo | btnNuevo | `FrmCliente.cs:95` | `LimpiarFormulario()` |
| 💾 Guardar | btnGuardar | `FrmCliente.cs:100` | `_bll.Registrar` o `_bll.Modificar`, luego `Listar()` |
| 🗑️ Eliminar | btnEliminar | `FrmCliente.cs:138` | Confirma y `_bll.Eliminar(_idActual)` |
| ❌ Cancelar | btnCancelar | `FrmCliente.cs:163` | `LimpiarFormulario()` |

Otros: `FrmCliente_Load` (`:20`) · `dgvLista_CellClick` (`:81`) · `Listar` (`:48`) · `LimpiarFormulario` (`:68`).
Controles: `txtNombres`, `txtApellidos`, `txtDocumento`, `txtTelefono`, `txtCorreo`, `txtDireccion`, `chkEstado`, `dgvLista`.

### FrmEmpleado — CRUD de empleados
- **Archivos:** `Restaurant.Presentacion/FrmEmpleado.cs` · `FrmEmpleado.Designer.cs` · **BLL:** `EmpleadoBLL` (`FrmEmpleado.cs:12`)

| Botón | Variable | Handler (archivo:línea) | Qué hace |
|---|---|---|---|
| ✏️ Nuevo | btnNuevo | `FrmEmpleado.cs:93` | `LimpiarFormulario()` |
| 💾 Guardar | btnGuardar | `FrmEmpleado.cs:98` | `_bll.Registrar` o `_bll.Modificar` |
| 🗑️ Eliminar | btnEliminar | `FrmEmpleado.cs:135` | Confirma y `_bll.Eliminar(_idActual)` |
| ❌ Cancelar | btnCancelar | `FrmEmpleado.cs:160` | `LimpiarFormulario()` |

Otros: `FrmEmpleado_Load` (`:20`) · `dgvLista_CellClick` (`:79`) · `Listar` (`:48`) · `LimpiarFormulario` (`:67`).
Controles: `txtNombres`, `txtApellidos`, `txtDni`, `cboCargo` (Mozo/Cajero/Cocinero/Administrador, items en `FrmEmpleado.cs:40`), `txtTelefono`, `chkEstado`, `dgvLista`.

### FrmMesa — CRUD de mesas
- **Archivos:** `Restaurant.Presentacion/FrmMesa.cs` · `FrmMesa.Designer.cs` · **BLL:** `MesaBLL` (`FrmMesa.cs:12`)

| Botón | Variable | Handler (archivo:línea) | Qué hace |
|---|---|---|---|
| ✏️ Nuevo | btnNuevo | `FrmMesa.cs:89` | `LimpiarFormulario()` |
| 💾 Guardar | btnGuardar | `FrmMesa.cs:94` | `_bll.Registrar` o `_bll.Modificar` |
| 🗑️ Eliminar | btnEliminar | `FrmMesa.cs:130` | Confirma y `_bll.Eliminar(_idActual)` |
| ❌ Cancelar | btnCancelar | `FrmMesa.cs:155` | `LimpiarFormulario()` |

Otros: `FrmMesa_Load` (`:20`) · `dgvLista_CellClick` (`:76`) · `Listar` (`:47`) · `LimpiarFormulario` (`:65`).
Controles: `nudNumero`, `nudCapacidad`, `txtUbicacion`, `cboSituacion` (Libre/Ocupada/Reservada, items en `FrmMesa.cs:39`), `chkEstado`, `dgvLista`.

### FrmPlato — CRUD de platos (carta)
- **Archivos:** `Restaurant.Presentacion/FrmPlato.cs` · `FrmPlato.Designer.cs` · **BLL:** `PlatoBLL` (`:12`) + `CategoriaBLL` (`:13`)

| Botón | Variable | Handler (archivo:línea) | Qué hace |
|---|---|---|---|
| ✏️ Nuevo | btnNuevo | `FrmPlato.cs:104` | `LimpiarFormulario()` |
| 💾 Guardar | btnGuardar | `FrmPlato.cs:109` | `_bll.Registrar` o `_bll.Modificar` |
| 🗑️ Eliminar | btnEliminar | `FrmPlato.cs:146` | Confirma y `_bll.Eliminar(_idActual)` |
| ❌ Cancelar | btnCancelar | `FrmPlato.cs:171` | `LimpiarFormulario()` |

Otros: `FrmPlato_Load` (`:21`) · `dgvLista_CellClick` (`:90`) · `CargarCategorias` (`:49`) · `Listar` (`:57`) · `LimpiarFormulario` (`:78`).
Controles: `cboCategoria`, `txtNombre`, `txtDescripcion`, `nudPrecio`, `chkDisponible`, `chkEstado`, `dgvLista`.

### FrmUsuario — CRUD de usuarios del sistema
- **Archivos:** `Restaurant.Presentacion/FrmUsuario.cs` · `FrmUsuario.Designer.cs` · **BLL:** `UsuarioBLL` (`FrmUsuario.cs:12`)

| Botón | Variable | Handler (archivo:línea) | Qué hace |
|---|---|---|---|
| ✏️ Nuevo | btnNuevo | `FrmUsuario.cs:92` | `LimpiarFormulario()` |
| 💾 Guardar | btnGuardar | `FrmUsuario.cs:97` | `_bll.Registrar` o `_bll.Modificar` |
| 🗑️ Eliminar | btnEliminar | `FrmUsuario.cs:133` | Confirma y `_bll.Eliminar(_idActual)` |
| ❌ Cancelar | btnCancelar | `FrmUsuario.cs:158` | `LimpiarFormulario()` |

Otros: `FrmUsuario_Load` (`:20`) · `dgvLista_CellClick` (`:79`) · `Listar` (`:50`) · `FormatearGrilla` oculta la columna `Clave` (`:56`) · `LimpiarFormulario` (`:68`).
Controles: `txtUsuario`, `txtClave` (PasswordChar `*`), `txtNombre`, `cboRol` (Administrador/Cajero/Mozo/Cocinero, items en `FrmUsuario.cs:40`), `chkEstado`, `dgvLista`.

### FrmPedido — comanda (maestro-detalle) ⭐
- **Archivos:** `Restaurant.Presentacion/FrmPedido.cs` · `FrmPedido.Designer.cs`
- **BLL:** `PedidoBLL` (`:14`), `MesaBLL` (`:15`), `EmpleadoBLL` (`:16`), `ClienteBLL` (`:17`), `PlatoBLL` (`:18`)

| Botón | Variable | Handler (archivo:línea) | Qué hace |
|---|---|---|---|
| ➕ Agregar | btnAgregar | `FrmPedido.cs:93` | Agrega plato al detalle `_detalle`; si ya existe acumula cantidad (`:109-114`) |
| ➖ Quitar | btnQuitar | `FrmPedido.cs:133` | Quita la línea seleccionada de `_detalle` |
| 💾 Registrar / Actualizar | btnRegistrar | `FrmPedido.cs:150` | Arma `Pedido`; `_pedidoBll.RegistrarPedido` (`:167`) o `ActualizarPedido` (`:173`) |
| ✏️ Nuevo | btnNuevo | `FrmPedido.cs:187` | `Limpiar()` |
| Cargar | btnCargar | `FrmPedido.cs:203` | Carga el pedido elegido en `cboBuscarPedido` para editarlo (`CargarPedido`, `:211`) |

Otros: `FrmPedido_Load` (`:28`) · helpers `FormatearDetalle` (`:78`), `ActualizarTotal` (`:144`), `CargarPedidos` (`:193`), `CargarPedido` (`:215`), `Limpiar` (`:243`).
Controles: `cboMesa`, `cboMozo`, `cboCliente`, `cboPlato`, `nudCantidad`, `dgvDetalle` (enlazado a `BindingList<DetallePedido> _detalle`), `lblTotal`, `cboBuscarPedido`.

### FrmFacturacion — boleta/factura con IGV ⭐
- **Archivos:** `Restaurant.Presentacion/FrmFacturacion.cs` · `FrmFacturacion.Designer.cs`
- **BLL:** `PedidoBLL` (`:13`) · `ComprobanteBLL` (`:14`)

| Botón | Variable | Handler (archivo:línea) | Qué hace |
|---|---|---|---|
| 📄 Facturar | btnFacturar | `FrmFacturacion.cs:105` | `_comprobanteBll.Generar(_idPedidoSel, tipo, _totalSel)` (`:117`); muestra serie-número, subtotal, IGV y total |
| 🔄 Refrescar | btnRefrescar | `FrmFacturacion.cs:136` | `ListarPendientes()` |

Otros: `FrmFacturacion_Load` (`:24`) · `dgvPedidos_CellClick` (`:77`).
Clave: `ListarPendientes` usa un **DataView** con `RowFilter "Situacion <> 'Pagado' AND Situacion <> 'Anulado'"` (`FrmFacturacion.cs:50`) → ver [[ADO.NET conectado y desconectado]] · `CargarDetalle` (`:88`).
Campos: `_idPedidoSel` (`:16`), `_totalSel` (`:17`). Controles: `dgvPedidos`, `dgvDetalle`, `cboTipo` (Boleta/Factura), `lblTotal`.

### FrmCocinero — cocina: pedidos en preparación ⭐
- **Archivos:** `Restaurant.Presentacion/FrmCocinero.cs` · `FrmCocinero.Designer.cs` · **BLL:** `PedidoBLL` (`FrmCocinero.cs:12`)

| Botón | Variable | Handler (archivo:línea) | Qué hace |
|---|---|---|---|
| ✓ Marcar Servido | btnServido | `FrmCocinero.cs:109` | `CambiarEstado("Servido")` |
| ↺ Marcar Solicitado | btnSolicitado | `FrmCocinero.cs:114` | `CambiarEstado("Solicitado")` |
| 🔄 Refrescar | btnRefrescar | `FrmCocinero.cs:140` | `CargarPedidos()` |

Otros: `FrmCocinero_Load` (`:20`) · `dgvPedidos_SelectionChanged` (`:77`).
Helpers: `CargarPedidos` (`:38`, llama `_bll.ListarEnPreparacion()` en `:41`), `FormatearPedidos` (`:47`), `SeleccionarPedido` (`:62`), `CargarDetalle` (`:82`, llama `_bll.ObtenerDetalle()` en `:92`), `FormatearDetalle` (`:96`), `CambiarEstado` (`:119`, llama `_bll.CambiarEstadoDetalle()` en `:131`).
Controles: `dgvPedidos` (master), `dgvDetalle` (líneas con columna `EstadoDetalle`).

### Reportes (los 4) — por rango de fechas
Las 4 ventanas comparten **la misma estructura y líneas**: campo `_bll` en `:12`, `Load` en `:19` (fija
`dtpDesde` = 1.º del mes y `dtpHasta` = hoy, `:31-32`), botón **📋 Generar** `btnGenerar_Click` en `:38`
(llama al BLL en `:42`, asigna la grilla en `:43`). Archivos en `Restaurant.Presentacion/`. **BLL:** `ReporteBLL`.

| Ventana | Archivo | Método BLL (`:42`) | Totaliza con (`DataTable.Compute`) |
|---|---|---|---|
| FrmReporteVentas | `FrmReporteVentas.cs` | `_bll.VentasPorFecha(...)` | `SUM(Total)` (`:47`) |
| FrmReportePlatosVendidos | `FrmReportePlatosVendidos.cs` | `_bll.PlatosMasVendidos(...)` | `SUM(TotalIngreso)` (`:46`) |
| FrmReporteEmpleados | `FrmReporteEmpleados.cs` | `_bll.VentasPorEmpleado(...)` | `SUM(TotalVentas)` (`:46`) |
| FrmReporteClientes | `FrmReporteClientes.cs` | `_bll.ReporteClientes(...)` | `SUM(TotalGastado)` (`:46`) |

Controles (todas): `dtpDesde`, `dtpHasta`, `btnGenerar`, `dgvReporte`, `lblRegistros`, `lblTotal`. `FormatearGrilla` en `:57` (`FrmReporteVentas` en `:58`).

---

## 🧠 Capa de Negocio (BLL)

Carpeta `Restaurant.Negocio/`. Cada BLL tiene su DAO como campo `_dao` y valida (lanza
`ApplicationException`) antes de delegar. Ver [[Capa de Negocio (BLL)]] · [[LINQ y lambdas]].

> [!important] Cálculos clave
> - **Total del pedido (LINQ):** `PedidoBLL.cs:26` (en `RegistrarPedido`) y `PedidoBLL.cs:98` (en `ActualizarPedido`) → `pedido.Total = pedido.Detalles.Sum(d => d.Subtotal);`
> - **IGV 18%:** constante `TasaIgv = 0.18m` en `ComprobanteBLL.cs:9`; desglose en `ComprobanteBLL.cs:27` (SubTotal = Total / 1.18) y `:28` (Igv = Total − SubTotal).

| BLL | Archivo | Métodos clave (línea) |
|---|---|---|
| CategoriaBLL | `Restaurant.Negocio/CategoriaBLL.cs` | `ListarTabla` (19) · `ListarActivas` LINQ (24) · `Buscar` LINQ (29) · `Registrar` (37) · `Modificar` (43) · `Eliminar` (51) · `Validar` (58) |
| PlatoBLL | `Restaurant.Negocio/PlatoBLL.cs` | `ListarDisponiblesPorCategoria` LINQ (24) · `ListarDisponibles` LINQ (32) · `Registrar` (37) · `Modificar` (43) · `Eliminar` (51) · `Validar` (58) |
| MesaBLL | `Restaurant.Negocio/MesaBLL.cs` | `ListarActivas` LINQ (24) · `Registrar` (29) · `Modificar` (35) · `Eliminar` (43) · `Validar` (50) |
| EmpleadoBLL | `Restaurant.Negocio/EmpleadoBLL.cs` | `ListarMozos` LINQ (24) · `Registrar` (32) · `Modificar` (38) · `Eliminar` (46) · `Validar` DNI 8 díg. (53) |
| ClienteBLL | `Restaurant.Negocio/ClienteBLL.cs` | `ListarActivos` LINQ (24) · `Registrar` (29) · `Modificar` (35) · `Eliminar` (43) · `Validar` (50) |
| UsuarioBLL | `Restaurant.Negocio/UsuarioBLL.cs` | `IniciarSesion` (13) · `ListarTabla` (32) · `Registrar` (37) · `Modificar` (43) · `Eliminar` (51) · `Validar` (58) |
| PedidoBLL | `Restaurant.Negocio/PedidoBLL.cs` | `RegistrarPedido` (14) · `ObtenerDetalle` (44) · `ListarEnPreparacion` (56) · `CambiarEstadoDetalle` (61) · `ObtenerPorId` (71) · `ActualizarPedido` (84) |
| ComprobanteBLL | `Restaurant.Negocio/ComprobanteBLL.cs` | `TasaIgv` const (9) · `Generar` (12) |
| ReporteBLL | `Restaurant.Negocio/ReporteBLL.cs` | `VentasPorFecha` (11) · `PlatosMasVendidos` (18) · `VentasPorEmpleado` (25) · `ReporteClientes` (32) — validan `fechaInicio <= fechaFin` |

---

## 🗄️ Capa de Datos (DAO)

Carpeta `Restaurant.Datos/`. Todos los `SqlCommand` son `CommandType.StoredProcedure` (anti inyección SQL,
ver [[Parámetros e inyección SQL]]). Ver [[Capa de Datos (DAO)]] · [[ADO.NET conectado y desconectado]].

- **Cadena de conexión:** `Restaurant.Datos/Conexion.cs:9-10` (`Data Source=.;Initial Catalog=RestaurantDB;Integrated Security=True`) · `Obtener()` en `:12`. Ver [[Cadena de conexión]].
- **Transacciones (`SqlTransaction`)** — solo en `PedidoDAO`: `Registrar` (Begin `:16`, Commit `:42`, Rollback `:47`) y `Actualizar` (Begin `:198`, Commit `:226`, Rollback `:230`). Ver [[Transacción (Commit y Rollback)]].

| DAO | Método (línea) → Procedimiento almacenado |
|---|---|
| CategoriaDAO | `Listar` (11) / `ListarTabla` (36) → `usp_Categoria_Listar` · `Insertar` (49) → `usp_Categoria_Insertar` · `Actualizar` (63) → `usp_Categoria_Actualizar` · `Eliminar` (78) → `usp_Categoria_Eliminar` |
| PlatoDAO | `Listar` (11) / `ListarTabla` (40) → `usp_Plato_Listar` · `Insertar` (53) · `Actualizar` (70) · `Eliminar` (88) |
| MesaDAO | `Listar` (11) / `ListarTabla` (38) → `usp_Mesa_Listar` · `Insertar` (51) · `Actualizar` (67) · `Eliminar` (84) |
| EmpleadoDAO | `Listar` (11) / `ListarTabla` (39) → `usp_Empleado_Listar` · `Insertar` (52) · `Actualizar` (69) · `Eliminar` (87) |
| ClienteDAO | `Listar` (11) / `ListarTabla` (40) → `usp_Cliente_Listar` · `Insertar` (53) · `Actualizar` (71) · `Eliminar` (90) |
| UsuarioDAO | `Listar` (11) / `ListarTabla` (38) → `usp_Usuario_Listar` · `Insertar` (51) · `Actualizar` (67) · `Eliminar` (84) · `Validar` (96) → `usp_Usuario_Validar` (login) |
| PedidoDAO | `Registrar` (11, **transacción**) → `usp_Pedido_Insertar`+`usp_DetallePedido_Insertar` · `Listar`/`ListarTabla` (53/81) → `usp_Pedido_Listar` · `ObtenerDetalle` (94) → `usp_Pedido_ObtenerDetalle` · `ListarEnPreparacion` (124) → `usp_Pedido_ListarEnPreparacion` · `CambiarEstadoDetalle` (137) → `usp_DetallePedido_CambiarEstado` · `CambiarSituacion` (150) → `usp_Pedido_CambiarSituacion` · `ObtenerPorId` (163) → `usp_Pedido_ObtenerPorId` · `Actualizar` (193, **transacción**) → `usp_Pedido_Actualizar`+… |
| ComprobanteDAO | `Registrar` (10) → `usp_Comprobante_Insertar` |
| ReporteDAO | `VentasPorFecha` (9) · `PlatosMasVendidos` (24) · `VentasPorEmpleado` (39) · `ReporteClientes` (54) → SPs `usp_Reporte_*` |

> **Modo conectado vs desconectado:** los `Listar`/`Validar`/`Obtener*` usan `SqlDataReader` (conectado);
> los `ListarTabla`/reportes/`ListarEnPreparacion` usan `SqlDataAdapter.Fill` → `DataTable` (desconectado).

---

## 🛢️ Base de datos (procedimientos y tablas)

Scripts en `database/`. **40 procedimientos almacenados** definidos en `01_RestaurantDB.sql`; **7 se
redefinen** (`CREATE OR ALTER`) en `02_Usuarios_Cocina.sql` (migración de Usuarios + Cocina). Ver
[[Procedimientos almacenados]].

| Procedimiento | Definido en (archivo:línea) |
|---|---|
| **Categoría** | Listar `01:157` · Insertar `01:166` · Actualizar `01:176` · Eliminar `01:186` |
| **Plato** | Listar `01:198` · Insertar `01:209` · Actualizar `01:220` · Eliminar `01:232` |
| **Mesa** | Listar `01:243` · Insertar `01:251` · Actualizar `01:261` · Eliminar `01:272` |
| **Empleado** | Listar `01:283` · Insertar `01:291` · Actualizar `01:302` · Eliminar `01:314` |
| **Cliente** | Listar `01:325` · Insertar `01:333` · Actualizar `01:344` · Eliminar `01:356` |
| **Pedido/Detalle** | Pedido_Insertar `01:367` · DetallePedido_Insertar `01:378` · Pedido_Listar `01:387` · Pedido_ObtenerDetalle `01:402` ⚠️`02:16` · Pedido_CambiarSituacion `01:414` · Pedido_ObtenerPorId `01:422` · Pedido_Actualizar `01:432` · DetallePedido_EliminarPorPedido `01:442` |
| **Cocina** | DetallePedido_CambiarEstado `01:453` ⚠️`02:30` · Pedido_ListarEnPreparacion `01:461` ⚠️`02:40` |
| **Comprobante** | Comprobante_Insertar `01:484` (genera correlativo, marca pedido 'Pagado') |
| **Usuario/Login** | Usuario_Validar `01:504` · Usuario_Listar `01:517` ⚠️`02:62` · Usuario_Insertar `01:526` ⚠️`02:71` · Usuario_Actualizar `01:537` ⚠️`02:82` · Usuario_Eliminar `01:549` ⚠️`02:94` |
| **Reportes** | VentasPorFecha `01:560` · PlatosMasVendidos `01:584` · VentasPorEmpleado `01:607` · Clientes `01:627` |

⚠️ = redefinido en `02_Usuarios_Cocina.sql`. (`01` = `database/01_RestaurantDB.sql`, `02` = `database/02_Usuarios_Cocina.sql`.)

**Tablas (`CREATE TABLE` en `database/01_RestaurantDB.sql`):** Categoria `:26` · Plato `:36` · Mesa `:50` ·
Empleado `:63` · Cliente `:77` · Pedido `:91` · DetallePedido `:107` · Comprobante `:122` · Usuario `:138`.
Ver [[Capa de Entidades]] para el modelo de objetos equivalente.

---

## 🎨 Estilos e iconos

- **`Restaurant.Presentacion/Estilos/TemaModerno.cs`** — estilos centralizados (paleta gris). Ver [[Tema Moderno]].
  `EstilizarFormulario` (`:37`) · `EstilizarBotonSuccess` (`:44`) · `EstilizarBotonDanger` (`:56`) ·
  `EstilizarBotonSecundario` (`:68`) · `EstilizarTextBox` (`:93`) · `EstilizarComboBox` (`:101`) ·
  `EstilizarCheckBox` (`:109`) · `EstilizarDataGridView` (`:120`) · `EstilizarTitulo` (`:215`) ·
  `EstilizarTotal` (`:223`) · `EstilizarMenu` (`:251`) · `AgregarTarjetaReferencia` (`:322`) ·
  `UniformarEntradas` (`:348`) · **`AplicarBarraTitulo`** (`:369`, la barra gris con el nombre de la ventana).
- **`Restaurant.Presentacion/Iconos/IconosUI.cs`** — constantes emoji para botones. Ver [[Iconografía]].
  `Nuevo` (`:5`), `Guardar` (`:6`), `Eliminar` (`:7`), `Cancelar` (`:8`), `Refrescar` (`:10`),
  `Agregar` (`:12`), `Quitar` (`:13`), `Facturar` (`:15`), `Generar` (`:16`), `Login` (`:18`)…

---

## 🧭 Cómo rastrear un botón de punta a punta

Ejemplo: **¿qué pasa al pulsar “Guardar” en Clientes?**

1. **Botón →** `btnGuardar_Click` en `Restaurant.Presentacion/FrmCliente.cs:100` (arma el objeto `Cliente`).
2. **Negocio →** `ClienteBLL.Registrar` (`Restaurant.Negocio/ClienteBLL.cs:29`) o `Modificar` (`:35`), que valida con `Validar` (`:50`).
3. **Datos →** `ClienteDAO.Insertar` (`Restaurant.Datos/ClienteDAO.cs:53`) / `Actualizar` (`:71`).
4. **Base de datos →** `usp_Cliente_Insertar` (`database/01_RestaurantDB.sql:333`) / `usp_Cliente_Actualizar` (`:344`).

Ese camino **Form → BLL → DAO → SP** es el mismo en todos los CRUD. Ver el recorrido completo en [[Flujo de datos]].

---
Volver al [[Índice]]
