# Cheat Sheet - Cómo Usar Tema Moderno en 5 Minutos

Referencia rápida para aplicar estilos a cualquier formulario nuevo.

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
    
    // Paso 3: Estilizar BOTONES (según función)
    TemaModerno.EstilizarBotonSuccess(btnGuardar);      // Verde
    TemaModerno.EstilizarBotonDanger(btnEliminar);      // Rojo
    TemaModerno.EstilizarBotonSecundario(btnNuevo);     // Gris
    TemaModerno.EstilizarBotonSecundario(btnCancelar);  // Gris
    
    // Paso 4: Agregar ICONOS a botones
    btnNuevo.Text = IconosUI.Nuevo;
    btnGuardar.Text = IconosUI.Guardar;
    btnEliminar.Text = IconosUI.Eliminar;
    btnCancelar.Text = IconosUI.Cancelar;
    
    // Paso 5: Estilizar TABLA si existe
    TemaModerno.EstilizarDataGridView(dgvLista);
    
    // Paso 6: Lógica original (CRUD, cargar datos, etc.)
    Listar();
    LimpiarFormulario();
}
```

## 3. Métodos Disponibles

| Método | Para | Ejemplo |
|--------|------|---------|
| `EstilizarFormulario(Form)` | El formulario completo | `TemaModerno.EstilizarFormulario(this);` |
| `EstilizarTextBox(TextBox)` | Campos de texto | `TemaModerno.EstilizarTextBox(txtNombre);` |
| `EstilizarComboBox(ComboBox)` | Listas desplegables | `TemaModerno.EstilizarComboBox(cboCategoria);` |
| `EstilizarCheckBox(CheckBox)` | Casillas de verificación | `TemaModerno.EstilizarCheckBox(chkEstado);` |
| `EstilizarNumericUpDown(NumericUpDown)` | Números con spinner | `TemaModerno.EstilizarNumericUpDown(nudPrecio);` |
| `EstilizarDateTimePicker(DateTimePicker)` | Picker de fechas | `TemaModerno.EstilizarDateTimePicker(dtpFecha);` |
| `EstilizarBotonSuccess(Button)` | Botones verdes (Guardar) | `TemaModerno.EstilizarBotonSuccess(btnGuardar);` |
| `EstilizarBotonDanger(Button)` | Botones rojos (Eliminar) | `TemaModerno.EstilizarBotonDanger(btnEliminar);` |
| `EstilizarBotonSecundario(Button)` | Botones grises (Cancelar) | `TemaModerno.EstilizarBotonSecundario(btnCancelar);` |
| `EstilizarBotonPrimario(Button)` | Botones azules (Aceptar) | `TemaModerno.EstilizarBotonPrimario(btnAceptar);` |
| `EstilizarDataGridView(DataGridView)` | Tabla de datos | `TemaModerno.EstilizarDataGridView(dgvLista);` |

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

```csharp
// Acceder a la paleta de colores
Color verde = TemaModerno.Colores.Exito;          // #4CAF50
Color rojo = TemaModerno.Colores.Alerta;          // #E74C3C
Color azul = TemaModerno.Colores.Primario;        // #0066CC
Color grisClaro = TemaModerno.Colores.Fondo;      // #F5F5F5
Color grísOscuro = TemaModerno.Colores.FondoOscuro; // #333333

// Ej: Para un label personalizado
lblTitulo.BackColor = TemaModerno.Colores.Primario;
lblTitulo.ForeColor = TemaModerno.Colores.Blanco;
```

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
  - [ ] Estilizar botones (Success, Danger, Secundario)
  - [ ] Asignar iconos a botones
  - [ ] Estilizar DataGridView si existe
  - [ ] Mantener lógica original (Listar(), etc.)
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
