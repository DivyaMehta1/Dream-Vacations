import { User } from './user.model';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  formData:User;
  readonly rootUrl:'https://localhost:44385/';

  constructor(private http:HttpClient) {

   }
  
  registerUser(user : User){
        const body: User = {
          Username: user.Username,
          Password: user.Password,
          Id:user.Id,
           }
        return this.http.post( 'https://localhost:44385/Api/users/NewUser', body);
      } 
      userAuthentication(username, password) {
        var data = "username=" + username + "&password=" + password + "&grant_type=password";
        var reqHeader = new HttpHeaders({ 'Content-Type': 'application/x-www-urlencoded','No-Auth':'True' });
        return this.http.post('https://localhost:44385/token', data, { headers: reqHeader });
      } 
        
     
    }
