import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CountryDto } from '../interfaces/country-dto.model';



const GETALL = "/api/Countries/GetAll";
const GETREGION = "/api/Countries/GetByRegion/";
const GETNAME = "/api/Countries/GetByName/";

@Injectable({
  providedIn: 'root'
})
export class CountryService {


  constructor(private http: HttpClient) {  }

  getAll(): Observable<CountryDto[]>{
    return this.http.get<CountryDto[]>(GETALL);
  }

  getByRegion(region: string): Observable<CountryDto[]>{
    return this.http.get<CountryDto[]>(GETREGION+region);
  }

  getByName(name: string): Observable<CountryDto[]>{
    return this.http.get<CountryDto[]>(GETNAME+name);
  }
}
