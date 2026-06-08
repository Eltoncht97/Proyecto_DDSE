---
tags: [DSE, formulario, winforms]
---
# Anatomía de un Formulario (F1)

Todo `Form` es **una clase partida en 2 archivos**. Parte de la [[Capa de Presentación (Forms)]].

| Archivo | Contiene | Quién lo edita |
|---|---|---|
| `FrmCategoria.Designer.cs` | el **diseño** (controles, posición) → [[Archivo Designer]] | Visual Studio |
| `FrmCategoria.cs` | la **lógica** (eventos) → [[Archivo de lógica del Form]] | tú |

## `partial class` — la palabra mágica
Permite que **dos archivos** sean **la misma clase**:
```csharp
public partial class FrmCategoria : Form   // ': Form' = HEREDA de Form (ya es una ventana)
{ ... }
```
- `: Form` → **herencia**: recibe gratis el botón cerrar, minimizar, mover, etc.

## El constructor enciende el formulario
```csharp
public FrmCategoria()
{
    InitializeComponent();   // ← construye TODOS los controles (vive en el Designer)
}
```
> [!warning] Sin `InitializeComponent()`
> No da error de compilación, pero el formulario sale **vacío** y cualquier control valdría `null`
> → `NullReferenceException`.

## 🔗 Relaciones
- Siguiente: [[Archivo Designer]] → [[Archivo de lógica del Form]] → [[Eventos del Formulario]]
- Pertenece a: [[Capa de Presentación (Forms)]]
- Concepto base: [[POO - Clase y Objeto]]
- Volver al [[Índice]]
