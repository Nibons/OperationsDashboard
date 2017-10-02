import { Component, OnInit } from '@angular/core';
import { Http,Response } from '@angular/http';
import 'rxjs/add/operator/map';

@Component({
  selector: 'app-servermapping',
  templateUrl: './servermapping.component.html',
  styleUrls: ['./servermapping.component.css']
})
export class ServermappingComponent implements OnInit {
  private apiurl = 'http://webapi/api/servermapping';
  private data: ServerMappingEntry[];
//should move this to services
  constructor(private http: Http) { 
    console.log("component-servermapping-constructor is running");
    this.getservermapping();
    this.getdata();
  }

  ngOnInit() {
    console.log("component-servermapping-ngOnInit is running");
  }
  getdata() {
    return this.http.get(this.apiurl)
      .map((res: Response) => res.json())
  }
  getservermapping() {
    this.getdata().subscribe(
      data => {
        console.log(data);
        this.data = data
      }
    )
  }
}

interface ServerMappingEntry {
  id: number;
  servername: string;
  friendlyname: string;
  logicalEnvironment: string;
  environment: string;
  function: string;
  ipAddress: string;
  dnsHost: string;
}
