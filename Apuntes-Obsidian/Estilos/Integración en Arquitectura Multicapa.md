# Integración de Estilos en la Arquitectura Multicapa

Los estilos visuales (TemaModerno.cs + IconosUI.cs) se integran **únicamente en la Capa Presentación** sin afectar las otras 3 capas.

## Arquitectura de 4 Capas (Recordatorio)

```
┌─────────────────────────────────────────────────────┐
│  Capa de Presentación (UI)                          │
│  - Windows Forms (Frm*.cs)                          │
│  - TemaModerno.cs   ← Estilos visuales (NUEVO)      │
│  - IconosUI.cs      ← Emojis (NUEVO)                │
├─────────────────────────────────────────────────────┤
│  Capa de Negocio (BLL)                              │
│  - Reglas de negocio                                │
│  - Validaciones ([LINQ]])                           │
│  - NO se toca                                        │
├─────────────────────────────────────────────────────┤
│  Capa de Datos (DAO)                                │
│  - Acceso a BD (ADO.NET)                            │
│  - Procedimientos almacenados                       │
│  - NO se toca                                        │
├─────────────────────────────────────────────────────┤
│  Capa de Entidades (Modelos)                        │
│  - Clases del dominio (Cliente, Pedido, etc.)       │
│  - NO se toca                                        │
└─────────────────────────────────────────────────────┘
```

---

## Dónde Viven los Estilos

```
Restaurant.sln (Solución)
│
├── Restaurant.Entidades/          ← Sin cambios
│   └── Cliente.cs, Pedido.cs, ...
│
├── Restaurant.Datos/              ← Sin cambios
│   └── ClienteDAO.cs, PedidoDAO.cs, ...
│
├── Restaurant.Negocio/            ← Sin cambios
│   └── ClienteBLL.cs, PedidoBLL.cs, ...
│
└── Restaurant.Presentacion/       ← AQUÍ ESTÁN LOS ESTILOS
    ├── Estilos/                   ← Nueva carpeta
    │   └── TemaModerno.cs         ← Nueva clase de estilos
    ├── Iconos/                    ← Nueva carpeta
    │   └── IconosUI.cs            ← Nuevas constantes de emojis
    ├── FrmCategoria.cs            ← Usa TemaModerno + IconosUI
    ├── FrmPlato.cs                ← Usa TemaModerno + IconosUI
    ├── FrmEmpleado.cs             ← Usa TemaModerno + IconosUI
    └── ... (resto de Frm*.cs)
```

---

## Flujo: Cómo se Conectan las Capas

### Ejemplo: Usuario hace clic en btnGuardar en FrmCategoria

```
1. Presentación (UI)
   └─ btnGuardar_Click() ejecuta
      │
      ├─ Recoge datos del formulario (txtNombre.Text, etc.)
      │
      ├─ TemaModerno coloreó el botón ← visibilidad mejorada
      │
      └─ Crea objeto Categoria con los datos
            │
            ▼
2. Negocio (BLL)
   └─ CategoriaBLL.Registrar(categoria) ejecuta
      │
      ├─ Valida nombre no vacío ← validación lógica (BLL)
      │
      ├─ Valida con LINQ si ya existe
      │
      └─ Si OK, llama a DAO
            │
            ▼
3. Datos (DAO)
   └─ CategoriaDAO.Insertar(categoria) ejecuta
      │
      ├─ Abre conexión a BD
      │
      ├─ Ejecuta stored procedure @sp_Categoria_Insertar
      │
      └─ Cierra conexión
            │
            ▼
4. Entidades
   └─ Nunca participa en la ejecución
      (solo define la estructura de Categoria)

RESULTADO: Categoría guardada en BD + Usuario ve botón bonito en pantalla
```

---

## Separación de Responsabilidades

### TemaModerno.cs (Estilo)

**Responsabilidad:**
> Definir colores, bordes, tamaños, fuentes — solo visual.

**No decide:**
- Si la categoría debe guardarse
- Si el nombre está vacío
- Cómo conectar a la BD

**Ejemplo:**

```csharp
// TemaModerno.cs define CÓMO se ve el botón
public static void EstilizarBotonSuccess(Button btn)
{
    btn.BackColor = Colores.Exito;  // Verde
    btn.Height = 36;                 // Tamaño
    // ... etc
}
```

### CategoriaBLL.cs (Lógica)

**Responsabilidad:**
> Validar reglas de negocio, orquestar DAO.

**No decide:**
- Qué color debe tener el botón
- Cómo lucen los TextBox
- Dónde guardar el CSS (no aplica, es WinForms)

**Ejemplo:**

```csharp
// CategoriaBLL decide SI se guarda
public void Registrar(Categoria c)
{
    if (string.IsNullOrWhiteSpace(c.Nombre))
        throw new Exception("El nombre es requerido");
    
    _dao.Insertar(c);  // Si OK, guarda
}
```

### FrmCategoria.cs (Conexión)

**Responsabilidad:**
> Conectar UI visual (TemaModerno) con lógica (CategoriaBLL).

**Ejemplo:**

```csharp
private void FrmCategoria_Load(object sender, EventArgs e)
{
    // 1. Aplicar estilos visuales ← TemaModerno
    TemaModerno.EstilizarBotonSuccess(btnGuardar);
    TemaModerno.EstilizarTextBox(txtNombre);
    btnGuardar.Text = IconosUI.Guardar;
    
    // 2. Cargar datos de BLL ← Lógica de negocio
    Listar();  // Llama a _bll.ListarTabla()
}

private void btnGuardar_Click(object sender, EventArgs e)
{
    // Lógica al guardar
    Categoria c = new Categoria { Nombre = txtNombre.Text };
    _bll.Registrar(c);  // Delega validación a BLL
}
```

---

## Niveles de Responsabilidad

| Capa | Responsabilidad | Ejemplo |
|------|-----------------|---------|
| **Presentación + Estilos** | Cómo se ve | "El botón es verde, 36px, emoji 💾" |
| **Negocio** | Qué se valida | "El nombre no puede estar vacío" |
| **Datos** | Cómo se persiste | "INSERT INTO Categoria (Nombre, ...)" |
| **Entidades** | Estructura | "Categoria tiene IdCategoria, Nombre, ..." |

---

## Ventaja: Puedes Cambiar Estilos sin Tocar Lógica

### Escenario: "Cambiar verde a azul en btnGuardar"

**Opción 1: Sin TemaModerno (Lo viejo)**
```csharp
// Tendrías que buscar en TODOS los Frm*.cs:
btnGuardar.BackColor = Color.Blue;  // ← En FrmCategoria.cs
btnGuardar.BackColor = Color.Blue;  // ← En FrmPlato.cs
btnGuardar.BackColor = Color.Blue;  // ← En FrmEmpleado.cs
// ... 20 veces más en otros formularios
// PROBLEMA: Error propenso, cambios inconsistentes
```

**Opción 2: Con TemaModerno (Lo nuevo)**
```csharp
// Editas TemaModerno.cs una sola vez:
public static void EstilizarBotonSuccess(Button btn)
{
    btn.BackColor = Colores.Exito;  // Cambias Colores.Exito = Color.Blue
}

// ¡Todos los btnGuardar en TODA la app cambian a azul automáticamente!
```

---

## Dependencias

### Qué Depende de Qué

```
Restaurant.Presentacion  (capa superior)
    │
    ├─ depende de → Estilos/TemaModerno.cs
    ├─ depende de → Iconos/IconosUI.cs
    ├─ depende de → Restaurant.Negocio
    └─ depende de → Restaurant.Entidades

Restaurant.Negocio  (capa media)
    │
    └─ depende de → Restaurant.Datos
                  → Restaurant.Entidades

Restaurant.Datos  (capa baja)
    │
    └─ depende de → Restaurant.Entidades

Restaurant.Entidades  (capa base)
    │
    └─ NO depende de nada
```

**Punto clave:** TemaModerno + IconosUI son parte de Presentacion, así que:
- ✅ Pueden usar clases de Entidades (p.ej., pasar una Categoria a un formulario)
- ✅ Pueden usar clases de Negocio (p.ej., CategoriaBLL)
- ❌ NO pueden usar código de Datos directamente (eso lo hace BLL)

---

## Ejemplo Completo: Ciclo de Vida de FrmCategoria

```csharp
// PASO 1: Usuario abre la app
// Program.cs crea FrmPrincipal

// PASO 2: Usuario hace clic en "Mantenimientos → Categorías"
// FrmPrincipal.mnuCategorias_Click() → AbrirHijo(new FrmCategoria())

// PASO 3: Se crea y carga FrmCategoria
public partial class FrmCategoria : Form
{
    private readonly CategoriaBLL _bll = new CategoriaBLL();
    
    private void FrmCategoria_Load(object sender, EventArgs e)
    {
        // PASO 3a: Aplicar estilos
        TemaModerno.EstilizarFormulario(this);              // Fondo #F5F5F5
        TemaModerno.EstilizarTextBox(txtNombre);            // Blanco, borde fino
        TemaModerno.EstilizarBotonSuccess(btnGuardar);      // Verde, 36px
        TemaModerno.EstilizarBotonDanger(btnEliminar);      // Rojo, 36px
        btnGuardar.Text = IconosUI.Guardar;                 // 💾 Guardar
        btnEliminar.Text = IconosUI.Eliminar;               // 🗑️ Eliminar
        TemaModerno.EstilizarDataGridView(dgvLista);        // Encabezados azules
        
        // PASO 3b: Cargar datos de Negocio
        DataTable dt = _bll.ListarTabla();  // Llama BLL → DAO → BD
        dgvLista.DataSource = dt;           // Muestra en tabla estilizada
        LimpiarFormulario();
    }
    
    // PASO 4: Usuario escribe nombre y hace clic btnGuardar
    private void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            // PASO 4a: Juntar datos (UI → Entidades)
            Categoria c = new Categoria
            {
                IdCategoria = _idActual,
                Nombre = txtNombre.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim(),
                Estado = chkEstado.Checked
            };
            
            // PASO 4b: Delegar validación a Negocio
            if (_idActual == 0)
                _bll.Registrar(c);  // BLL valida + DAO guarda
            else
                _bll.Modificar(c);  // BLL valida + DAO actualiza
            
            // PASO 4c: Refrescar UI
            MessageBox.Show("Guardado correctamente");
            Listar();               // Vuelve a cargar tabla
            LimpiarFormulario();    // Reset formulario
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error");
        }
    }
}
```

---

## Checklist de Integración

✅ **TemaModerno.cs creado** — Define colores, métodos de estilo  
✅ **IconosUI.cs creado** — Define constantes de emojis  
✅ **Frm*.cs actualizados** — Todos usan TemaModerno + IconosUI en Load()  
✅ **No se toca BLL** — Lógica sigue igual  
✅ **No se toca DAO** — Datos siguen igual  
✅ **No se toca Entidades** — Modelos siguen igual  
✅ **Solución compila** — Todos los using correctos, referencias OK  

---

## Ver También

- [[Tema Moderno]] - Métodos de estilo específicos
- [[Iconografía]] - Cómo funcionan los emojis
- [[Capa de Presentación]] - Dónde viven los formularios
- [[Arquitectura multicapa]] - Contexto general de 4 capas
