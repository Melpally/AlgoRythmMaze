import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from './pages/account/auth/auth.component';

const routes: Routes = [
  { path: '', component: AuthComponent },
  { path: 'auth', loadChildren: () => import('./pages/account/auth/auth.module').then(m => m.AuthModule) }, // Default route for the landing page
  { path: '**', redirectTo: '' }, // Redirect undefined routes to the landing page
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
