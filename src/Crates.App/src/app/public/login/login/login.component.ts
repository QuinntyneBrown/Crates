import { Component, OnInit, OnDestroy, ViewEncapsulation } from '@angular/core';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';
import { AuthService } from '@core/auth.service';
import { RedirectService } from '@core/redirect.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: [
    './login.component.scss'
  ]
})
export class LoginComponent implements OnDestroy, OnInit {

  private readonly _destroyed$: Subject<void> = new Subject();

  constructor(
    private readonly _authService: AuthService,
    private readonly _redirectService: RedirectService
  ) { }

  ngOnInit() {
    this._authService.logout();
  }

  public handleTryToLogin($event: { username: string, password: string }) {
    this._authService
    .tryToLogin({
      username: $event.username,
      password: $event.password
    })
    .pipe(
      takeUntil(this._destroyed$),
    )
    .subscribe(
      () => {
        this._redirectService.redirectPreLogin();
      },
      errorResponse => {
        // handle error response
      }
    );
  }

  ngOnDestroy(): void {
    this._destroyed$.next();
    this._destroyed$.complete();
  }
}
