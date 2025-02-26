export interface NativeName {
  abbreviation: string;
  common: string;
  official: string;
}

export interface Name {
  common: string;
  official: string;
  nativeName: NativeName;
}

export interface CountryDto {
  name: Name;
  region: string;
  population: number;
  languages: string[];
  flag: string;
}
