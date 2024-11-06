import { createMemoryHistory, createRouter } from 'vue-router'

import ShipDetails from './components/ShipDetails.vue'
import NoShip from './components/NoShip.vue'
import Manifest from './components/Manifest.vue'
import CrewList from './components/CrewList.vue'

const routes = [
  {
    name:       'ShipDetails',
    path:       '/ship/:shipId',
    component:  ShipDetails
  },
  {
    name:       'Manifest',
    path:       '/ship/manifest',
    component:  Manifest
  },
  {
    name:       'CrewList',
    path:       '/ship/crewlist',
    component:  CrewList
  },
]

export const router = createRouter({
  history: createMemoryHistory(),
  routes,
})
