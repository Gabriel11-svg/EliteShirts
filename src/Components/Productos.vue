<script setup>
import { ref, onMounted } from 'vue'
import axios from 'axios'

const productos = ref([])

const nuevoProducto = ref({
  id: 0,
  nombre: '',
  descripcion: '',
  precio: 0,
  stock: 0
})

const modoEdicion = ref(false)

const cargarProductos = async () => {
  try {
    const response = await axios.get(
      'https://localhost:7044/api/Productos'
    )

    productos.value = response.data
  } catch (error) {
    console.error(error)
  }
}

const guardarProducto = async () => {
  try {

    if (modoEdicion.value) {

      await axios.put(
        `https://localhost:7044/api/Productos/${nuevoProducto.value.id}`,
        nuevoProducto.value
      )

      modoEdicion.value = false

    } else {

      await axios.post(
        'https://localhost:7044/api/Productos',
        {
          nombre: nuevoProducto.value.nombre,
          descripcion: nuevoProducto.value.descripcion,
          precio: nuevoProducto.value.precio,
          stock: nuevoProducto.value.stock
        }
      )

    }

    limpiarFormulario()
    cargarProductos()

  } catch (error) {
    console.error(error)
  }
}

const editarProducto = (producto) => {

  nuevoProducto.value = {
    id: producto.id,
    nombre: producto.nombre,
    descripcion: producto.descripcion,
    precio: producto.precio,
    stock: producto.stock
  }

  modoEdicion.value = true
}

const eliminarProducto = async (id) => {

  if (!confirm('¿Desea eliminar este producto?'))
    return

  try {

    await axios.delete(
      `https://localhost:7044/api/Productos/${id}`
    )

    cargarProductos()

  } catch (error) {
    console.error(error)
  }
}

const limpiarFormulario = () => {

  nuevoProducto.value = {
    id: 0,
    nombre: '',
    descripcion: '',
    precio: 0,
    stock: 0
  }
}

onMounted(() => {
  cargarProductos()
})
</script>

<template>
  <div class="container mt-4">

    <div class="card shadow mb-4">

      <div class="card-header bg-success text-white">
        <h3>
          {{ modoEdicion ? 'Editar Producto' : 'Agregar Producto' }}
        </h3>
      </div>

      <div class="card-body">

        <div class="row g-2">

          <div class="col-md-3">
            <input
              v-model="nuevoProducto.nombre"
              class="form-control"
              placeholder="Nombre" />
          </div>

          <div class="col-md-3">
            <input
              v-model="nuevoProducto.descripcion"
              class="form-control"
              placeholder="Descripción" />
          </div>

          <div class="col-md-2">
            <input
              v-model="nuevoProducto.precio"
              type="number"
              class="form-control"
              placeholder="Precio" />
          </div>

          <div class="col-md-2">
            <input
              v-model="nuevoProducto.stock"
              type="number"
              class="form-control"
              placeholder="Stock" />
          </div>

          <div class="col-md-2 d-grid">
            <button
              @click="guardarProducto"
              class="btn btn-success">
              {{ modoEdicion ? 'Actualizar' : 'Guardar' }}
            </button>
          </div>

        </div>

      </div>

    </div>

    <div class="card shadow">

      <div class="card-header bg-dark text-white">
        <h2>EliteShirts - Gestión de Productos</h2>
      </div>

      <div class="card-body">

        <table class="table table-striped table-hover">

          <thead class="table-dark">
            <tr>
              <th>ID</th>
              <th>Nombre</th>
              <th>Descripción</th>
              <th>Precio</th>
              <th>Stock</th>
              <th>Acciones</th>
            </tr>
          </thead>

          <tbody>

            <tr
              v-for="producto in productos"
              :key="producto.id">

              <td>{{ producto.id }}</td>
              <td>{{ producto.nombre }}</td>
              <td>{{ producto.descripcion }}</td>
              <td>RD$ {{ producto.precio }}</td>
              <td>{{ producto.stock }}</td>

              <td>

                <button
                  class="btn btn-warning btn-sm me-2"
                  @click="editarProducto(producto)">
                  Editar
                </button>

                <button
                  class="btn btn-danger btn-sm"
                  @click="eliminarProducto(producto.id)">
                  Eliminar
                </button>

              </td>

            </tr>

          </tbody>

        </table>

      </div>

    </div>

  </div>
</template>