import { ServerMappingEntry } from './server-mapping-entry';
import { Injectable } from '@angular/core';
import {Http, Response} from '@angular/http';

@Injectable()
export class ServermappingService {
  private apiurl = 'http://webapi/api/servermapping';
  private data: ServerMappingEntry[];
  // tslint:disable-next-line:max-line-length
  // private fakestring = '[{"servername":"hfsne121-037100","friendlyName":"Prod-Web-1"},{"servername":"hfsne121-037104","friendlyName":"Prod-App-1"}]';

  constructor(private http: Http) {
    console.log('ServermappingService-Constructor is running');
    this.getservermapping();
    this.retrieveData();
    // this.data = JSON.parse(this.fakestring) as ServerMappingEntry[]; //MOCKED
  }
  get Data() {
    return this.data;
  }
  private retrieveData() {
    return this.http.get(this.apiurl)
      .map((res: Response) => res.json());
  }
  private getservermapping() {
    this.retrieveData().subscribe(
      data => {
        console.log(data);
        this.data = data;
      }
    );
  }

  // these are mocked, to try when webAPI is unavailable
  // private retrieveData() {
  //   return JSON.parse(this.fakestring);
  // }
  // private getservermapping() {
  //   this.data = this.retrieveData();
  // }



}
