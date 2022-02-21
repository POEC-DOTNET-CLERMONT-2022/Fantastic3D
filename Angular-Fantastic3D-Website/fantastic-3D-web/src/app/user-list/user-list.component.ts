import { Component, OnInit } from '@angular/core';
import { IUserList } from 'src/models/i-user-list';
import { User } from 'src/models/user';
import { ApiClientService } from 'src/services/api-client.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {
  UserArray: User[] = [];
  iUserList: IUserList|undefined;
  offset: number = 0;
  constructor(public apiService: ApiClientService) { }

  ngOnInit(): void {
    this.apiService.getUsersByOffset(0)
    .subscribe((iUserList: IUserList) => {
      this.iUserList = iUserList;
      for(let result of iUserList.results) {
        this.apiService.getUserById(result.id).subscribe((User: User) => {
          this.UserArray.push(User);
          this.UserArray.sort((p1, p2) => p1.id - p2.id);
        });
        }
      });
  }
  callPage(page: number): void {}
}