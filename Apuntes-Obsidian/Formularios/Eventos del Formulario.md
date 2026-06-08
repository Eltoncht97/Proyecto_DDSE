---
tags: [DSE, formulario, winforms, eventos]
---
# Eventos del Formulario (F4)

Un **evento** = "cuando el usuario hace X, ejecuta este código". Aquí todo cobra sentido.
Parte del [[Archivo de lógica del Form]].

## Clic en la grilla → cargar el registro
Pone los datos de la fila en las cajas y cambia a **modo edición** (`_idActual > 0`):
```csharp
private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
{
    DataGridViewRow fila = dgvLista.Rows[e.RowIndex];
    _idActual = Convert.ToInt32(fila.Cells["IdCategoria"].Value);   // ahora hay selección
    txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
}
```

## Guardar → insertar o modificar (decide `_idActual`)
```csharp
private void btnGuardar_Click(object sender, EventArgs e)
{
    try
    {
        Categoria c = new Categoria { IdCategoria = _idActual,
                                      Nombre = txtNombre.Text.Trim(),
                                      Estado = chkEstado.Checked };   // arma la caja 📦
        if (_idActual == 0) _bll.Registrar(c);   // modo nuevo  → INSERT
        else                _bll.Modificar(c);   // modo edición → UPDATE
        Listar(); LimpiarFormulario();
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message, "Validación");   // atrapa el error del BLL
    }
}
```

> [!tip] El `try/catch` y la validación
> Si el [[Capa de Negocio (BLL)|BLL]] lanza un error (ej. nombre vacío), el `catch` lo **atrapa**
> y lo muestra al usuario. Por eso validamos en el BLL: el formulario solo muestra el mensaje.

## 🔗 Relaciones
- Antes: [[Archivo de lógica del Form]]
- Llama a: [[Capa de Negocio (BLL)]] → [[Capa de Datos (DAO)]] → [[Base de datos]]
- El recorrido completo: [[Flujo de datos]]
- Volver al [[Índice]]
