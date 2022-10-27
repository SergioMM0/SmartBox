import {Component, OnInit} from '@angular/core';
import {HttpService} from "../services/http.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  standardBoxes: any;

  constructor(private http: HttpService) {

  }

  async ngOnInit() {
    const boxes = await this.http.getAllBoxes();
    console.log(boxes);

    await this.getAllStandardBoxes();
  }

  async getAllStandardBoxes(){
    this.standardBoxes = await this.http.getAllStandardBoxes();
  }
}
