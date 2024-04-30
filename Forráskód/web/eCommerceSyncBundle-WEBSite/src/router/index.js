//import router and  pages component
import { createRouter, createWebHistory } from 'vue-router';
import AppHome from '../components/AppHome.vue';
import AboutView from '../views/AboutView.vue';
import HelpView from '../views/HelpView.vue';
import DatabaseView from '../views/DatabaseView.vue';
import DownloadView from '../views/DownloadView.vue';
import DownloadOS from '../views/DownloadOS.vue';
import ReviewsView from '../views/ReviewsView.vue'
import AddReview from '../views/AddReview.vue'


//routing settings
const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'AppHome',
      component: AppHome
    },
    {
      path: '/AboutView',
      name: 'AboutView',
      component: AboutView
    },
    {
      path: '/HelpView',
      name: 'HelpView',
      component: HelpView
    },
    {
      path: '/DatabaseView',
      name: 'DatabaseView',
      component: DatabaseView
    },
    {
      path: '/DownloadView',
      name: 'DownloadView',
      component: DownloadView
    },
    {
      path: '/DownloadOS',
      name: 'DownloadOS',
      component: DownloadOS
    },
    {
      path: '/ReviewsView',
      name: 'ReviewsView',
      component: ReviewsView
    },
    {
      path: '/AddReview',
      name: 'AddReview',
      component: AddReview
    }
  ]
})

export default router
