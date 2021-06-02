import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '@core';

@Component({
  selector: 'app-workspace',
  templateUrl: './workspace.component.html',
  styleUrls: ['./workspace.component.scss']
})
export class WorkspaceComponent  {
  constructor(
    private readonly _authService: AuthService,
    private readonly _router: Router
  ) {

  }

  public logout() {
    this._authService.logout();
    this._router.navigate([""]);
  }
}
