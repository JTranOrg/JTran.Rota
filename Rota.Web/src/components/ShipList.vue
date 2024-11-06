<template>
  <div class="shiplist drilldown">
    <h2>Ships</h2>
    <div>
      <input type="text" maxlength="20" @keyup="onFilterChange" v-model="prefix" ref="input" />
    </div>
    <div>
      <ul>
        <li v-for="ship in ships" :key="ship.Id">
          <router-link :to="{ name: 'ShipDetails', params: {shipId: ship.Id} }">
            <div>{{ ship.Name }}</div>
            <div>{{ ship.Status }}</div>
          </router-link>
        </li>
      </ul>
    </div>
  </div>
</template>


<script lang="ts">
  import type { Ship } from "@/types/Ship";
  import { shipService } from "@/services/ShipService"

  export default  {
    data() {
      return {
        ships: [] as Ship[],
        prefix: ""
      };
    },
    
    methods: {

        // GetShips
      getShips() {
        shipService.getShipList(this.prefix)
                   .then(data => this.ships = data )
      },

      onFilterChange()
      {
        this.getShips()
      }
    },

    mounted() {
      this.getShips()
  }
}
</script>
