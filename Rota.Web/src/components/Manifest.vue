<template>
  <div class="shipdetails">
    <h2>Manifest</h2>
    <div>
      <h3>Current Status</h3>
      <table>
        <tr>
          <td>Status</td>
          <td>In-Flight</td>
        </tr>
        <tr>
          <td>Location</td>
          <td>140.23x - 30.25y - 51.7z</td>
        </tr>
        <tr>
          <td>Origin</td>
          <td>Rigel 5</td>
        </tr>
        <tr>
          <td>Destination</td>
          <td>Terra</td>
        </tr>
        <tr>
          <td>Departed</td>
          <td>27 Oct 2512</td>
        </tr>
        <tr>
          <td>Expected Arrival</td>
          <td>6 Nov 2512</td>
        </tr>
      </table>
      <div class="routerlink">
        <RouterLink to="/ship/manifest">Manifest</RouterLink>
      </div>
      </div>
    <div>
      <img src="/src/assets/Pegasus.png" />
    </div>
    <div>
      <h3>General Info</h3>
      <table>
        <tbody>
          <tr><td>Class</td>          <td>{{ ship.ClassName }}</td></tr>
          <tr><td>Registration</td>   <td>{{ ship.Registration }}</td></tr>
          <tr><td>Year Built</td>     <td>{{ ship.YearBuilt }}</td></tr>
          <tr><td>Num Engines</td>    <td>{{ ship.NumEngines}}</td></tr>
          <tr><td>Max Warp</td>       <td>{{ ship.MaxWarp }}</td></tr>
          <tr><td>Pod Attachment</td> <td>{{ ship.PodAttachment }}</td></tr>
          <tr><td>Max Pods</td>       <td>{{ ship.MaxPods }}</td></tr>
        </tbody>
      </table>
    </div>
    <div class="drilldown">
      <h3>Crew</h3>
      <table>
        <tr v-for="crew in ship.Crew" :key="crew.CrewId">
          <td>{{ crew.Position }}</td>
          <td>{{ crew.Name }}</td>
        </tr>
      </table>
      <div class="routerlink">
        <RouterLink to="/ship/crewlist">Full Crew List</RouterLink>
      </div>
    </div>

  </div>
</template>

<script lang="ts">
  import type { Ship } from "@/types/Ship";

  export default {
    data() {
      return { ship: {} as Ship }
    },

    methods: {

      // GetShips
      getShip( id : string) {
        fetch('https://localhost:7046/Ship/' + id + '/officers')
          .then(response => response.json())
          .then(data => this.ship = data)
      }
    }
  }
</script>
