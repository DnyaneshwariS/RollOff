import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountEmpListComponent } from './account-emp-list.component';

describe('AccountEmpListComponent', () => {
  let component: AccountEmpListComponent;
  let fixture: ComponentFixture<AccountEmpListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AccountEmpListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AccountEmpListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
