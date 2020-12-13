import { Component, EventEmitter, OnInit, Output } from '@angular/core';

import { COUNTRIES } from 'src/assets/countries';
import { Country } from '../../models/shared.models';

@Component({
  selector: 'app-countries',
  templateUrl: './countries.component.html',
  styleUrls: ['./countries.component.css']
})
export class CountriesComponent implements OnInit {

  @Output() countryChanged = new EventEmitter<string>();

  countries: Country[] = COUNTRIES;

  constructor() { }

  ngOnInit(): void {
  }

  public onChange(event: string): void {
    this.countryChanged.emit(event);
  }
}
