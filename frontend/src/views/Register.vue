<template>
   

    <div class="container w-50">
        <form v-on:submit.prevent="submit">
            <div class="mb-3">
                <label for="email" class="form-label">Email</label>
                <input  type="email" class="form-control" name="email" id="email" v-model="user.email">
            </div>
            <div class="mb-3">
                <label for="username" class="form-label">Username</label>
                <input  type="text" class="form-control" name="username" id="username" v-model="user.userName">
            </div>
            <div class="mb-3">
                <label for="password" class="form-label">Password</label>
                <input  class="form-control" type="password" nam="password" id="password"  v-model="user.passwordHash">
            </div>
            <div class="mb-3">
                <label for="phoneNumber" class="form-label">Phone</label>
                <input  class="form-control" type="text" nam="phoneNumber" id="phoneNumber"  v-model="user.phoneNumber">
            </div>
            <div>
            <input type="text" hidden name="role" id="role" v-model="role">
        </div>
            <button type="submit" class="btn d-block mx-auto w-25 btn-primary">Sign Up</button>
        </form>
    </div>


  </template>
  
  <script>
  import { mapActions } from 'vuex'
  export default {
    name: 'Sign-in',
    components: {
     
    },
    data() {
          return {
            
                user: {
                id: "",
                userName: "",
                email: "",
                passwordHash: "",
                phoneNumber: "",
                },
                role: "customer",
           
            response:{}
          }
    },
    methods: {
        ...mapActions({Register:'auth/Register'}),
       async submit(){
        let formuser = {user: {},Role:""} 
        formuser.user=this.user
        formuser.Role=this.role
        this.Register(formuser).then(() => {
            this.$router.replace({
                name: 'signin',
            })
        });
       }
    }
  }
  </script>