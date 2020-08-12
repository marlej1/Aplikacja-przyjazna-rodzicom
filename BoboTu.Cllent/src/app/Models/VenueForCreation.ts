import { VenueType } from "./Enums"
import { Rating } from "./Rating"
import { Opinion } from "./Opinion"

export class VenueForCreation{
    Name :string       
    City :string
    Street :string
    ZipCode :string
   VenueType: VenueType 
   Rating:Rating  
   Opinion:   Opinion
    Description: string 
    WebPage: string 
    EmailAddress: string 
    Facilities:Array<number>
   
}