# Tema Moderno - Arquitectura de Estilos

[[Arquitectura multicapa]] define la estructura de la app. Los estilos visuales se aplican exclusivamente en **Capa Presentación**.

> [!info] Diseño actual
> La UI es **100% escala de grises**, plana y minimalista. **No** hay colores de acento: ni azul, ni verde, ni rojo. Los botones se diferencian solo por la **intensidad del gris**, nunca por color.

## Ubicación

```
Restaurant.Presentacion/
├── Estilos/
│   └── TemaModerno.cs          ← Clase centralizada de estilos
├── Iconos/
│   └── IconosUI.cs             ← Constantes de emojis
├── Recursos/
│   ├── fondo_app.png           ← Fondo del MDI (a color original)
│   └── Imagenes/*.png          ← Tarjetas referenciales (200x200) por ventana
└── Frm*.cs                      ← Formularios que usan los estilos
```

## Filosofía

**Separación de responsabilidades:**
- **TemaModerno.cs** = Estilos visuales (colores, bordes, fuentes, tamaños)
- **Formularios** = Lógica de negocios (CRUD, validaciones, eventos)
- **Conexión** = Se hace en `FrmXXX_Load()` con una sola línea por control

## Paleta de Colores

Toda la paleta vive en la clase anidada `TemaModerno.Colores`. Es **escala de grises pura** (sin tintes de color):

```csharp
public static class Colores
{
    // ---- Escala de grises ----
    Color Primario        = RGB(70, 70, 70)     ← Gris oscuro: títulos, encabezado de grilla, acento
    Color Texto           = RGB(40, 40, 40)     ← Casi negro: texto principal
    Color TextoSecundario = RGB(130, 130, 130)  ← Gris medio: texto secundario
    Color Fondo           = RGB(245, 245, 245)  ← Gris muy claro: filas alternas / hover
    Color FondoFormulario = RGB(250, 250, 250)  ← Blanco roto: fondo de ventana
    Color Borde           = RGB(215, 215, 215)  ← Gris sutil: bordes
    Color Blanco          = White

    // ---- Botones (solo varían en intensidad de gris) ----
    Color Exito           = RGB(70, 70, 70)     ← Acción primaria (Guardar/Ingresar)
    Color ExitoHover      = RGB(50, 50, 50)
    Color Alerta          = RGB(140, 140, 140)  ← Acción destructiva (Eliminar)
    Color AlertaHover     = RGB(115, 115, 115)

    // ---- Grilla ----
    Color SeleccionGrilla = RGB(210, 210, 210)  ← Selección de fila (no azul)
    Color EncabezadoGrilla= RGB(70, 70, 70)     ← Cabecera de columnas
}
```

> [!warning] Sin colores de acento
> Esta paleta reemplaza por completo a la anterior. Ya **no existe** `#0066CC` (azul), `#4CAF50` (verde) ni `#E74C3C` (rojo). El botón primario es gris oscuro y el de peligro es gris medio: se distinguen por tono, no por color.

## Métodos Principales

Todos los helpers son métodos `static`. Se llaman una vez por control en el `Load` del formulario.

### 1. Formulario: `EstilizarFormulario(Form)`
Aplica el estilo base a toda la ventana.

```csharp
TemaModerno.EstilizarFormulario(this);
// BackColor = RGB(250,250,250), Font = Segoe UI 9pt
```

---

### 2. Entradas

| Método | Control | Efecto |
|--------|---------|--------|
| `EstilizarTextBox(TextBox)` | TextBox | Fondo blanco, texto casi negro, `BorderStyle.FixedSingle`, Segoe UI 9 |
| `EstilizarComboBox(ComboBox)` | ComboBox | Fondo blanco, `FlatStyle.Flat` (sin 3D), Segoe UI 9 |
| `EstilizarNumericUpDown(NumericUpDown)` | NumericUpDown | Fondo blanco, borde fino, Segoe UI 9 |
| `EstilizarDateTimePicker(DateTimePicker)` | DateTimePicker | Texto del calendario en gris oscuro, Segoe UI 9 |

#### `EstilizarCheckBox(CheckBox)`
```csharp
TemaModerno.EstilizarCheckBox(chkEstado);
```
Usa `FlatStyle.Flat` para **evitar el acento azul** que Windows 11 pinta en el check. El check marcado usa fondo gris (`Fondo`) y borde gris (`Borde`), con `UseVisualStyleBackColor = false`.

---

### 3. Botones

> [!tip] Diferenciación por intensidad
> Los tres botones son planos (`FlatStyle.Flat`), de 36px de alto y con `Cursor = Hand`. Cambian solo el tono de gris.

| Método | Uso | Apariencia |
|--------|-----|------------|
| `EstilizarBotonSuccess(Button)` | Guardar / Ingresar / confirmar | Fondo gris oscuro `RGB(70,70,70)`, texto blanco, hover `RGB(50,50,50)`, **negrita** |
| `EstilizarBotonDanger(Button)` | Eliminar / acción irreversible | Fondo gris medio `RGB(140,140,140)`, texto blanco, hover `RGB(115,115,115)`, **negrita** |
| `EstilizarBotonSecundario(Button)` | Cancelar / Nuevo / opcional | Fondo blanco, texto gris oscuro, borde 1px `Borde`, hover `Fondo` |
| `EstilizarBotonPrimario(Button)` | Acción de acento alterna | Fondo `Primario`, texto blanco, hover `RGB(50,50,50)`, **negrita** |

```csharp
TemaModerno.EstilizarBotonSuccess(btnGuardar);   // gris oscuro
TemaModerno.EstilizarBotonDanger(btnEliminar);   // gris medio
TemaModerno.EstilizarBotonSecundario(btnNuevo);  // blanco con borde
```

---

### 4. DataGridView: `EstilizarDataGridView(DataGridView)`
Tabla de datos en grises planos.

```csharp
TemaModerno.EstilizarDataGridView(dgvLista);
```

**Encabezados:**
- BackColor = gris oscuro `RGB(70,70,70)` (`EncabezadoGrilla`)
- ForeColor = Blanco, Segoe UI 9 **Bold**, alineado a la izquierda
- `EnableHeadersVisualStyles = false` y `SelectionBackColor` igual al fondo (la cabecera no cambia al seleccionar)
- Alto = 34px

**Celdas:**
- BackColor = Blanco, ForeColor = casi negro
- Selección = gris `RGB(210,210,210)` (`SeleccionGrilla`), texto se mantiene oscuro (**no azul**)
- `CellBorderStyle = SingleHorizontal`, columnas en modo `Fill`, filas de 28px

**Filas alternas:** gris muy claro `RGB(245,245,245)` para legibilidad.

> [!important] Checkboxes grises pintados a mano
> El método suscribe el evento `CellPainting` al manejador privado **`PintarCheckGris`**. Por cada celda de una `DataGridViewCheckBoxColumn` dibuja el check **en gris** en vez del check azul del sistema (Win11):
> - **Marcado** → caja gris oscuro (`Primario`) con un check blanco trazado con `DrawLines`.
> - **Sin marcar** → caja blanca con borde gris (`TextoSecundario`).
>
> Así ninguna columna booleana sale azul. La suscripción es idempotente (primero hace `-=` y luego `+=`).

---

### 5. Etiquetas

| Método | Uso | Efecto |
|--------|-----|--------|
| `EstilizarLabel(Label, bool esEncabezado)` | Label normal o de sección | Texto casi negro; si `esEncabezado=true`, gris `Primario` y 14pt Bold |
| `EstilizarTitulo(Label)` | Título principal (H1) de la ventana | Gris `Primario`, **15pt Bold**, fondo transparente |
| `EstilizarTotal(Label)` | Importe/total destacado | Gris `Primario`, 14pt Bold |

> [!note] Antes en azul
> `EstilizarTitulo` y `EstilizarTotal` reemplazan al antiguo título/total azul: ahora ambos usan el gris oscuro `Primario`.

```csharp
TemaModerno.EstilizarTitulo(lblTitulo);
TemaModerno.EstilizarTotal(lblTotal);
```

---

### 6. Menú y barra de estado

#### `EstilizarMenu(MenuStrip)`
Menú superior en grises planos.
- Fondo `Primario`, texto blanco, Segoe UI 9.
- Usa un `ToolStripProfessionalRenderer` con una `ProfessionalColorTable` propia (**`ColoresMenuGris`**) para que el **hover/selección no salga azul**: el resaltado usa `TextoSecundario` y el desplegable fondo blanco.

#### `EstilizarStatus(StatusStrip)`
Barra de estado inferior: fondo gris claro `Fondo`, texto casi negro, Segoe UI 9.

```csharp
TemaModerno.EstilizarMenu(menuPrincipal);
TemaModerno.EstilizarStatus(statusBarra);
```

---

### 7. Imágenes referenciales

#### `CargarImagen(string nombreArchivo)`
Carga una imagen **embebida como recurso** buscando por nombre de archivo (p. ej. `"categoria.png"`). Recorre `GetManifestResourceNames()`, devuelve una copia `Bitmap` independiente (cierra el stream con seguridad) o `null` si no existe.

#### `AgregarTarjetaReferencia(Form, string nombreImagen)`
Crea un `PictureBox` **cuadrado de 200x200** anclado a la **esquina superior derecha** (`Anchor = Top | Right`), con la imagen referencial de la ventana. Usa `SizeMode = Zoom` (sin barras) y devuelve el PictureBox (o `null` si no halló la imagen).

> [!tip] Recursos
> Las tarjetas viven en `Restaurant.Presentacion/Recursos/Imagenes/*.png`. El fondo del MDI es `Recursos/fondo_app.png` (a color original, es la única imagen no gris).

---

### 8. Alineación: `UniformarEntradas(Control, int ancho)`
Recorre **recursivamente** el contenedor y da el **mismo ancho** a todas las `TextBox` y `ComboBox`, para que los campos queden alineados.

```csharp
TemaModerno.UniformarEntradas(this, 380);
```

---

### 9. Barra de título gris MDI: `AplicarBarraTitulo(Form)`
Reemplaza el **marco nativo** (blanco/clásico) de una ventana **hija MDI** por una barra de título **gris plana** propia.

> [!info] ¿Por qué hace falta?
> El marco nativo de las ventanas hijas MDI **no se puede recolorear** con la API de Windows. Por eso se quita (`FormBorderStyle = None`) y se dibuja una barra propia.

Qué hace:
- Es **idempotente**: si ya es `FormBorderStyle.None`, no hace nada.
- Crece el alto 36px y mueve todo el contenido previo a un `Panel` interno.
- Agrega una barra gris `RGB(51,51,51)` con botones **minimizar / maximizar / cerrar** (el de cerrar tiene hover rojo solo en ese botón, como Windows).
- Implementa **arrastre** de la ventana hija dentro del área MDI (mouse down/move/up) y **doble clic** para maximizar/restaurar.

> [!warning] Orden de llamada
> Debe ser la **ÚLTIMA línea del `Load`**, después de agregar todos los controles (porque mueve el contenido existente al panel interno).

---

## Cómo Conectar (Patrón de Uso)

### En FrmXXX_Load() - Aplicar estilos

```csharp
private void FrmCategoria_Load(object sender, EventArgs e)
{
    // 1. Formulario
    TemaModerno.EstilizarFormulario(this);

    // 2. Entradas
    TemaModerno.EstilizarTextBox(txtNombre);
    TemaModerno.EstilizarTextBox(txtDescripcion);
    TemaModerno.EstilizarCheckBox(chkEstado);

    // 3. Botones (se diferencian por intensidad de gris)
    TemaModerno.EstilizarBotonSuccess(btnGuardar);      // gris oscuro
    TemaModerno.EstilizarBotonDanger(btnEliminar);      // gris medio
    TemaModerno.EstilizarBotonSecundario(btnNuevo);     // blanco con borde
    TemaModerno.EstilizarBotonSecundario(btnCancelar);  // blanco con borde

    // 4. Iconos (ver [[Iconografía]])
    btnNuevo.Text = IconosUI.Nuevo;
    btnGuardar.Text = IconosUI.Guardar;
    btnEliminar.Text = IconosUI.Eliminar;
    btnCancelar.Text = IconosUI.Cancelar;

    // 5. Tabla (checks grises automáticos vía CellPainting)
    TemaModerno.EstilizarDataGridView(dgvLista);

    // 6. Lógica original
    Listar();
    LimpiarFormulario();

    // 7. Cierre estándar de cada ventana (SIEMPRE al final, en este orden):
    TemaModerno.UniformarEntradas(this, 380);
    TemaModerno.AgregarTarjetaReferencia(this, "categoria.png");
    TemaModerno.AplicarBarraTitulo(this);   // ← última línea
}
```

> [!important] Las 3 líneas de cierre
> Cada ventana de mantenimiento/operación termina su `Load` con:
> `UniformarEntradas(this, 380)` → alinea campos · `AgregarTarjetaReferencia(this, "X.png")` → tarjeta arriba-derecha · `AplicarBarraTitulo(this)` → barra de título gris (debe ir al final).

---

## Ventajas de esta Arquitectura

| Aspecto | Beneficio |
|---------|-----------|
| **Centralización** | Cambias la paleta en 1 lugar (`Colores`), se aplica a toda la app |
| **Reutilización** | Copias una línea por control en cada formulario |
| **Mantenibilidad** | Para un rebranding, editas solo `TemaModerno.cs` |
| **Coherencia** | Gris uniforme: ningún control escapa con un acento de color del sistema |
| **Separación** | Lógica de negocios ≠ Diseño visual |

---

## Flujo Completo de Carga

```
Usuario abre FrmCategoria
         ↓
FrmCategoria_Load() ejecuta
         ↓
1. EstilizarFormulario(this)        → fondo RGB(250,250,250), Segoe UI 9
         ↓
2. EstilizarTextBox / CheckBox      → blanco, borde fino, check gris
         ↓
3. EstilizarBotonSuccess(btnGuardar)→ gris oscuro RGB(70,70,70), texto blanco
         ↓
4. btnGuardar.Text = IconosUI.Guardar
         ↓
5. EstilizarDataGridView(dgvLista)  → cabecera gris oscuro, selección gris,
                                       filas alternas grises, checks grises
         ↓
6. Listar()                          ← lógica original (CRUD)
         ↓
7. UniformarEntradas → AgregarTarjetaReferencia → AplicarBarraTitulo
         ↓
UI gris plana + funcionalidad original = ✅ Lista
```

---

## Ver También

- [[Iconografía]] - Cómo funcionan los emojis (IconosUI.cs)
- [[Capa de Presentación]] - Dónde viven los formularios
- [[Arquitectura multicapa]] - Contexto: Presentación es solo la capa visual
