import type { CrewMember } from "@/types/CrewMember";

export type Ship = 
{
  Id:                 string;              
  Name:               string;                 
  ClassName:          string;      
  Registration:       string;         
  YearBuilt:          number;            
  Length:             number;               
  Width:              number;                
  Height:             number;               
  NumEngines:         number;           
  MaxWarp:            number;              
  PodAttachment:      string;        
  MaxPods:            number;              
  Status:             string;              

  Crew:               CrewMember[];
}
