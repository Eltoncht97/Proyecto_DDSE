# Cheat Sheet - Cómo Usar Tema Moderno en 5 Minutos

Referencia rápida para aplicar estilos a cualquier formulario nuevo.

> [!info] El tema es 100% gris
> La UI ya **no** usa azul/verde/rojo: es escala de grises, plana y minimalista. Los botones se diferencian solo por **intensidad** de gris, nunca por color. Si ves `#0066CC`, `#4CAF50` o `#E74C3C` en notas viejas, ya no existen.

## 0. Ubicación del Código

```
Restaurant.Presentacion/
├── Estilos/TemaModerno.cs    ← Paleta + métodos
├── Iconos/IconosUI.cs        ← Emojis
└── FrmXXX.cs                 ← Tu formulario (aquí aplicas)
```

## 1. Agregar los Using

Al inicio de tu Frm*.cs:

```csharp
using Restaurant.Presentacion.Estilos;
using Restaurant.Presentacion.Iconos;
```

## 2. En FrmXXX_Load() - Orden Exacto

```csharp
private void FrmXXX_Load(object sender, EventArgs e)
{
    // Paso 1: Estilizar el formulario base
    TemaModerno.EstilizarFormulario(this);
    
    // Paso 2: Estilizar cada CONTROL
    TemaModerno.EstilizarTextBox(txtNombre);
    TemaModerno.EstilizarTextBox(txtDescripcion);
    TemaModerno.EstilizarComboBox(cboCategoria);
    TemaModerno.EstilizarCheckBox(chkEstado);
    TemaModerno.EstilizarNumericUpDown(nudPrecio);
    TemaModerno.EstilizarDateTimePicker(dtpFecha);
    
    // Paso 3: Estilizar BOTONES (según función — solo cambia la INTENSIDAD del gris)
    TemaModerno.EstilizarBotonSuccess(btnGuardar);      // Gris oscuro (acción primaria)
    TemaModerno.EstilizarBotonDanger(btnEliminar);      // Gris medio (peligro)
    TemaModerno.EstilizarBotonSecundario(btnNuevo);     // Blanco con borde gris
    TemaModerno.EstilizarBotonSecundario(btnCancelar);  // Blanco con borde gris
    
    // Paso 4: Agregar ICONOS a botones
    btnNuevo.Text = IconosUI.Nuevo;
    btnGuardar.Text = IconosUI.Guardar;
    btnEliminar.Text = IconosUI.Eliminar;
    btnCancelar.Text = IconosUI.Cancelar;
    
    // Paso 5: Estilizar TABLA si existe (los checkbox se pintan grises, no azules)
    TemaModerno.EstilizarDataGridView(dgvLista);
    
    // Paso 6: Lógica original (CRUD, cargar datos, etc.)
    Listar();
    LimpiarFormulario();

    // Paso 7: Toques finales de layout (SIEMPRE al final del Load, en este orden)
    TemaModerno.UniformarEntradas(this, 380);            // mismo ancho a TextBox/ComboBox
    TemaModerno.AgregarTarjetaReferencia(this, "X.png"); // tarjeta cuadrada arriba-derecha
    TemaModerno.AplicarBarraTitulo(this);                // barra de título gris (ventana hija MDI)
}
```

> [!tip] Los 3 últimos van al final
> `UniformarEntradas`, `AgregarTarjetaReferencia` y `AplicarBarraTitulo` deben ir como **últimas líneas** del `_Load`, después de crear/estilizar todos los controles. `AplicarBarraTitulo` mueve el contenido a un panel interno, así que si lo llamas antes romperás el layout.

## 3. Métodos Disponibles

| Método | Para | Ejemplo |
|--------|------|---------|
| `EstilizarFormulario(Form)` | El formulario completo | `TemaModerno.EstilizarFormulario(this);` |
| `EstilizarTextBox(TextBox)` | Campos de texto | `TemaModerno.EstilizarTextBox(txtNombre);` |
| `EstilizarComboBox(ComboBox)` | Listas desplegables | `TemaModerno.EstilizarComboBox(cboCategoria);` |
| `EstilizarCheckBox(CheckBox)` | Casillas de verificación | `TemaModerno.EstilizarCheckBox(chkEstado);` |
| `EstilizarNumericUpDown(NumericUpDown)` | Números con spinner | `TemaModerno.EstilizarNumericUpDown(nudPrecio);` |
| `EstilizarDateTimePicker(DateTimePicker)` | Picker de fechas | `TemaModerno.EstilizarDateTimePicker(dtpFecha);` |
| `EstilizarBotonSuccess(Button)` | Acción primaria — gris oscuro, texto blanco (Guardar) | `TemaModerno.EstilizarBotonSuccess(btnGuardar);` |
| `EstilizarBotonDanger(Button)` | Acción de peligro — gris medio, texto blanco (Eliminar) | `TemaModerno.EstilizarBotonDanger(btnEliminar);` |
| `EstilizarBotonSecundario(Button)` | Secundario — blanco con borde gris (Cancelar/Nuevo) | `TemaModerno.EstilizarBotonSecundario(btnCancelar);` |
| `EstilizarBotonPrimario(Button)` | Acento — gris oscuro (Aceptar) | `TemaModerno.EstilizarBotonPrimario(btnAceptar);` |
| `EstilizarDataGridView(DataGridView)` | Tabla de datos (checks en gris, no azul) | `TemaModerno.EstilizarDataGridView(dgvLista);` |
| `EstilizarLabel(Label, bool)` | Etiqueta normal / encabezado | `TemaModerno.EstilizarLabel(lbl, true);` |
| `EstilizarTitulo(Label)` | Título H1 de la ventana (gris) | `TemaModerno.EstilizarTitulo(lblTitulo);` |
| `EstilizarTotal(Label)` | Importe destacado (total, gris) | `TemaModerno.EstilizarTotal(lblTotal);` |
| `EstilizarMenu(MenuStrip)` | Menú superior en grises planos | `TemaModerno.EstilizarMenu(menuPrincipal);` |
| `EstilizarStatus(StatusStrip)` | Barra de estado inferior gris | `TemaModerno.EstilizarStatus(statusBar);` |
| `UniformarEntradas(Control, int)` | Mismo ancho a TextBox/ComboBox (recursivo) | `TemaModerno.UniformarEntradas(this, 380);` |
| `AgregarTarjetaReferencia(Form, string)` | Tarjeta 200×200 con imagen arriba-derecha | `TemaModerno.AgregarTarjetaReferencia(this, "categoria.png");` |
| `AplicarBarraTitulo(Form)` | Barra de título gris para ventana hija MDI | `TemaModerno.AplicarBarraTitulo(this);` |
| `CargarImagen(string)` | Carga una imagen embebida (recurso) | `Image img = TemaModerno.CargarImagen("logo.png");` |

## 4. Iconos Disponibles

| Icono | IconosUI.Property | Código |
|-------|------|------|
| ✏️ | `IconosUI.Nuevo` | `btn.Text = IconosUI.Nuevo;` |
| 💾 | `IconosUI.Guardar` | `btn.Text = IconosUI.Guardar;` |
| 🗑️ | `IconosUI.Eliminar` | `btn.Text = IconosUI.Eliminar;` |
| ❌ | `IconosUI.Cancelar` | `btn.Text = IconosUI.Cancelar;` |
| ➕ | `IconosUI.Agregar` | `btn.Text = IconosUI.Agregar;` |
| ➖ | `IconosUI.Quitar` | `btn.Text = IconosUI.Quitar;` |
| 🔍 | `IconosUI.Buscar` | `btn.Text = IconosUI.Buscar;` |
| 🔄 | `IconosUI.Refrescar` | `btn.Text = IconosUI.Refrescar;` |
| 📄 | `IconosUI.Facturar` | `btn.Text = IconosUI.Facturar;` |
| 📋 | `IconosUI.Generar` | `btn.Text = IconosUI.Generar;` |
| 📊 | `IconosUI.Reportes` | `btn.Text = IconosUI.Reportes;` |

## 5. Colores (Si los Necesitas Directamente)

Toda la paleta es **escala de grises** (clase `TemaModerno.Colores`):

| Miembro | RGB | Uso |
|---------|-----|-----|
| `Primario` | `70,70,70` (gris oscuro) | Títulos, encabezado de grilla, acento |
| `Texto` | `40,40,40` (casi negro) | Texto principal |
| `TextoSecundario` | `130,130,130` (gris medio) | Texto secundario |
| `Fondo` | `245,245,245` (gris muy claro) | Filas alternas / hover |
| `FondoFormulario` | `250,250,250` (blanco roto) | Fondo de ventana |
| `Borde` | `215,215,215` | Bordes sutiles |
| `Blanco` | `White` | Fondos de campos |
| `Exito` | `70,70,70` (gris oscuro) | Botón de acción primaria (Guardar) |
| `Alerta` | `140,140,140` (gris medio) | Botón de peligro (Eliminar) |

```csharp
// Acceder a la paleta de colores (todos grises)
Color acento = TemaModerno.Colores.Primario;        // 70,70,70 (gris oscuro)
Color texto = TemaModerno.Colores.Texto;            // 40,40,40 (casi negro)
Color grisClaro = TemaModerno.Colores.Fondo;        // 245,245,245
Color borde = TemaModerno.Colores.Borde;            // 215,215,215

// Ej: Para un label personalizado
lblTitulo.BackColor = TemaModerno.Colores.Primario;
lblTitulo.ForeColor = TemaModerno.Colores.Blanco;
```

> [!warning] `FondoOscuro` ya no existe
> Antes había `Colores.FondoOscuro`. Hoy usa `Colores.Primario` (gris oscuro `70,70,70`) para fondos oscuros como encabezados.

## 6. Ejemplo Completo: FrmProducto (Inventado)

```csharp
using System;
using System.Windows.Forms;
using Restaurant.Entidades;
using Restaurant.Negocio;
using Restaurant.Presentacion.Estilos;    // ← Agrega
using Restaurant.Presentacion.Iconos;     // ← Agrega

namespace Restaurant.Presentacion
{
    public partial class FrmProducto : Form
    {
        private readonly ProductoBLL _bll = new ProductoBLL();
        private int _idActual = 0;

        public FrmProducto()
        {
            InitializeComponent();
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            // Estilizar
            TemaModerno.EstilizarFormulario(this);
            TemaModerno.EstilizarTextBox(txtNombre);
            TemaModerno.EstilizarNumericUpDown(nudPrecio);
            TemaModerno.EstilizarBotonSuccess(btnGuardar);
            TemaModerno.EstilizarBotonDanger(btnEliminar);
            TemaModerno.EstilizarBotonSecundario(btnNuevo);
            TemaModerno.EstilizarBotonSecundario(btnCancelar);
            TemaModerno.EstilizarDataGridView(dgvProductos);
            
            // Iconos
            btnNuevo.Text = IconosUI.Nuevo;
            btnGuardar.Text = IconosUI.Guardar;
            btnEliminar.Text = IconosUI.Eliminar;
            btnCancelar.Text = IconosUI.Cancelar;
            
            // Cargar datos
            Listar();
            LimpiarFormulario();

            // Toques finales de layout (al final del Load)
            TemaModerno.UniformarEntradas(this, 380);
            TemaModerno.AgregarTarjetaReferencia(this, "producto.png");
            TemaModerno.AplicarBarraTitulo(this);
        }

        private void Listar()
        {
            dgvProductos.DataSource = _bll.ListarTabla();
        }

        private void LimpiarFormulario()
        {
            _idActual = 0;
            txtNombre.Clear();
            nudPrecio.Value = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Producto p = new Producto
                {
                    IdProducto = _idActual,
                    Nombre = txtNombre.Text.Trim(),
                    Precio = nudPrecio.Value
                };

                if (_idActual == 0)
                    _bll.Registrar(p);
                else
                    _bll.Modificar(p);

                MessageBox.Show("Guardado correctamente.");
                Listar();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
```

## 7. Checklist para Nuevo Formulario

- [ ] Agregar `using Restaurant.Presentacion.Estilos;`
- [ ] Agregar `using Restaurant.Presentacion.Iconos;`
- [ ] En `FrmXXX_Load()`:
  - [ ] Llamar `TemaModerno.EstilizarFormulario(this);`
  - [ ] Estilizar cada TextBox, ComboBox, CheckBox, etc.
  - [ ] Estilizar botones (Success, Danger, Secundario) — recuerda: solo cambia la intensidad del gris
  - [ ] Asignar iconos a botones
  - [ ] Estilizar DataGridView si existe
  - [ ] Estilizar título (`EstilizarTitulo`) y total (`EstilizarTotal`) si los hay
  - [ ] Mantener lógica original (Listar(), etc.)
  - [ ] Al final: `UniformarEntradas(this, 380)` → `AgregarTarjetaReferencia(this, "X.png")` → `AplicarBarraTitulo(this)`
- [ ] Compilar ✅
- [ ] Ejecutar ✅

## 8. Troubleshooting

| Problema | Causa | Solución |
|----------|-------|----------|
| "El tipo o nombre TemaModerno no existe" | Falta `using Restaurant.Presentacion.Estilos;` | Agrega el using |
| "No puedo encontrar los métodos" | Archivo TemaModerno.cs no está en .csproj | Edita .csproj manualmente |
| "Los botones no cambian color" | `TemaModerno.EstilizarBotonSuccess()` se llamó ANTES de crear el botón | Llámalo DESPUÉS de `InitializeComponent()` |
| "El formulario no cambió de fondo" | `EstilizarFormulario(this)` se olvidó | Llámalo primero en Load() |

## 9. Más Información

Para detalles:
- [[Tema Moderno]] — Métodos específicos, paleta completa
- [[Iconografía]] — Tabla de emojis disponibles
- [[Integración en Arquitectura Multicapa]] — Cómo se conectan con BLL/DAO

---

**Resumen rápido:** Agrega 2 using → Llama 5-6 líneas de TemaModerno en Load() → Asigna iconos → ¡Listo!
