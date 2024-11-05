import { createMemoryHistory, createRouter } from 'vue-router'

import ShipDetails from './components/ShipDetails.vue'
import Manifest from './components/Manifest.vue'
import CrewList from './components/CrewList.vue'

const routes = [
  { path: '/', component: ShipDetails },
  { path: '/ship/manifest', component: Manifest },
  { path: '/ship/crewlist', component: CrewList },
]

export const router = createRouter({
  history: createMemoryHistory(),
  routes,
})
