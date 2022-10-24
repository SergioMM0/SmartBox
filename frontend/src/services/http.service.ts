import { Injectable } from '@angular/core';
import axios from 'axios';

export const customAxios = axios.create(
  {
  baseURL: 'https://localhost:7114/'
})

/* ------------------------ Might be a solution ------------------------
export const customAxios = axios.create(
  {
    baseURL: "",
    withCredentials: false,
    headers: {
      'Access-Control-Allow-Origin' : '*',
      'Access-Control-Allow-Methods':'GET,PUT,POST,DELETE,PATCH,OPTIONS',
    }
})
 */

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor() { }

  async getAllBoxes(){
    const httpResponse = await customAxios.get<any>('Box');
    return httpResponse.data;
  }
}
