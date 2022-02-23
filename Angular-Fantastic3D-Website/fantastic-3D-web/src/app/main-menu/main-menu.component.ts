import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-main-menu',
  templateUrl: './main-menu.component.html',
  styleUrls: ['./main-menu.component.scss']
})
export class MainMenuComponent implements OnInit {
  static pathUserList: string = 'user';
  urlUserList: string = '/' + MainMenuComponent.pathUserList;
  static pathUserNew: string = 'user/new';
  urlUserNew: string = '/' + MainMenuComponent.pathUserNew;
  static pathUserForm: string = 'user';
  urlUserForm: string = '/' + MainMenuComponent.pathUserForm;

  constructor() { }

  ngOnInit(): void {
  }

}
