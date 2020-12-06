import { Component, OnInit } from '@angular/core';
import { AccountService } from './../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  public model: any = {};
  public loggedIn: boolean;

  constructor(private accontService: AccountService) {}

  ngOnInit(): void {}

  public login() {
    this.accontService.login(this.model).subscribe(
      (response) => {
        console.log(response);
        this.loggedIn = true;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  public logout() {
    this.loggedIn = false;
  }
}
