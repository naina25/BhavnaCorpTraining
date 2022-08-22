import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  addNavlinksStyles(){
    let cssstyles={
        'font-weight':'bold',
        'color':'#033196',
        'margin-left': '20px'
    }
    return cssstyles;
   }

}
