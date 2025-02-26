import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'search-bar',
  standalone: false,
  templateUrl: './search-bar.component.html',
  styleUrl: './search-bar.component.css'
})
export class SearchBarComponent {
  searchInput = {
    input : '',
    type : 'region'
  };

  @Output() searchEvent = new EventEmitter<any>();

  onSearch(): void {
    this.searchEvent.emit(this.searchInput);
  }

  public resetSearch(): void {
    this.searchInput.input = ''
    this.searchInput.type = 'region'
  }

}
