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

## 🔗 Relaciones
- Abre los formularios de: [[Capa de Presentación (Forms)]]
- Cada formulario: [[Anatomía de un Formulario]]
- Volver al [[Índice]]
