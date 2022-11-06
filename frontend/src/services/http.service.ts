import { Injectable } from '@angular/core';
import axios from 'axios';
import {MatSnackBar} from "@angular/material/snack-bar";
import {catchError} from "rxjs";

export const customAxios = axios.create(
  {
  baseURL: 'https://localhost:7114/'
})

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private matSnackBar : MatSnackBar) {
    customAxios.interceptors.response.use(
      response => {
        if(response.status>200 && response.status <299) {
          this.matSnackBar.open("Great success", undefined, {duration: 2000})
        }
        return response;
      }, rejected => {
        if(rejected.response.status>=400 && rejected.response.status <500) {
          matSnackBar.open(rejected.response.data);
        } else if (rejected.response.status>499) {
          this.matSnackBar.open("Something went wrong", "error", {duration: 3000})
        }
        catchError(rejected);
      }
    );
  }

  async getAllStandardBoxes() {
    const httpResponse = await customAxios.get<any>('box');
    return httpResponse.data;
  }


  async login(dto: any) {
    const httpResponse = await customAxios.get<any>('login', dto)
    return httpResponse.data;
  }

  async register(dto: any) {
    const httpResponse = await customAxios.post<any>('register', dto);
    return httpResponse.data;
  }
}
