import { Component, OnInit } from '@angular/core';
import { KitchenApiService } from '../kitchen-api.service';
import FoodItem from '../models/food-item';

// other decorators: Directive, Input, Output

@Component({
  // identify (with a CSS selector) which elements in the page will be instances of this component
  selector: 'app-fridge',
  // component gets one template, either in separate file with a "relative URL path"
  templateUrl: './fridge.component.html',
  // ... or inline with "template:"
  // component can have multiple stylesheets, external or as a string here.
  // (angular supports cool things like SCSS)
  styleUrls: ['./fridge.component.css'],
  // ... or inline with "styles:"
  // define angular animations (based on CSS animations)
  animations: [],
  // services provided in component scope
  providers: []
})
export class FridgeComponent implements OnInit {
  fridgeItems: FoodItem[] | null = null;
  error: string | null = null;

  constructor(private kitchenApi: KitchenApiService) {}

  reloadFridgeItems(): Promise<void> {
    return this.kitchenApi
      .getFridgeItems()
      .then((items) => {
        this.error = null;
        this.fridgeItems = items;
      })
      .catch((error) => (this.error = error.toString()));
  }

  // angular components have a lifecycle - the objects are created and destroyed
  // as the user navigates through the app

  // that lifecycle has hooks that you can put code on
  // the most common one is on init -

  // ngOnInit runs after angular has wired up this object to the data binding
  // in the DOM based on its template.

  // the constructor is just for setup that doesn't relate to the template
  //  (e.g. dependency injection)
  // ngOnInit is for the stuff that does.
  ngOnInit(): void {
    this.reloadFridgeItems().then();
  }

  // this simplistic way of storing the state of the component in fields
  // works, but has some disadvantages compared to the observable-based reactive style
  // adopted in the documentation / tour of heroes template.
}
