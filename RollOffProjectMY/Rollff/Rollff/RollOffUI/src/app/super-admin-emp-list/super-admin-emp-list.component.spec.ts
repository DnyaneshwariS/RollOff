import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SuperAdminEmpListComponent } from './super-admin-emp-list.component';

describe('SuperAdminEmpListComponent', () => {
  let component: SuperAdminEmpListComponent;
  let fixture: ComponentFixture<SuperAdminEmpListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SuperAdminEmpListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SuperAdminEmpListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
