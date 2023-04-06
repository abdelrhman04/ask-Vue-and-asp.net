<template>
  <div class="container mt-5">
  <table class="table table-hover">
  <thead class="">
    <tr>
      <th scope="col">#</th>
      <th scope="col">Name</th>
      <th scope="col">Price</th>
      <th scope="col">image</th>
      <th scope="col" v-if="role" >Delete</th>
      <th scope="col" v-if="role" >Update</th>
    </tr>
  </thead>
  <tbody>
    <tr v-for="item of product">
    
       <th scope="row">{{ item?.id }}</th>
      <td>{{ item?.name }}</td>
      <td>{{ item?.price }}</td>
      <td><img style="width: 60px;" :src='"https://localhost:7132/wwwroot/Files/Image/"+item?.image'  ></td> 
      <td v-if="role" ><button class="btn btn-danger " @click="delete_project(item?.id)">Delete</button></td>
      <td v-if="role" > <button class=" btn btn-primary " @click="update_project(item?.id)">Update</button></td>
    </tr>
  </tbody>
</table>
</div>
</template>

<script>
 import { mapActions } from 'vuex'
export default {
  name: 'HomeView',
  components: {
   
  },
  data() {
          return {
            
                product: {
                id: 0,
                name: "",
                price: 0,
                file: null,
                image: "_",
                },
                role:true,
                fileone:null,
          }
    },mounted() {
        this.getall();
        this.Role_();
    },
  methods: {
    ...mapActions({GetAll_Product:'auth/GetAll_Product',delete_Product:'auth/delete_Product'}),
    Role_(){
        
        if(localStorage.getItem('role')=='admin'){
          console.log(localStorage.getItem('role'))
          this.role= true
        }else{
          console.log(localStorage.getItem('role'))
          this.role= false
        }
      },
    async getall(){
     
        await this.GetAll_Product(this.product).then((data) => {
        this.product=data.data.data
        });
    },  async delete_project(id){
        await this.delete_Product(id)
        location.reload();
    },
    update_project(id){
      this.$router.replace({ name: "update_Product",params:{id} });
    }
    }
}
</script>
