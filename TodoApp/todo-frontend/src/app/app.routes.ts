import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { TodoListComponent } from './components/todo-list/todo-list.component';
import { CategoryListComponent } from './components/categoty/category.component';

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'tasks', component: TodoListComponent },
  { path: 'categories', component: CategoryListComponent },
  { path: '', redirectTo: '/login', pathMatch: 'full' } 
];