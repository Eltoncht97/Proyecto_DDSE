---
tags: [DSE, concepto, sql, tema3]
---
# Procedimientos almacenados

Un **procedimiento almacenado** (stored procedure) es una **orden con nombre que vive dentro de
SQL Server**. En vez de escribir el SQL desde C#, el [[Capa de Datos (DAO)|DAO]] le dice a SQL:
*"ejecuta tu receta `usp_Categoria_Insertar` con estos datos"*. (Tema 3)

## Ejemplos
```sql
-- Insertar (devuelve el Id nuevo)
CREATE PROCEDURE dbo.usp_Categoria_Insertar
    @Nombre NVARCHAR(60), @Descripcion NVARCHAR(150), @Estado BIT
AS
BEGIN
    INSERT INTO dbo.Categoria (Nombre, Descripcion, Estado)
    VALUES (@Nombre, @Descripcion, @Estado);
    SELECT CAST(SCOPE_IDENTITY() AS INT);   -- el Id que SQL generó
END

-- Listar
CREATE PROCEDURE dbo.usp_Categoria_Listar
AS
BEGIN
    SELECT IdCategoria, Nombre, Descripcion, Estado FROM dbo.Categoria ORDER BY Nombre;
END
```

## ¿Por qué usarlos? (Tema 3)
1. 🔒 **Seguridad**: usan [[Parámetros e inyección SQL|parámetros]] → evitan inyección SQL.
2. ⚡ **Rendimiento**: están precompilados.
3. 🧹 **Orden**: la lógica de datos vive centralizada en la base.

## Baja lógica
El "Eliminar" **no borra**: hace `UPDATE ... SET Estado = 0`. Así no se rompen los registros
relacionados (FK). El dato solo se marca como inactivo.

## 🔗 Relaciones
- Viven en: [[Base de datos]]
- Los llama: [[Capa de Datos (DAO)]]
- Seguridad: [[Parámetros e inyección SQL]]
- Tema del curso: [[Temas del curso (T1-T6)]] (Tema 3)
- Volver al [[Índice]]
