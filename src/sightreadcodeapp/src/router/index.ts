import { createRouter, createWebHistory } from 'vue-router';
import HomeView from "@/views/HomeView.vue";
import CodeView from "@/views/CodeView.vue";

const routes = [
  // Define your routes here
  {
    path: '/',
    name: 'Home',
    component: HomeView

  },
  {
    path: '/code',
    name: 'Code',
    component: CodeView,
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes
});

export default router;
