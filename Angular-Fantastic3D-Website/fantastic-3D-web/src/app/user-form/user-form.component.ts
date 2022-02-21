import { Component } from '@angular/core';
import { User } from "src/models/user";
import { ApiClientService } from 'src/services/api-client.service';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss']
})
export class UserFormComponent {

  user : User = new User();
  constructor(private userService: ApiClientService) {
    
  }

  onSubmit(): void {
    console.log(this.user);
    this.userService.postUser(this.user).subscribe( (newUser : User) => console.log(newUser));
  }

}
