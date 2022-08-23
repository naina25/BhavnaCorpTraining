import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-localities',
  templateUrl: './localities.component.html',
  styleUrls: ['./localities.component.css']
})
export class LocalitiesComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  title ='Popular localities in and around Dehradun';
  localities: any[] = [

    { Locality: 'Rajpur', Places: '96 places' },

    { Locality: 'Jakhan', Places: '180 places' },

    { Locality: 'Hathibarkala Salwala', Places: '171 places' },

    { Locality: 'Chukkuwala', Places: '124 places' },

    { Locality: 'Karanpur', Places: '94 places' },

    { Locality: 'Ballupur', Places: '128 places' },
    { Locality: 'Paltan Bazaar', Places: '131 places' },
    { Locality: 'Balliwala', Places: '109 places' },

  ];
}
