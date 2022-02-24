import { Component, OnInit } from '@angular/core';
import { User } from "src/models/user";
import { ApiClientService } from 'src/services/api-client.service';
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss']
})
export class UserFormComponent implements OnInit {

  user: User;
  private readonly activatedRoute: ActivatedRoute;
  private readonly userService: ApiClientService;
  constructor(activatedRoute: ActivatedRoute, userService: ApiClientService) {
    this.activatedRoute = activatedRoute;
    this.userService = userService;
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
    console.log(this.user);
    if (this.user.id == 0) {
      this.userService.postUser(this.user).subscribe((newUser: User) => console.log(newUser));
    }
    else {
      this.userService.updateUserById(this.user.id, this.user).subscribe((newUser: User) => console.log(newUser));
    }
  }
  onDelete(): void {
    this.userService.deleteUserById(this.user.id);
  }

}

