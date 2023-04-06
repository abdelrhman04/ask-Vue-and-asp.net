import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import SignIn from'../views/SignIn.vue'
import Dashboard from '../views/Dashboard.vue'
import Register from '../views/Register.vue'
import Add_Product from '../views/Add_Product.vue'
import update_Product from '../views/update_Product.vue'
const auth = (to, from, next) => {
  if (localStorage.getItem("token")) {
    return next();
  } else {
    return next("/signin");
  }
};
const guest = (to, from, next) => {
  if (!localStorage.getItem("token")) {
    return next();
  } else {
    return next("/");
  }
};
const admin2 = (to, from, next) => {
  if (localStorage.getItem("token")&&localStorage.getItem("role")=='admin') {
    return next();
  } else {
    return next("/");
  }
};
const routes = [
  {
    path: '/',
    name: 'home',
    beforeEnter: auth,
    component: HomeView
  },
  {
    path: '/signin',
    name: 'signin',
  beforeEnter: guest,
    component: SignIn
  },
  {
    path: '/Register',
    name: 'Register',
   beforeEnter: guest,
    component: Register
  },
  {
    path: '/Dashboard',
    name: 'dashboard',
    beforeEnter: auth,
    component: Dashboard
  },
  {
    path: '/Add_Product',
    name: 'Add_Product',
    beforeEnter: admin2,
    component: Add_Product
  },
  {
    path: '/update_Product/:id',
    name: 'update_Product',
    beforeEnter: admin2,
    component: update_Product
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
