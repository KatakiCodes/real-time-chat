import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Login } from './pages/login/login';
import { CreateAccount } from './pages/create-account/create-account';

const routes: Routes = [
  { path: 'login', component: Login, pathMatch: 'full'},
  { path: 'new-account', component: CreateAccount, pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
