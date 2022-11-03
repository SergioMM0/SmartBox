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

  constructor(private http: HttpService) {

  }

  async ngOnInit() {
    await this.getAllStandardBoxes();
  }

  async getAllStandardBoxes(){
    this.standardBoxes = await this.http.getAllStandardBoxes();
  }
}
