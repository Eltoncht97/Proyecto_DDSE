---
tags: [DSE, formulario, winforms, mdi]
---
# Programa y MDI (F6)

Cómo **arranca** la app y cómo el menú abre los formularios. Parte de la
[[Capa de Presentación (Forms)]].

## `Program.cs` — el arranque
```csharp
static void Main()   // ← el PRIMER método que corre
{
    using (FrmLogin login = new FrmLogin())
        if (login.ShowDialog() == DialogResult.OK)   // si el login fue correcto...
            Application.Run(new FrmPrincipal());      // ...abre la ventana principal
}
```
Por eso al ejecutar (F5) ves primero el **Login** (`admin/admin123`) y luego el menú.

## `FrmPrincipal` — el contenedor MDI
Es la ventana grande con el menú (Mantenimientos, Operaciones, Reportes). Cada opción abre un
**formulario hijo dentro** de ella:
```csharp
private void mnuCategorias_Click(object sender, EventArgs e) { AbrirHijo(new FrmCategoria()); }
```
> **MDI** = *Multiple Document Interface*: una ventana padre que contiene varias ventanas hijas.

> [!note] `AbrirHijo` no duplica ventanas
> Antes de abrir, recorre `this.MdiChildren`: si ya hay una del mismo tipo, la **activa** y descarta la nueva (`hijo.Dispose()`). Así no abres dos veces el mismo mantenimiento.

## 🖼️ El fondo del MDI
El área gris central (la `MdiClient`) lleva una **imagen de fondo a color**: `Recursos/fondo_app.png`.
WinForms no deja poner `BackgroundImage` directo en el MDI, así que se dibuja **a mano**:
```csharp
area.Paint  += AreaMdi_Paint;    // dibuja la imagen en cada repintado
area.Resize += AreaMdi_Resize;   // invalida para redibujar al cambiar tamaño
// + se activa DoubleBuffered (por reflexión) para evitar parpadeo
```
> [!tip] `DoubleBuffered` es protegido
> Como no es público, se prende por **reflexión** (`GetProperty(... NonPublic)`), igual que la imagen se carga como **recurso embebido** con `Assembly.GetManifestResourceStream`.

## 🎨 Barra de título gris en las ventanas hijas
Las ventanas hijas (mantenimientos, pedidos, reportes) **no usan el marco azul nativo de Windows 11**.
En su `_Load` llaman a `TemaModerno.AplicarBarraTitulo(this)`, que reemplaza el marco por una **barra de título gris propia** (con botones minimizar / maximizar / cerrar y arrastre).

> [!warning] ¿Por qué una barra "a mano" y no recolorear el marco nativo?
> El marco nativo de una **hija MDI** *no se puede* recolorear con la API de Windows: la llamada a DWM (`DwmSetWindowAttribute`) **falla con `E_HANDLE`** sobre ese tipo de ventana. La única forma de tener el marco gris del [[Tema Moderno]] es quitar el marco nativo y pintar la barra nosotros.

Además, cada hija remata su `_Load` con dos toques visuales más:
- `AgregarTarjetaReferencia(this, "X.png")` → una **tarjeta de imagen referencial cuadrada** (arriba-derecha) que identifica la ventana. Las imágenes viven en `Recursos/Imagenes/*.png`.
- `UniformarEntradas(this, 380)` → da el **mismo ancho** a todas las cajas/combos (campos alineados).

> Detalle completo de estos helpers en [[Tema Moderno]].

## 🔗 Relaciones
- Abre los formularios de: [[Capa de Presentación (Forms)]]
- Cada formulario: [[Anatomía de un Formulario]]
- Volver al [[Índice]]
