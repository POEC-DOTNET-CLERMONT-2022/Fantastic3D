import { Component, OnInit } from '@angular/core';
import { User } from "src/models/user";
import { ApiClientService } from 'src/services/api-client.service';
import { ActivatedRoute, Router } from "@angular/router";
import { MainMenuComponent } from '../main-menu/main-menu.component';
import { DialogService } from 'src/services/dialog.service';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss']
})
export class UserFormComponent implements OnInit {

  private readonly router: Router;
  private readonly activatedRoute: ActivatedRoute;
  private readonly userService: ApiClientService;
  private readonly dialog: DialogService;
  user: User;


  constructor(router: Router, activatedRoute: ActivatedRoute, userService: ApiClientService, dialog: DialogService) {
    this.router = router;
    this.activatedRoute = activatedRoute;
    this.userService = userService;
    this.dialog = dialog;
    this.user = new User();
  }
  roles = [
    { id: 1, name: "Basic" },
    { id: 2, name: "Premium" },
    { id: 9, name: "Admin" }
  ];

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((param) => {
      this.userService.getUserById(param['userId']).subscribe((user: User) => {
        this.user = user;
      });
    });
  }

  onSubmit(): void {
    var actionConfirmed: boolean = true;
    if (this.user.id == 0) {
      this.userService.postUser(this.user).subscribe((newUser: User) => console.log(newUser));
    }
    else {

      this.dialog.confirm('Voulez-vous vraiment mettre à jour ' + this.user.username + ' ?').subscribe((response: boolean) => actionConfirmed = response);
      this.userService.updateUserById(this.user.id, this.user).subscribe((newUser: User) => console.log(newUser));
    }
    if (actionConfirmed) {
      this.router.navigate(['user']);
    }
  }
  onDelete(): void {
    var suppressionConfirmed: boolean = false;
    this.dialog.confirm('Voulez-vous vraiment supprimer ' + this.user.username + ' ?').subscribe((response: boolean) => suppressionConfirmed = response);
    if (suppressionConfirmed) {
      this.userService.deleteUserById(this.user.id);
      this.router.navigate(['user']);
    }
  }

}

