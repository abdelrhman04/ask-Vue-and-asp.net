  <template>

<nav class="navbar navbar-expand-lg bg-body-tertiary mb-5">
  <div class="container">
    <a class="navbar-brand">
      <router-link class="nav-item nav-link active" :to="{
                name:'home'
            }">Home</router-link>
    </a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarSupportedContent">
      
      <ul class="navbar-nav ms-auto mb-2 mb-lg-0">
        <!-- <li class="nav-item">
          <router-link class="nav-item nav-link " :to="{
                name:'dashboard'
            }">Dashboard</router-link>
        </li> -->
        <li class="nav-item" v-if="role">
          <router-link class="nav-item nav-link " :to="{
                name:'Add_Product'
            }">Add Product</router-link>
        </li>
        <li class="nav-item" v-if="!token_">
          <router-link class="nav-item nav-link " :to="{
                name:'signin'
            }">Sign In</router-link>
        </li>
        <li class="nav-item"   v-if="!token_"> 
          <router-link class="nav-item nav-link " :to="{
                name:'Register'
            }">Register</router-link>
        </li>
        <li class="nav-item"  v-if="token_">
          <a class="nav-item nav-link "  @click="logout()">Logout</a>
        </li>
      </ul>
    </div>
  </div>
</nav>
  </template>
  
  <script>
  export default {
    name: 'TheNavigation',
    data() {
          return {
            token_:true,
            role:true,
        }
    },
    mounted() {
        this.Auth_();
    },
  methods: {

    Auth_(){
        
      if(localStorage.getItem('token')){
        this.token_= true
      }else{
        this.token_= false
      }
      if(localStorage.getItem('role')=='admin'){
         
          this.role= true
        }else{
          
          this.role= false
        }
    },
    logout(){
        localStorage.removeItem('token')
        localStorage.removeItem('role')
        this.$router.replace({ name: "signin" });
    }
    }
  }
  </script>