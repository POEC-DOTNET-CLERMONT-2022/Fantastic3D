import { Component, OnInit } from '@angular/core';
import { ApiClientService } from 'src/services/api-client.service';

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
