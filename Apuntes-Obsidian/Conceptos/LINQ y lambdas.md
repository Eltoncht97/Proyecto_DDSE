---
tags: [DSE, concepto, linq, tema5]
---
# LINQ y lambdas

**LINQ** permite **filtrar, ordenar y agrupar** listas con una línea. Se usa en la
[[Capa de Negocio (BLL)]]. (Tema 5)

## Expresión lambda
Es una mini-función anónima: `parámetro => qué hacer`.
```csharp
c => c.Estado          // "para cada c, quédate con las que tengan Estado verdadero"
p => p.Precio > 0      // "platos con precio mayor a 0"
```
Se lee como un **colador automático** 🥅.

## Operadores más usados
| Operador | Hace |
|---|---|
| `Where()` | filtra (deja los que cumplen) |
| `OrderBy()` | ordena |
| `Select()` | transforma/proyecta |
| `Sum()` | suma valores |
| `Count()` | cuenta |

## Ejemplos del proyecto
```csharp
_dao.Listar().Where(c => c.Estado).OrderBy(c => c.Nombre).ToList();   // categorías activas
pedido.Detalles.Sum(d => d.Subtotal);                                 // total del pedido
_dao.Listar().Where(e => e.Cargo == "Mozo").ToList();                 // solo mozos
```

## 🔗 Relaciones
- Se usa en: [[Capa de Negocio (BLL)]]
- Opera sobre listas de: [[Capa de Entidades]]
- Tema del curso: [[Temas del curso (T1-T6)]] (Tema 5)
- Volver al [[Índice]]
