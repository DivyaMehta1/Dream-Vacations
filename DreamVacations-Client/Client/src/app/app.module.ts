import { NgxPaginationModule } from 'ngx-pagination';
import { UserService } from './shared/user.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {  HttpClientModule} from "@angular/common/http";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { RouterModule } from "@angular/router";
import { AppComponent } from './app.component';
import { FormsModule} from "@angular/forms";
import { CampService } from './shared/camp.service';
import { LoginComponent } from './home/login/login.component';
import { ToastrModule } from "ngx-toastr";
import { HomeComponent } from './home/home.component';
import { appRoutes } from './routes';
import { AuthGuard } from './home/auth/auth.guard';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AdminComponent } from './admin/admin.component';
import { ManageCampsComponent } from './admin/manage-camps/manage-camps.component';
import { AdminDashboardComponent } from './admin/admin-dashboard/admin-dashboard.component';
import { EditCampComponent } from './admin/edit-camp/edit-camp.component';
import { DashboardComponent } from './home/dashboard/dashboard.component';
import { AddcampComponent } from './admin/addcamp/addcamp.component';
import { BookingsComponent } from './home/bookings/bookings.component';
import { ManageBookingComponent } from './home/bookings/manage-booking/manage-booking.component';
import { ConfirmbookingComponent } from './home/bookings/confirmbooking/confirmbooking.component';
import { ConfirmationScreenComponent } from './home/bookings/confirmation-screen/confirmation-screen.component';
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    BookingsComponent,
    ManageBookingComponent,
    ConfirmbookingComponent,
    AdminComponent,
    DashboardComponent,
    ManageCampsComponent,
    AdminDashboardComponent,
    ConfirmationScreenComponent,
    EditCampComponent,
    AddcampComponent,   
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule,
    RouterModule.forRoot(appRoutes),
    //NgbModule,
    NgxPaginationModule,
    NgbModule
    
    
    
  ],
  providers: [CampService,UserService,AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
