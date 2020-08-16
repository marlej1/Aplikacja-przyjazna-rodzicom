export enum VenueType{
    Restaurant = 1,
    Playground,
    Toilet,
    Doctor,
    Pharmacy,
    PlayingField,
    ShoppingCenter,
    ThemePark 

}

export enum FacilityType{
    ChangingTable = 1,
    PlayArea,
    Playground,
    BabyChairs,
    MenuForKids,
    ChildCare

}

export class VenueTypeDisplay{
   static GetDisplayName(venueType: string):string{
        switch(venueType){
            case 'Doctor':
                return'Lekarz';
            case 'Pharmacy':
                return'Apteka';
            case 'Playground':
                return'Plac zabaw'
            case 'PlayingField':
                return'Boisko';
            case 'Restaurant':
                return'Restauracja';
            case 'ShoppingCenter':
                return'Galeria handlowa';
                case 'ThemePark':
                    return'Park rozrywki';    
                    case 'Toilet':
                        return'Publiczna toaleta';    
        }
    }

}

export class FacilityToDisplay{
    static GetDisplayName(venueType: string):string{
        switch(venueType){
            case 'ChangingTable':
                return'Przewijak';
            case 'PlayArea':
                return'Kącik zabawaw';
                case 'Playground':
                    return'Plac zabaw';
                    case 'BabyChairs':
                return'Stoliki dziecieęce';
                case 'MenuForKids':
                return'Menu dziecięce';

                case 'ChildCare':
                return'Opekun/ka dla dzecie';
        }

        // ChangingTable = 1,
        // PlayArea,
        // Playground,
        // BabyChairs,
        // MenuForKids,
        // ChildCare


}
}
