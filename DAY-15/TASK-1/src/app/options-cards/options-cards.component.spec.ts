import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OptionsCardsComponent } from './options-cards.component';

describe('OptionsCardsComponent', () => {
  let component: OptionsCardsComponent;
  let fixture: ComponentFixture<OptionsCardsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OptionsCardsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OptionsCardsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
