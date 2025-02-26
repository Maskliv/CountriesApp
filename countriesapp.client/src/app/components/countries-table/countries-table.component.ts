import { Component, Input } from '@angular/core';
import { CountryDto } from '../../interfaces/country-dto.model';

@Component({
  selector: 'countries-table',
  standalone: false,
  templateUrl: './countries-table.component.html',
  styleUrl: './countries-table.component.css'
})
export class CountriesTableComponent {
  @Input() countriesData:CountryDto[]= [];
  
}
