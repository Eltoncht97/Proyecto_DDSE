# Tema Moderno - Arquitectura de Estilos

[[Arquitectura multicapa]] define la estructura de la app. Los estilos visuales se aplican exclusivamente en **Capa Presentación**.

## Ubicación

```
Restaurant.Presentacion/
├── Estilos/
│   └── TemaModerno.cs          ← Clase centralizada de estilos
├── Iconos/
│   └── IconosUI.cs             ← Constantes de emojis
└── Frm*.cs                      ← Formularios que usan los estilos
```

## Filosofía

**Separación de responsabilidades:**
- **TemaModerno.cs** = Estilos visuales (colores, bordes, fuentes, tamaños)
- **Formularios** = Lógica de negocios (CRUD, validaciones, eventos)
- **Conexión** = Se hace en `FrmXXX_Load()` con una sola línea por control

## Paleta de Colores

```csharp
public static class Colores
{
    Color Primario      = #0066CC (Azul)           ← Para encabezados, botones principales
    Color Secundario    = #FF6B35 (Naranja)        ← Para acentos (no usado aún)
    Color Exito         = #4CAF50 (Verde)          ← Para btnGuardar
    Color Alerta        = #E74C3C (Rojo)           ← Para btnEliminar
    Color Fondo         = #F5F5F5 (Gris claro)    ← Fondo de formularios
    Color FondoOscuro   = #333333 (Gris oscuro)   ← Texto
    Color Borde         = #DDDDDD (Gris borde)    ← Bordes de controles
    Color Blanco        = #FFFFFF                  ← Texto sobre fondos oscuros
    Color Gris          = #C8C8C8                  ← Colores secundarios
}
```

## Métodos Principales

### 1. Formularios: `EstilizarFormulario(Form)`
Aplica el estilo base al formulario completo.

```csharp
// En FrmCategoria_Load():
TemaModerno.EstilizarFormulario(this);
// Resultado: BackColor = #F5F5F5, Font = Segoe UI 9pt
```

**Efecto visual:**
- Fondo gris claro en toda la ventana
- Fuente uniforme Segoe UI tamaño 9

---

### 2. TextBox: `EstilizarTextBox(TextBox)`
Estandariza campos de entrada de texto.

```csharp
TemaModerno.EstilizarTextBox(txtNombre);
```

**Propiedades aplicadas:**
- BackColor = Blanco (#FFFFFF)
- ForeColor = Gris oscuro (#333333)
- BorderStyle = FixedSingle
- Font = Segoe UI 9pt
- Padding = 3px interno

**Resultado:** TextBox con borde fino, texto legible, coherente con el tema.

---

### 3. ComboBox: `EstilizarComboBox(ComboBox)`
Lista desplegable estilizada.

```csharp
TemaModerno.EstilizarComboBox(cboCategoria);
```

**Propiedades:**
- BackColor = Blanco
- Font = Segoe UI 9pt
- FlatStyle = Flat (elimina efecto 3D)

---

### 4. Botones de Éxito: `EstilizarBotonSuccess(Button)`
Para guardar, crear, confirmar.

```csharp
TemaModerno.EstilizarBotonSuccess(btnGuardar);
```

**Apariencia:**
- BackColor = Verde (#4CAF50)
- ForeColor = Blanco
- FlatStyle = Flat (sin relieve)
- MouseOver = Verde más oscuro (#3A8E3C)
- Height = 36px (botones grandes, fáciles de clickear)
- Font = Segoe UI 9pt Bold

**Uso:** Acciones positivas / de confirmación.

---

### 5. Botones de Peligro: `EstilizarBotonDanger(Button)`
Para eliminar, descartar.

```csharp
TemaModerno.EstilizarBotonDanger(btnEliminar);
```

**Apariencia:**
- BackColor = Rojo (#E74C3C)
- ForeColor = Blanco
- MouseOver = Rojo más oscuro (#C0392B)

**Uso:** Acciones irreversibles.

---

### 6. Botones Secundarios: `EstilizarBotonSecundario(Button)`
Para cancelar, limpiar, opcionales.

```csharp
TemaModerno.EstilizarBotonSecundario(btnCancelar);
```

**Apariencia:**
- BackColor = Gris claro (#E6E6E6)
- ForeColor = Gris oscuro (#333333)
- BorderStyle = Flat con borde 1px (#DDDDDD)
- MouseOver = Gris más claro (#DCDCDC)

**Uso:** Acciones opcionales, cancelaciones.

---

### 7. DataGridView: `EstilizarDataGridView(DataGridView)`
Tabla de datos con tema moderno.

```csharp
TemaModerno.EstilizarDataGridView(dgvLista);
```

**Encabezados:**
- BackColor = Azul primario (#0066CC)
- ForeColor = Blanco
- Font = Segoe UI 9pt Bold
- Height = 28px

**Celdas normales:**
- BackColor = Blanco
- ForeColor = Gris oscuro
- Selection = Azul claro (#C8DCFA)

**Filas alternas:**
- BackColor = Gris muy claro (#F9F9F9)
- Mejora legibilidad al leer filas largas

**Resultado:** Tabla profesional, fácil de leer, coherente con el tema.

---

## Cómo Conectar (Patrón de Uso)

### Paso 1: En FrmXXX_Load() - Aplicar estilos base

```csharp
private void FrmCategoria_Load(object sender, EventArgs e)
{
    // 1. Estilizar el formulario
    TemaModerno.EstilizarFormulario(this);
    
    // 2. Estilizar controles individuales
    TemaModerno.EstilizarTextBox(txtNombre);
    TemaModerno.EstilizarTextBox(txtDescripcion);
    TemaModerno.EstilizarCheckBox(chkEstado);
    
    // 3. Estilizar botones con función
    TemaModerno.EstilizarBotonSuccess(btnGuardar);      // Verde
    TemaModerno.EstilizarBotonDanger(btnEliminar);      // Rojo
    TemaModerno.EstilizarBotonSecundario(btnNuevo);     // Gris
    TemaModerno.EstilizarBotonSecundario(btnCancelar);  // Gris
    
    // 4. Agregar iconos (ver [[Iconografía]])
    btnNuevo.Text = IconosUI.Nuevo;      // ✏️ Nuevo
    btnGuardar.Text = IconosUI.Guardar;  // 💾 Guardar
    btnEliminar.Text = IconosUI.Eliminar;// 🗑️ Eliminar
    btnCancelar.Text = IconosUI.Cancelar;// ❌ Cancelar
    
    // 5. Estilizar tabla de datos (si existe)
    TemaModerno.EstilizarDataGridView(dgvLista);
    
    // 6. Continuar con lógica original
    Listar();
    LimpiarFormulario();
}
```

### Paso 2: El compilador lo aplica

1. **El formulario carga**
2. **FrmCategoria_Load() ejecuta** en este orden:
   - TemaModerno.EstilizarFormulario(this) → fondo #F5F5F5
   - Cada control se estiliza (colores, fuentes, bordes)
   - Se asignan iconos emoji a los botones
3. **Usuario ve la UI moderna** con coherencia visual

---

## Ventajas de esta Arquitectura

| Aspecto | Beneficio |
|---------|-----------|
| **Centralización** | Cambias colores en 1 lugar (TemaModerno.cs), se aplica a toda la app |
| **Reutilización** | Copias 2 líneas en cada formulario, no repites código |
| **Mantenibilidad** | Si haces rebranding, editas TemaModerno.cs nada más |
| **Flexibilidad** | Puedes aplicar solo algunos estilos o saltarte otros |
| **Separación** | Lógica de negocios ≠ Diseño visual |

---

## Flujo Completo de Carga

```
Usuario abre FrmCategoria
         ↓
FrmCategoria_Load() ejecuta
         ↓
1. TemaModerno.EstilizarFormulario(this)
   ├─ BackColor = #F5F5F5
   └─ Font = Segoe UI 9pt
         ↓
2. TemaModerno.EstilizarTextBox(txtNombre)
   ├─ BackColor = Blanco
   ├─ BorderStyle = FixedSingle
   └─ Font = Segoe UI 9pt
         ↓
3. TemaModerno.EstilizarBotonSuccess(btnGuardar)
   ├─ BackColor = #4CAF50 (Verde)
   ├─ ForeColor = Blanco
   └─ FlatStyle = Flat
         ↓
4. btnGuardar.Text = IconosUI.Guardar  → "💾 Guardar"
         ↓
5. TemaModerno.EstilizarDataGridView(dgvLista)
   ├─ Encabezados azules
   ├─ Celdas blancas
   └─ Filas alternas grises
         ↓
6. Listar()  ← lógica original (CRUD)
         ↓
UI moderna + funcionalidad original = ✅ Lista
```

---

## Ver También

- [[Iconografía]] - Cómo funcionan los emojis (IconosUI.cs)
- [[Capa de Presentación]] - Dónde viven los formularios
- [[Arquitectura multicapa]] - Contexto: Presentación es solo la capa visual
