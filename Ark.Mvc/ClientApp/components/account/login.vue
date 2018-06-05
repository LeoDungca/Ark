<template>
  <div class="col-sm-4 col-sm-offset-4">
    <h2>Log In</h2>
    <v-form @submit.prevent="submit">
      <label>
        Email:
        <input type="email" v-model="input.email"/>
      </label>
    
      <label>
        Password:
        <input type="password" v-model="input.password"/>
      </label>
      <button type="submit">Login</button>
    </v-form>
  </div>
</template>

<script src="./login.ts"></script>
