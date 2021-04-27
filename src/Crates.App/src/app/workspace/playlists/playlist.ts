import { Track } from "../tracks/track";

export type Playlist = {
    playlistId: string;
    created: string;
    released: string;
    tracks: Track[];
    spotify: string;
    coverArtDigitalAssetId: string;
};
