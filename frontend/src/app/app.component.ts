import {Component, OnInit} from '@angular/core';
import {HttpService} from "../services/http.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  constructor(private http: HttpService) {

  }

  async ngOnInit() {
    const boxes = await this.http.getProducts();
    console.log(boxes);

    //21:25
  }
}
