---
tags: [DSE, formulario, winforms, designer]
---
# Archivo Designer (F2)

`FrmX.Designer.cs` contiene el **diseño**. Lo genera Visual Studio al arrastrar controles.
Parte de la [[Anatomía de un Formulario]].

## Los 3 momentos de TODO control 🔑
Ejemplo con `txtNombre`:

1. **Se declara** (al final) — anuncia que existe (vale `null`):
```csharp
private System.Windows.Forms.TextBox txtNombre;
```
2. **Se crea y configura** (dentro de `InitializeComponent`) — cobra vida con `new`:
```csharp
this.txtNombre = new System.Windows.Forms.TextBox();   // ← nace
this.txtNombre.Location = new System.Drawing.Point(120, 52);
this.txtNombre.Size = new System.Drawing.Size(280, 23);
```
3. **Se agrega** al formulario — aparece en pantalla:
```csharp
this.Controls.Add(this.txtNombre);
```

```
declarar (null)  →  new + propiedades (vivo)  →  Controls.Add (visible)
```

## Los botones: 4º paso → conectar el evento
```csharp
this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
```
*"cuando hagan **Click**, ejecuta `btnGuardar_Click`"* (que vive en el [[Archivo de lógica del Form]]).

## Detalles que puedes ignorar
- `SuspendLayout()`/`ResumeLayout()` → rendimiento al colocar controles.
- `Dispose()` → libera memoria al cerrar.

## 🔗 Relaciones
- Antes: [[Anatomía de un Formulario]] · Después: [[Archivo de lógica del Form]] y [[Eventos del Formulario]]
- Caso con combo: [[ComboBox enlazado]]
- Volver al [[Índice]]
