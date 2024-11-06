import type { Ship } from "@/types/Ship";

export default class ShipService
{
  baseUrl : string;

  constructor(baseUrl : string) {
    this.baseUrl = baseUrl + "/ship/";
  }

  async getShipDetail( shipId : string)
  {
     return this.get(shipId +  '/officers');
  }

  async getShipList( search : string)
  {
     return this.get('list?search=' + search);
  }

  private async get( url : string)
  {
    return fetch(this.baseUrl + url).then(response => response.json());
  }
}

export const shipService = new ShipService("https://localhost:7046");
