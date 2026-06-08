---
tags: [DSE, concepto, poo, tema2]
---
# POO — Clase y Objeto

Conceptos base de la Programación Orientada a Objetos (Tema 2). Se usan en la [[Capa de Entidades]].

## Clase vs Objeto 🧁
- **Clase** = el **molde** (la receta). Se escribe **una sola vez**.
- **Objeto** = cada **cupcake** que sale del molde. Se crea con `new`.

```csharp
Categoria postre = new Categoria();   // crea UN objeto (cupcake)
postre.Nombre = "Postres";            // le pone datos
```

## Miembros de una clase
| Miembro | Qué es | Ejemplo |
|---|---|---|
| **Propiedad** | un dato del objeto (`get`/`set`) | `public string Nombre { get; set; }` |
| **Constructor** | corre al crear el objeto | `public Categoria() { Estado = true; }` |
| **Método** | una acción del objeto | `public string Estado() {...}` |

## Encapsulamiento
`get` y `set` controlan cómo se lee/escribe un dato → protege la información (Tema 2).

## 🔗 Relaciones
- Se aplica en: [[Capa de Entidades]]
- Forma parte de: [[Temas del curso (T1-T6)]] (Tema 2)
- Volver al [[Índice]]
