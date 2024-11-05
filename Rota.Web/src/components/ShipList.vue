<template>
  <div class="shiplist drilldown">
    <h2>Ships</h2>
    <div>
      <input type="text" maxlength="20" @keyup="onFilterChange" v-model="prefix" ref="input" />
    </div>
    <div>
      <ul>
        <li v-for="ship in ships" :key="ship.Id" @click="setActiveShip(ship.Id)">
          <div>{{ ship.Name }}</div>
          <div>{{ ship.Status }}</div>
        </li>
      </ul>
    </div>
  </div>
</template>


<script lang="ts">
  import type { Ship } from "@/types/Ship";

  export default  {
    data() {
      return {
        ships: [] as Ship[],
        currentShip: "",
        prefix: ""
      };
    },
    
    methods: {

        // GetShips
      getShips() {
        fetch('https://localhost:7046/ship/list?search=' + this.prefix)
            .then(response => response.json())
            .then(data => this.ships = data )
          },

      setActiveShip(idShip: string) {
        this.currentShip = idShip;
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
