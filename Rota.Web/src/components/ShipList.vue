<template>
  <div class="shiplist drilldown">
    <h2>Ships</h2>
    <ul>
      <li v-for="ship in ships" :key="ship.Id">
        <div>{{ ship.name }}</div>
        <div>In-flight</div>
      </li>
    </ul>
  </div>
</template>


<script>
  export default  {
    data() {
      return { ships: [] }
    },
    
    methods: {

        // GetShips
      getShips() {
          fetch('https://localhost:7046/Ship')
            .then(response => response.json())
            .then(data => this.ships = data )
          }
      },

    mounted() {
      this.getShips()
  }
}
</script>
