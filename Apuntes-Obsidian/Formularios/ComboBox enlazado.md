---
tags: [DSE, formulario, winforms, combobox]
---
# ComboBox enlazado (F5)

Cómo llenar un `ComboBox` con datos de la [[Capa de Negocio (BLL)]] (ej. `FrmPlato` con su
combo de categorías). Es un control del Tema 2.

## Enlazar la lista
```csharp
cboCategoria.DataSource = _categoriaBll.ListarActivas();  // lista de Categoria 📦
cboCategoria.DisplayMember = "Nombre";       // qué TEXTO muestra
cboCategoria.ValueMember   = "IdCategoria";  // qué VALOR guarda por dentro
```
- **DisplayMember** = la propiedad visible (lo que ve el usuario).
- **ValueMember** = la propiedad "oculta" que se usa para guardar (la FK).

## Leer lo elegido al guardar
```csharp
p.IdCategoria = Convert.ToInt32(cboCategoria.SelectedValue);  // toma el ValueMember
```

## Mostrar lo correcto al editar
```csharp
cboCategoria.SelectedValue = Convert.ToInt32(fila.Cells["IdCategoria"].Value);
```

> [!note] Por qué importa
> El combo muestra el **nombre** de la categoría, pero guarda su **Id** (la clave foránea de la
> [[Base de datos]]). Es el puente entre lo que ve el usuario y lo que entiende la BD.

## 🔗 Relaciones
- Tipo de control de: [[Capa de Presentación (Forms)]]
- Se llena desde: [[Capa de Negocio (BLL)]]
- Guarda una FK de: [[Base de datos]]
- Ver también: [[Eventos del Formulario]]
- Volver al [[Índice]]
