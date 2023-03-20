
import { Component, OnDestroy, OnInit } from '@angular/core';
import { AnalyticsService } from './@core/utils';
import { InitUserService } from './@theme/services/init-user.service';
import { Subject } from 'rxjs';
import { NbDateTimePickerComponent } from '@nebular/theme';

@Component({
  selector: 'ngx-app',
  template: '<router-outlet></router-outlet>',
})
export class AppComponent implements OnInit, OnDestroy {

  private destroy$: Subject<void> = new Subject<void>();

  constructor(private analytics: AnalyticsService,
              private initUserService: InitUserService
              ) {
              this.initUser();
              NbDateTimePickerComponent.prototype.ngOnInit = function () {
                this.format = this.format || this.buildTimeFormat();
                this.init$.next();
              };
  }

  ngOnInit(): void {
    this.analytics.trackPageViews();
  }

  initUser() {
    // this.initUserService.initCurrentUser()
    //   .pipe(
    //     takeUntil(this.destroy$),
    //   )
    //   .subscribe();
    this.initUserService.initCurrentUser();
  }

  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
