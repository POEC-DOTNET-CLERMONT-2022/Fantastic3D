import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-main-menu',
  templateUrl: './main-menu.component.html',
  styleUrls: ['./main-menu.component.scss']
})
export class MainMenuComponent implements OnInit {
  static pathUsers: string = 'user';
  pathUsers: string = '/' + MainMenuComponent.pathUsers;
  static pathUserNew: string = 'user/new';
  urlUserNew: string = '/' + MainMenuComponent.pathUserNew;

  constructor() { }

  ngOnInit(): void {
  }

}
