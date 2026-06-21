---
tags: [DSE, capa, negocio, bll, tema5]
---
# Capa de Negocio (BLL)

Proyecto `Restaurant.Negocio`. Es el **jefe de cocina** 👨‍🍳: pone las **reglas** y valida antes de
tocar la base. Intermediario entre los [[Capa de Presentación (Forms)|formularios]] y la
[[Capa de Datos (DAO)]].

> **BLL** = *Business Logic Layer*. El formulario **nunca** habla directo con el DAO: pasa por aquí.

## Validar primero, guardar después
```csharp
public class CategoriaBLL
{
    private readonly CategoriaDAO _dao = new CategoriaDAO();   // el BLL TIENE un DAO

    public int Registrar(Categoria c)
    {
        Validar(c);                  // 1) si algo está mal, lanza error y NO sigue
        return _dao.Insertar(c);     // 2) si pasó, recién guarda
    }

    private void Validar(Categoria c)
    {
        if (string.IsNullOrWhiteSpace(c.Nombre))
            throw new ApplicationException("El nombre es obligatorio.");  // ← la regla
    }
}
```
Si la validación falla, el error sube hasta el formulario y se muestra en un `MessageBox`
(ver [[Eventos del Formulario]]).

## Súper-poder: [[LINQ y lambdas|LINQ]] (Tema 5)
```csharp
public List<Categoria> ListarActivas() =>
    _dao.Listar().Where(c => c.Estado).OrderBy(c => c.Nombre).ToList();
```

## Caso real: `PedidoBLL` (registrar **y** editar)
El BLL de pedidos hace lo mismo que `CategoriaBLL` pero con un par de reglas más, porque
ahora `FrmPedido` no solo inserta: también deja **cargar un pedido y editarlo**.

### El total NO viene del formulario: lo calcula el BLL con [[LINQ y lambdas|LINQ]]
Tanto al **registrar** como al **actualizar**, el total se recalcula sumando el subtotal de
cada línea del detalle. Así el formulario nunca puede "mentir" con el importe.
```csharp
// Tema 5 - LINQ: el total sale del detalle, no de la pantalla.
pedido.Total = pedido.Detalles.Sum(d => d.Subtotal);
```

### `ObtenerPorId` — traer un pedido para editarlo
Pide la **cabecera** y el **detalle** por separado a la [[Capa de Datos (DAO)]] y los une.
Valida que el id sea válido y que el pedido exista antes de devolverlo.
```csharp
public Pedido ObtenerPorId(int idPedido)
{
    if (idPedido <= 0)
        throw new ApplicationException("Seleccione un pedido válido.");

    Pedido pedido = _dao.ObtenerPorId(idPedido);     // cabecera
    if (pedido == null)
        throw new ApplicationException("No se encontró el pedido N° " + idPedido + ".");

    pedido.Detalles = _dao.ObtenerDetalle(idPedido); // detalle (líneas)
    return pedido;
}
```

### `ActualizarPedido` — validar, recalcular y guardar
Mismo patrón de siempre (**validar primero, guardar después**), agregando la regla de que el
`IdPedido` sea válido para actualizar. Recalcula el total y delega en el DAO, que por dentro
lo resuelve con una [[Transacción (Commit y Rollback)]].
```csharp
public void ActualizarPedido(Pedido pedido)
{
    if (pedido == null)            throw new ApplicationException("No hay datos del pedido.");
    if (pedido.IdPedido <= 0)      throw new ApplicationException("Pedido no válido para actualizar.");
    if (pedido.IdMesa <= 0)        throw new ApplicationException("Debe seleccionar una mesa.");
    if (pedido.IdEmpleado <= 0)    throw new ApplicationException("Debe seleccionar el mozo que atiende.");
    if (pedido.Detalles == null || pedido.Detalles.Count == 0)
        throw new ApplicationException("Debe agregar al menos un plato al pedido.");

    pedido.Total = pedido.Detalles.Sum(d => d.Subtotal);  // LINQ: recalcula el total
    _dao.Actualizar(pedido);
}
```

> [!tip] Registrar vs Actualizar
> - `RegistrarPedido` → si no hay situación, la pone en **"Atendido"** (es nuevo).
> - `ActualizarPedido` → **no toca** la situación: el DAO la preserva al guardar.
> - El formulario decide cuál llamar según `_idPedido` (0 = nuevo, >0 = editando).
> - Las dos comparten las mismas validaciones y el **mismo cálculo de total con LINQ**.

## 🔗 Relaciones
- Pone reglas sobre: [[Capa de Entidades]]
- Le pide datos a: [[Capa de Datos (DAO)]]
- La usa: [[Capa de Presentación (Forms)]]
- Filtra con: [[LINQ y lambdas]]
- Dispara: [[Transacción (Commit y Rollback)]] (en pedidos)
- Volver al [[Índice]]
