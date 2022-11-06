import {Component, OnInit} from '@angular/core';
import {HttpService} from "../services/http.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  standardBoxes: any;
  columnsToDisplay = ['ID', 'Material', 'Price', 'Length', 'Width', 'Height'];
  deliveryAddress: any;
  loginSuccessful: boolean = false;
  userName: any;
  password: any;
  user : any;

  constructor(public http: HttpService) {

  }

  async ngOnInit() {
    await this.getAllStandardBoxes();
  }

  async getAllStandardBoxes(){
    this.standardBoxes = await this.http.getAllStandardBoxes();
  }

  async login(){
    let dto = {
      username: this.userName,
      password: this.password
    }
    this.user = await this.http.login(dto);
    console.log(this.user);
    this.loginSuccessful = true;
  }

  async register(){
    let dto= {
      username: this.userName,
      password: this.password
    }
    this.user = await this.http.register(dto);
    console.log(this.user);
    this.loginSuccessful = true;
  }
}
