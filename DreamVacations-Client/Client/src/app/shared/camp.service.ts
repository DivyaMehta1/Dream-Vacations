import { Guid } from 'guid-typescript';
import { Camp } from './camp.model';
import { Injectable } from '@angular/core';
import {  HttpClient, HttpHeaders} from "@angular/common/http";
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CampService {
  formData:Camp;
  
  readonly rootURL:"https://localhost:44385/";


  constructor(private http:HttpClient) { }
  getCampData(){

  }

  //Post a New Camp
  postCamp(formData:Camp):Observable<object>{
    let token = localStorage.getItem('userToken')
    console.log(token);
    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': 'bearer '+token});
//headers.append('Content-Type','application/json');

 return  this.http.post('https://localhost:44385/Api/Camps/AddCamp',formData,{ headers: headers});
  }
  //SearchCampsBetween
  searchCamps(checkinDate,checkoutDate,capacity):Observable<object>{
    
    return this.http.get('https://localhost:44385/Api/Camps/GetCampsBetween/'+checkinDate+'/'+checkoutDate+'/'+capacity);
    ;

  }//getAll Camps
  getCamps():Observable<object>{
      return this.http.get('https://localhost:44385/Api/Camps/GetAllCamps');
    //.toPromise().then(res=>this.list=res as Camp[]);
  }
  //get Camp by CampId
   getCamp(campId:string):Observable<Object>{
    return this.http.get('https://localhost:44385/Api/Camps/GetCamp/'+campId);
  }

  deleteCamp(campId):Observable<object> {
    let token = localStorage.getItem('userToken')
    console.log(token);
    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': 'bearer '+token});
    return this.http.delete('https://localhost:44385/Api/Camps/DeleteCamp/'+campId,{ headers: headers});
  }

  updateCamp(camp:Camp):Observable<object>
  {
    let token=localStorage.getItem('userToken')
    console.log(camp);
    console.log(token+ "dfdfdg");
    let headers = new HttpHeaders({
      'Authorization': 'bearer '+token});
     return this.http.put('https://localhost:44385/Api/Camps/UpdateCamp',camp,{ headers: headers});
  
  }
  
  }
