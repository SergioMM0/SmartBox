import { Injectable } from '@angular/core';
import axios from 'axios';

export const customAxios = axios.create(
  {
  baseURL: 'https://localhost:7114/'
})

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor() { }

  async getAllBoxes(){
    const httpResponse = await customAxios.get<any>('Box');
    return httpResponse.data;
  }

  async getAllStandardBoxes() {
    const httpResponse = await customAxios.get<any>('box');
    return httpResponse.data;
  }
}
