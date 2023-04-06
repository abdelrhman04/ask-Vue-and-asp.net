<template>

 <div class="container w-50">
        <form v-on:submit.prevent="submit">
            <div class="mb-3">
                <label for="email" class="form-label">Email</label>
                <input  type="email" class="form-control" name="email" id="email" v-model="form.email">
            </div>
            <div class="mb-3">
                <label for="password" class="form-label">Password</label>
                <input  class="form-control" type="password" nam="password" id="password"  v-model="form.password">
            </div>
            <button type="submit" class="btn d-block mx-auto w-25 btn-primary">Sign in</button>
        </form>
    </div>
  </template>
  
  <script>
  import { mapActions } from 'vuex'
  import axios from 'axios'
  export default {
    name: 'Sign-in',
    components: {
     
    },
    data() {
          return {
            form: {
                password:'',
                email: '',
                response:{}
            },
            response:{}
          }
    },
    methods: {
        ...mapActions({signIn:'auth/signIn'}),
        
       async submit(){
        this.signIn(this.form).then(() => {
           
                this.$router.replace({
                name: 'home',
            })
        window.location.reload();
        });
       }
    }
  }
  </script>