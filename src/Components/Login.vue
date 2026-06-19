<script setup>
import { ref } from 'vue'
import axios from 'axios'

const email = ref('')
const password = ref('')

const login = async () => {
  try {

    const response = await axios.post(
      'https://localhost:7044/api/Auth/login',
      {
        email: email.value,
        password: password.value
      }
    )

    localStorage.setItem(
      'token',
      response.data.token
    )

    alert('Login exitoso')

  } catch (error) {

    alert('Credenciales incorrectas')

    console.error(error)
  }
}
</script>

<template>
  <div class="container mt-5">

    <div class="row justify-content-center">

      <div class="col-md-4">

        <div class="card shadow">

          <div class="card-header bg-dark text-white">
            <h3>Login EliteShirts</h3>
          </div>

          <div class="card-body">

            <div class="mb-3">

              <label>Email</label>

              <input
                v-model="email"
                class="form-control" />

            </div>

            <div class="mb-3">

              <label>Contraseña</label>

              <input
                v-model="password"
                type="password"
                class="form-control" />

            </div>

            <button
              @click="login"
              class="btn btn-success w-100">

              Iniciar Sesión

            </button>

          </div>

        </div>

      </div>

    </div>

  </div>
</template>