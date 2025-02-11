import { Routes } from '@angular/router';
import { LandingComponent } from './pages/landing/landing.component';
import { authGuard } from './core/guards/auth.guard';
import { MainComponent } from './pages/main/main/main.component';

export const routes: Routes = [
    { path: '', component: LandingComponent },
    {
        path: 'auth',
        loadChildren: () => import('./pages/auth/auth.module').then(m => m.AuthModule),

    },
    {
        path: 'main',
        loadChildren: () => import('./pages/main/main.module').then((m) => m.MainModule),
        canMatch: [authGuard],
        canActivate: [authGuard]
    },
    { path: '**', redirectTo: '' }
];
