import { Component, OnInit } from '@angular/core';
import { ApiClientService } from 'src/services/api-client.service';

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

  private readonly fetchService: ApiClientService;
  public apiIsOnline: boolean = false;

  constructor(fetchService: ApiClientService) {
    this.fetchService = fetchService;
  }

  ngOnInit(): void {
    this.tryLoadApi();
  }

  tryLoadApi(): void {
    this.apiIsOnline = this.fetchService.getApiStatus();
  }

}
