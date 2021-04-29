import { Artist } from "../artists/artist";
import { Playlist } from "../playlists/playlist";

export type Track = {
    trackId:string;
    name: string;
    artists: Artist[];
    artistName: string;
    albumName: string;
    playlists: Playlist[];
    spotify: string;
    appleMusic: string;
    coverArtDigitalAssetId: string;
};
