

import {instance,instanceproduct}  from '@/store/axiosInstance';
export default{
    namespaced: true,
  state: {
    token: 'token',
    user:null,
   
  },
  getters: {
  },
  mutations: {
  },
  actions: {
    async signIn(_,credentials){
        let response =await  instance.post('User/Login',credentials)
        console.log(credentials);
        if(response?.data?.code==200){
          localStorage.setItem('token', response?.data?.data?.token);
           localStorage.setItem('role', response?.data?.data?.role);
        }
    },
    async Register(_,credentials){
      console.log(instance)
      let response = await instance.post('User/Register',credentials)
      console.log(response);
  },
  async Add_product(_,credentials){
    console.log(credentials);
    let response = await instanceproduct.post('Product/Add-Product',credentials)
    console.log(response);
},
async get_product(_,credentials){
  console.log(credentials);
  let response = await instanceproduct.get('Product/Get-Product?Id='+credentials)
 
 return response // console.log(response,credentials);
},
async Update_Product(_,credentials){
  let response = await instanceproduct.post('Product/Update-Product',credentials)
 
console.log(response);
},
async delete_Product(_,credentials){
  let response = await instance.delete('Product/Delete-Product?Id='+credentials)
console.log(response);
},
async GetAll_Product(_,credentials){
  let response = await instanceproduct.get('Product/GetAll-Product')
  return response
},
  },
  modules: {
  
  }
}
