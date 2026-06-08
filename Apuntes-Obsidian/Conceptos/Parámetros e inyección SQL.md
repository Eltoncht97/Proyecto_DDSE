---
tags: [DSE, concepto, seguridad, tema3]
---
# Parámetros e inyección SQL

Los **`@parámetros`** son la forma segura de enviar datos a SQL. Son el **escudo directo** contra
la **inyección SQL** (Tema 3).

## La clave
Los datos viajan **separados** del texto del comando. Un atacante no puede "colar" comandos porque
su entrada se trata como un **valor**, nunca como código SQL.

```csharp
cmd.Parameters.AddWithValue("@Nombre", c.Nombre);   // ✅ seguro
// NUNCA: "INSERT ... VALUES ('" + c.Nombre + "')"   // ❌ vulnerable
```

> [!warning] Importante
> Lo que protege son los **parámetros**, NO el [[Procedimientos almacenados|procedimiento]] en sí.
> Se pueden usar parámetros incluso sin procedimiento. El procedimiento **ayuda**, pero el escudo
> es mandar los datos como `@parámetros`.

## En el proyecto
Cada [[Capa de Datos (DAO)|DAO]] usa `cmd.Parameters.AddWithValue("@x", valor)` para todas sus
operaciones de escritura y búsqueda.

## 🔗 Relaciones
- Se usan en: [[Capa de Datos (DAO)]] y [[Procedimientos almacenados]]
- Tema del curso: [[Temas del curso (T1-T6)]] (Tema 3)
- Volver al [[Índice]]
