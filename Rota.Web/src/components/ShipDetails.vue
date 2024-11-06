<template>
  <div class="shipdetails">
    <h2>{{ ship.Name }}</h2>
    <div>
      <h3>Current Status</h3>
      <table>
        <tbody>
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
        </tbody>
      </table>
      <div class="routerlink">
        <router-link :to="{ name: 'Manifest' }">Manifest</router-link>
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
        <router-link :to="{ name: 'CrewList' }">Full Crew List</router-link>
      </div>
    </div>

  </div>
</template>

<script lang="ts">
  import type { Ship } from "@/types/Ship";
  import { shipService } from "@/services/ShipService"

  export default {
    data() {
      return { ship: {} as Ship }
    },

    methods: {

      // GetShips
      getShip( id : string) {

        if(id != null)
        {
          shipService.getShipDetail(id)
            .then(data =>
              {
                this.ship = data;
              })
        }
      }
    },

    created() {
      try {
        this.$watch(() => this.$route.params.shipId,
          (newId, oldId) => {
            try
            {
              this.getShip(this.$route.params.shipId);
            }
            catch(e)
            {
                alert('bob' + e);
            }
          })      
      }
      catch (e2) {
        alert("goodbye" + e2);
      }
    }
  }
</script>
