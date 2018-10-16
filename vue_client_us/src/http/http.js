import axios from 'axios'
export const HTTP = axios.create({
    baseURL: 'http://localhost:3538/',
    //headers: {
     //   'Content-Type': 'application/json',
     //   Authorization: 'Bearer ' 
    //}
})
