import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageCampsComponent } from './manage-camps.component';

describe('ManageCampsComponent', () => {
  let component: ManageCampsComponent;
  let fixture: ComponentFixture<ManageCampsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManageCampsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManageCampsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
