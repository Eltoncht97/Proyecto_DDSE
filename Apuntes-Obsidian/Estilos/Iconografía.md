# Iconografía - Emojis en Botones

Los emojis son **constantes de texto** en `IconosUI.cs` que se asignan a los botones para mejorar la interfaz visual.

## Ubicación

```
Restaurant.Presentacion/
└── Iconos/
    └── IconosUI.cs  ← Todas las constantes aquí
```

## Contenido de IconosUI.cs

```csharp
namespace Restaurant.Presentacion.Iconos
{
    public static class IconosUI
    {
        // Operaciones CRUD
        public const string Nuevo = "✏️ Nuevo";
        public const string Guardar = "💾 Guardar";
        public const string Eliminar = "🗑️ Eliminar";
        public const string Cancelar = "❌ Cancelar";
        
        // Acciones adicionales
        public const string Agregar = "➕ Agregar";
        public const string Quitar = "➖ Quitar";
        public const string Buscar = "🔍 Buscar";
        public const string Refrescar = "🔄 Refrescar";
        
        // Operaciones especiales
        public const string Facturar = "📄 Facturar";
        public const string Generar = "📋 Generar";
        public const string Reportes = "📊 Reportes";
        
        // Menús
        public const string Mantenimientos = "🔧 Mantenimientos";
        public const string Operaciones = "⚙️ Operaciones";
        public const string Salir = "🚪 Salir";
        
        // Autenticación
        public const string Login = "🔐 Ingresar";
        public const string Usuario = "👤 Usuario";
        public const string Contraseña = "🔒 Contraseña";
    }
}
```

## Cómo se Asignan a Botones

### Paso 1: Importar IconosUI

```csharp
using Restaurant.Presentacion.Iconos;
```

### Paso 2: Asignar en FrmXXX_Load()

```csharp
private void FrmCategoria_Load(object sender, EventArgs e)
{
    // ... TemaModerno.Estilizar...()
    
    // Asignar iconos a botones
    btnNuevo.Text = IconosUI.Nuevo;           // ✏️ Nuevo
    btnGuardar.Text = IconosUI.Guardar;       // 💾 Guardar
    btnEliminar.Text = IconosUI.Eliminar;     // 🗑️ Eliminar
    btnCancelar.Text = IconosUI.Cancelar;     // ❌ Cancelar
    
    Listar();
}
```

### Resultado Visual

| Antes | Después |
|-------|---------|
| `[Nuevo]` | `[✏️ Nuevo]` |
| `[Guardar]` | `[💾 Guardar]` |
| `[Eliminar]` | `[🗑️ Eliminar]` |
| `[Cancelar]` | `[❌ Cancelar]` |

---

## Ventajas

### 1. Claridad Visual
Los emojis comunican **de un vistazo** qué hace cada botón:
- 💾 = Guardar (archivo)
- 🗑️ = Eliminar (basura)
- ❌ = Cancelar (error/cierre)
- ✏️ = Editar (lápiz)

### 2. Coherencia
Si usas los mismos emojis en todos los formularios, el usuario aprende rápido:
- "💾 siempre guarda"
- "🗑️ siempre elimina"

### 3. Accesibilidad
Los emojis no dependen de idioma. Un emoji es igual en Español, Inglés, Chino.

### 4. Modernidad
Interfaces modernas (Material Design, Fluent Design) usan iconos. Los emojis son una forma accesible de hacerlo en Windows Forms.

---

## Conexión con TemaModerno

**TemaModerno.cs** = Colores, bordes, tamaños  
**IconosUI.cs** = Texto + emoji para botones  

Ambas trabajan juntas:

```csharp
// En FrmCategoria_Load():

// 1. TemaModerno define CÓMO se ve
TemaModerno.EstilizarBotonSuccess(btnGuardar);
// Resultado: BackColor = Verde, ForeColor = Blanco, Height = 36px

// 2. IconosUI define QUÉ dice
btnGuardar.Text = IconosUI.Guardar;
// Resultado: Botón con texto "💾 Guardar"

// Efecto visual final: Botón verde grande con icono 💾
```

---

## Patrón en Cada Formulario

```csharp
private void FrmXXX_Load(object sender, EventArgs e)
{
    // Estilizar formulario
    TemaModerno.EstilizarFormulario(this);
    
    // Estilizar controles
    TemaModerno.EstilizarTextBox(txtNombre);
    TemaModerno.EstilizarBotonSuccess(btnGuardar);
    TemaModerno.EstilizarBotonSecundario(btnNuevo);
    // ...
    
    // Agregar iconos
    btnNuevo.Text = IconosUI.Nuevo;       // ← Aquí se asigna emoji
    btnGuardar.Text = IconosUI.Guardar;   // ← Aquí se asigna emoji
    btnEliminar.Text = IconosUI.Eliminar; // ← Aquí se asigna emoji
    btnCancelar.Text = IconosUI.Cancelar; // ← Aquí se asigna emoji
    
    // Lógica original (CRUD)
    Listar();
    LimpiarFormulario();
}
```

---

## Cómo Agregar Nuevos Iconos

Si necesitas un emoji nuevo (ej: para una acción especial):

### 1. Agrégalo a IconosUI.cs

```csharp
public const string Exportar = "💾 Exportar";   // Nuevo icono
```

### 2. Úsalo en el formulario

```csharp
btnExportar.Text = IconosUI.Exportar;
```

### 3. ¡Listo!

El emoji aparece en el botón de inmediato.

---

## Emojis Disponibles (Tabla de Referencia)

| Emoji | Significado | Uso |
|-------|-------------|-----|
| ✏️ | Editar | Nuevo, Editar |
| 💾 | Guardar | Guardar, Exportar |
| 🗑️ | Eliminar | Eliminar, Borrar |
| ❌ | Cerrar | Cancelar, Rechazar |
| ➕ | Agregar | Agregar línea |
| ➖ | Quitar | Quitar línea |
| 🔍 | Buscar | Buscar, Filtrar |
| 🔄 | Refrescar | Recargar, Actualizar |
| 📄 | Documento | Facturación, Comprobante |
| 📋 | Listin | Reporte, Generar |
| 📊 | Gráfico | Reportes, Estadísticas |
| 🔧 | Herramienta | Mantenimientos, Configuración |
| ⚙️ | Engranaje | Operaciones, Ajustes |
| 🚪 | Puerta | Salir, Logout |
| 🔐 | Candado | Login, Seguridad |
| 👤 | Persona | Usuario |
| 🔒 | Llave | Contraseña |

---

## Ver También

- [[Tema Moderno]] - Cómo se estilizan los botones (colores + tamaños)
- [[Capa de Presentación]] - Dónde viven los formularios que usan estos iconos
