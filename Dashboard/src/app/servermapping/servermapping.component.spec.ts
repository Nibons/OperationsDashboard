import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ServermappingComponent } from './servermapping.component'; //tells us many things

describe('ServermappingComponent', () => {
  let component: ServermappingComponent;
  let fixture: ComponentFixture<ServermappingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ServermappingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ServermappingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
