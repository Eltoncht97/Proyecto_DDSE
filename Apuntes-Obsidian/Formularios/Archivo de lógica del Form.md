---
tags: [DSE, formulario, winforms]
---
# Archivo de lógica del Form (F3)

`FrmX.cs` contiene **lo que tú programas**. Parte de la [[Anatomía de un Formulario]].

## 1) Campos: la "memoria" del formulario
```csharp
private readonly CategoriaBLL _bll = new CategoriaBLL();  // puente a [[Capa de Negocio (BLL)]]
private int _idActual = 0;                                 // ¿qué registro está seleccionado?
```
- `_bll` → el form pide cosas al **BLL** (nunca al DAO directo).
- `_idActual` → el dato más importante:
  - `0` → **modo nuevo** (al guardar, *inserta*).
  - `> 0` → **modo edición** (al guardar, *modifica*).

## 2) Evento `Load`: lo primero al abrir
```csharp
private void FrmCategoria_Load(object sender, EventArgs e)
{
    Listar();              // llena la grilla
    LimpiarFormulario();   // deja todo en blanco
}
```

## 3) Métodos ayudantes
```csharp
private void Listar() => dgvLista.DataSource = _bll.ListarTabla();   // ver [[Flujo de datos]]

private void LimpiarFormulario()
{
    _idActual = 0;             // ← vuelve a "modo nuevo"
    txtNombre.Clear();
    chkEstado.Checked = true;
}
```

## 🔗 Relaciones
- Antes: [[Archivo Designer]] · Después: [[Eventos del Formulario]]
- Usa: [[Capa de Negocio (BLL)]]
- Muestra datos vía: [[Flujo de datos]]
- Volver al [[Índice]]
