import {NgModule} from '@angular/core';
import {Http, HttpModule} from '@angular/http';
import {FormsModule} from '@angular/forms';
import {BrowserModule} from '@angular/platform-browser';
import {AppComponent} from './app';
import {routing, appRoutingProviders} from './app.routing';

import {AuthenticationService} from './services/auth.service';
import {AuthGuard} from './guards/auth.guard';
import {AuthenticationAwareHttp} from './services/authenticationAwareHttp';

import {LoginComponent} from './components/login/login.component';
import {LogoutComponent} from './components/logout/logout.component';
import {MenuComponent} from './components/menu/menu.component';
import {MenuItemComponent} from './components/menu/menu-item.component';
import {HeaderComponent} from './components/header/header.component';
import {SplitLayoutComponent} from './components/splitLayout/splitLayout.component';
import {DashboardComponent} from './components/dashboard/dashboard.component';
import {FolderListComponent} from './components/folderList/folderList.component';
import {FoldersMasterDetailComponent} from './components/foldersMasterDetail/foldersMasterDetail.component';
import {NoteDetailComponent} from './components/noteDetail/noteDetail.component';
import {LoadingIndicatorComponent} from './components/loadingIndicator/loadingIndicator.component';

@NgModule({
    imports: [BrowserModule, FormsModule, routing, HttpModule],
    declarations: [
        AppComponent, 
        MenuComponent, 
        MenuItemComponent, 
        HeaderComponent, 
        SplitLayoutComponent, 
        DashboardComponent, 
        FolderListComponent,
        FoldersMasterDetailComponent,
        NoteDetailComponent,
        LoadingIndicatorComponent,
        LoginComponent,
        LogoutComponent
    ],
    bootstrap: [AppComponent],
    providers: [
        AuthenticationService,
        AuthGuard,
        {provide: Http, useClass: AuthenticationAwareHttp},
        appRoutingProviders
    ]
})
export class AppModule {
}
