<template>

    <div class="container">
        <form v-on:submit.prevent="submit">
            <div class="mb-3">
                <label for="Name" class="form-label">Name</label>
                <input  type="text" class="form-control" name="Name" id="Name" v-model="product.Name">
            </div>
            <div class="mb-3">
                <label for="Price" class="form-label">Price</label>
                <input  class="form-control" type="number" nam="Price" id="Price" v-model="product.Price">
            </div>
            <div class="mb-3">
                <label for="file" class="form-label">Image</label>
                <input class="form-control" type="file"  id="file" v-on:change="onFileSelected">
            </div>
            <button type="submit" class="btn d-block mx-auto w-25 btn-primary">Add</button>
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
            
                product: {
                id: 0,
                Name: "",
                Price: 0,
                file: null,
                Image: "_",
                },

                fileone:null,
          }
    },
    methods: {
        ...mapActions({Add_product:'auth/Add_product'}),
       async submit(){
       this.product.file =this.fileone
        this.Add_product(this.product).then(() => {
        });
       },
       onFileSelected(event) {
      this.fileone= event.target.files[0];
    }
    }
  }
  </script>