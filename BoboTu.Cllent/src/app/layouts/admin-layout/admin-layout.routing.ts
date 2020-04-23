import { Routes } from '@angular/router';

import { MainPageComponent } from 'app/main-page/main-page.component';

export const AdminLayoutRoutes: Routes = [

    { path: 'main',      component: MainPageComponent },  
    { path: '*',           component: MainPageComponent },

 
];
