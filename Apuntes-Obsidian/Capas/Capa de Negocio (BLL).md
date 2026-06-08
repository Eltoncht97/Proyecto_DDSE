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

## 🔗 Relaciones
- Pone reglas sobre: [[Capa de Entidades]]
- Le pide datos a: [[Capa de Datos (DAO)]]
- La usa: [[Capa de Presentación (Forms)]]
- Filtra con: [[LINQ y lambdas]]
- Dispara: [[Transacción (Commit y Rollback)]] (en pedidos)
- Volver al [[Índice]]
