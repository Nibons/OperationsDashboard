import { ServerMappingEntry } from './../server-mapping-entry';
import { ServermappingService } from './../servermapping.service';
import { Component, OnInit } from '@angular/core';
import { Http, Response } from '@angular/http';
import 'rxjs/add/operator/map';

@Component({
  selector: 'app-servermapping',
  templateUrl: './servermapping.component.html',
  styleUrls: ['./servermapping.component.css']
})
export class ServermappingComponent implements OnInit {
  private apiurl = 'http://webapi/api/servermapping';
  private data: ServerMappingEntry[];

  constructor(service: ServermappingService) {
    console.log('component-servermapping-constructor is running');
    this.data = service.Data;
  }

  ngOnInit() {
    console.log('component-servermapping-ngOnInit is running');
  }


}


