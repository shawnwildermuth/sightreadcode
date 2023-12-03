import { useRouter, RouteConfig } from 'vue-router';
import { HomeView, CodeView } from '@/views';

const routes: Array<RouteConfig> = [
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

const router = useRouter(routes);

export default router;
