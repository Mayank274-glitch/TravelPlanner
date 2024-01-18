import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { ExploreComponent } from './explore/explore.component';
import { ItineraryComponent } from './itinerary/itinerary.component';
import { BudgetComponent } from './budget/budget.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'explore', component: ExploreComponent },
  { path: 'itinerary', component: ItineraryComponent },
  { path: 'budget', component: BudgetComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
