import { Component, OnInit, ViewChild } from '@angular/core';
import { CountryDto } from './interfaces/country-dto.model';
import { Observable } from 'rxjs';
import { CountryService } from './services/country.service';
import { SearchBarComponent } from './components/search-bar/search-bar.component';
import { HttpResponse, HttpStatusCode } from '@angular/common/http';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  result: boolean = false;
  countries: CountryDto[] = [];
  @ViewChild('searchComponent') searchComponent!:SearchBarComponent;

  constructor(private countryService: CountryService) {}

  ngOnInit() {
    this.getAll()
  }

  getAll(){
    this.countries = [];
    this.result = false;
    this.countryService.getAll().subscribe(
      (data) => {
        this.countries = data;
        this.countries.sort((a,b)=> a.name.common.localeCompare(b.name.common));
        this.result = true;
      },
      (error) => {
        this.handleHttpError(error);

      }
    );
  }

  getRegion(region: string){
    this.countryService.getByRegion(region).subscribe(
      (data) => {
        this.countries = data;
        this.countries.sort((a,b)=> a.name.common.localeCompare(b.name.common));
        this.result = true;
      },
      (error) => {
        this.handleHttpError(error);
      }
    );
  }

  getName(name: string){
    this.countryService.getByName(name).subscribe(
      (data) => {
        this.countries = data;
        this.countries.sort((a,b)=> a.name.common.localeCompare(b.name.common));
        this.result = true;
      },
      (error) => {
        this.handleHttpError(error);
      }
    );
  }

  handleSearch(searchInput: any) {
    //console.log('Buscando:', searchInput);
    this.countries = [];
    this.result = false;
    if (searchInput.type === 'region') {
      this.getRegion(searchInput.input)
    }
    else if (searchInput.type === 'name'){
      this.getName(searchInput.input);
    }
  }

  handleHttpError(error: any) {
    if (error.status === HttpStatusCode.NotFound) {
      this.result = true;
      return;
    }
    console.error('Error fetching countries:', error);
  }

  clearSearch() {
    this.searchComponent.resetSearch();
    this.getAll();
  }
}
