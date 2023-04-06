<template>
    
    <div class="container">
    <form v-on:submit.prevent="update_product">
  <div class="mb-3">
    <label for="Name" class="form-label">Name</label>
    <input  type="text" class="form-control" name="Name" id="Name" v-model="product.name">
  </div>
  <div class="mb-3">
    <label for="Price" class="form-label">Price</label>
    <input  class="form-control" type="number" nam="Price" id="Price" v-model="product.price">
  </div>
  <div class="mb-3">
  <label for="file" class="form-label">Image</label>
  <input class="form-control" type="file"  id="file" v-on:change="onFileSelected">
</div>
  <button type="submit" class="btn d-block mx-auto w-25 btn-primary">Update</button>
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
                name: "",
                price: 0,
                file: null,
                image: "",
                },

                fileone:null,
          }
    },mounted() {
      
        this.getproduct();
    },
    methods: {
        ...mapActions({get_product:'auth/get_product',Update_Product:'auth/Update_Product'}),
      
       async getproduct(){
      await this.get_product(this.$route.params.id).then((data) => {
        this.product=data.data.data
         console.log(this.product);
        });
       },
       async update_product(){

        this.product.file =this.fileone
      await this.Update_Product(this.product)
      this.$router.replace({
                name: 'home',})
       },
       onFileSelected(event) {
      this.fileone= event.target.files[0];
    },
   
    }
  }
  </script>