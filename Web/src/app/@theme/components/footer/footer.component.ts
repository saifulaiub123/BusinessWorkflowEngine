import { Component } from '@angular/core';

@Component({
  selector: 'ngx-footer',
  styleUrls: ['./footer.component.scss'],
  template: `
    <span class="created-by" style="text-align: center;">
      All right reserved by <b><a href="#" target="_blank">XYZ</a></b> 2023
    </span>
  `,
})
export class FooterComponent {
}
