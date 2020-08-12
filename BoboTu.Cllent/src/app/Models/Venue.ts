import { Rating } from "./Rating"
import { Opinion } from "./Opinion"
import { VenueType, FacilityType } from "./Enums"

export class Venue{
     id:number 
      name :string       
      city :string
      street :string
      zipCode :string
     venueType: VenueType 
     ratings: Array<Rating>  
     opinions:   Array<Opinion>
      description: string 
     averageRating:number 
      webPage: string 
      emailAddress: string 
      facilities:Array<FacilityType>
       lattitude:number
       longitude:number;
     
}

