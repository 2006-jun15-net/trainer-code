import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import FoodItem from './models/food-item';

// in angular, there are three lifetimes
// for services
// (kind of like in ASP.NET, transient, scoped, singleton)

// 1. providedIn: 'root' - singleton
//        registering it for the whole app
// 2. (on a module:) providers: [ TheService ]
//        one instance of the service within that module.
// 3. (on a component:) providers: [ TheService ]
//        one instance for each instance of that component

// but whichever lifetime it has, it does need
//   Injectable decorator on it to make it
//   an angular service.

// sometimes/always? to use a service
// you need to import its module in the module you want
//    to use it from. e.g.: import HttpClientModule

@Injectable({
  providedIn: 'root',
})
export class KitchenApiService {
  private baseUrl = 'https://localhost:44350';

  constructor(private httpClient: HttpClient) {}

  getFridgeItems(): Promise<FoodItem[]> {
    return this.httpClient
      .get<FoodItem[]>(`${this.baseUrl}/api/fridge/items`)
      .toPromise();
  }
}
