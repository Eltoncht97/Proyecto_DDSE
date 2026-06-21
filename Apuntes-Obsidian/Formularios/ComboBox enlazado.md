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

## Caso real: elegir un pedido para editar (`FrmPedido`)
El mismo truco sirve para algo más que llenar una FK: en `FrmPedido` un combo
`cboBuscarPedido` lista los pedidos existentes para **elegir uno y cargarlo** en pantalla
y editarlo. Aquí el `DisplayMember` no es un simple nombre, sino una propiedad de resumen
de la entidad `Pedido`:

```csharp
// Llena el combo con los pedidos EDITABLES (no los ya pagados ni anulados).
cboBuscarPedido.DataSource = _pedidoBll.Listar()
    .Where(p => p.Situacion != "Pagado" && p.Situacion != "Anulado")  // filtro LINQ 🔎
    .ToList();
cboBuscarPedido.DisplayMember = "Resumen";   // "N° 5 · Mesa 3 · Juan · S/45.00 · Atendido"
cboBuscarPedido.ValueMember   = "IdPedido";  // el Id que usaremos para cargarlo
cboBuscarPedido.SelectedIndex = -1;          // arranca sin nada elegido
```

- **DisplayMember = "Resumen"** → `Pedido.Resumen` es una propiedad de solo lectura que arma
  un texto legible (`"N° X · Mesa · Cliente · S/Total · Situación"`). El combo puede mostrar
  cualquier propiedad de la entidad, no solo un `Nombre`.
- **`.Where(...)`** → con [[LINQ y lambdas]] filtras la lista **antes** de enlazarla, así el usuario solo
  ve los pedidos que tiene sentido editar. Un pedido `"Pagado"` o `"Anulado"` ni aparece.
- **`SelectedIndex = -1`** → deja el combo vacío al abrir, para que el usuario elija a propósito.

Al pulsar **Cargar**, se lee el `ValueMember` y se trae el pedido completo:
```csharp
if (cboBuscarPedido.SelectedIndex < 0 || cboBuscarPedido.SelectedValue == null) return;
int id = Convert.ToInt32(cboBuscarPedido.SelectedValue);  // toma el IdPedido elegido
Pedido p = _pedidoBll.ObtenerPorId(id);                   // cabecera + detalle desde la BLL
// ...luego se vuelcan cboMesa.SelectedValue, cboMozo, el detalle, etc.
```

> [!tip] DisplayMember puede ser una propiedad calculada
> No estás obligado a mostrar un campo crudo de la tabla. Si la entidad expone una propiedad
> como `Resumen` (texto armado en C#), el combo la muestra igual. Útil para que el usuario
> reconozca el registro de un vistazo.

## 🔗 Relaciones
- Tipo de control de: [[Capa de Presentación (Forms)]]
- Se llena desde: [[Capa de Negocio (BLL)]]
- Guarda una FK de: [[Base de datos]]
- Ver también: [[Eventos del Formulario]]
- Volver al [[Índice]]
