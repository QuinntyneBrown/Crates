import { TestBed } from '@angular/core/testing';

import { PlaylistTrackService } from './playlist-track.service';

describe('PlaylistTrackService', () => {
  let service: PlaylistTrackService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PlaylistTrackService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
