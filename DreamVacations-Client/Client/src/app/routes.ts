import { AdminDashboardComponent } from './admin/admin-dashboard/admin-dashboard.component';
import { AuthGuard } from './home/auth/auth.guard';
import { Routes } from '@angular/router'
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './home/login/login.component';
import { AdminComponent } from './admin/admin.component';
import { ManageCampsComponent } from './admin/manage-camps/manage-camps.component';
import { EditCampComponent } from './admin/edit-camp/edit-camp.component';
import { DashboardComponent } from './home/dashboard/dashboard.component';
import { ConfirmationScreenComponent } from './home/bookings/confirmation-screen/confirmation-screen.component';
import { ManageBookingComponent } from './home/bookings/manage-booking/manage-booking.component';
import { ConfirmbookingComponent } from './home/bookings/confirmbooking/confirmbooking.component';
import { AddcampComponent } from './admin/addcamp/addcamp.component';


export const appRoutes: Routes = [
    { path: 'home', component: HomeComponent},
    {   path:'confirmationScreen/:referenceNumber/:message',
        component:HomeComponent,
        children:[{path:'',component:ConfirmationScreenComponent}]
    },
    {
        path:'dashboard',component:HomeComponent,
        children:[{path:'',component:DashboardComponent}]},
    {
        path:'admin', component : AdminComponent,
     
    },

    
    {
        path:'confirmBooking/:id/:checkin/:checkout/:capacity',component :HomeComponent,
        children:[{path:'',component:ConfirmbookingComponent}]
        
    },
    //children:[{path:'',component:ConfirmbookingComponent}]},
    
    {
        path:'managebookings',component :HomeComponent,
        children:[{path:'',component:ManageBookingComponent}]
        //component:ManageBookingComponent,canActivate:[AuthGuard],
       
    },
    {
        path:'editCamp/:id',component:AdminComponent,
        children:[{path:'',component:EditCampComponent}]
    },
    {
        path:'adminDashboard',component:AdminComponent,
        children:[{path:'',component:AdminDashboardComponent}]
    },
    {
        path:'addCamp',component :AdminComponent,
        children:[{path:'',component:AddcampComponent,canActivate:[AuthGuard]}]
        //component:ManageBookingComponent,canActivate:[AuthGuard],
       
    },
    {
        path: 'manageCamps', component: AdminComponent,
        children: [{ path: '', component: ManageCampsComponent ,canActivate:[AuthGuard]}]
    },
    {
        path: 'login', component: HomeComponent,
        children: [
            {
            path:'',component:LoginComponent,
       
    }]
},

    { path : '', redirectTo:'dashboard', pathMatch : 'full'}
    
];
