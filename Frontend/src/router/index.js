import Vue from "vue";
import VueRouter from "vue-router";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    redirect: "/samples",
  },
  {
    path: "/samples",
    name: "Samples",
    component: () => import("../views/Samples.vue"),
  },
  {
    path: "/clients",
    name: "Clients",
    component: () => import("../views/Clients.vue"),
  },
  {
    path: "/add-client",
    name: "AddClient",
    component: () => import("../views/AddClient.vue"),
  },
  {
    path: "/add-sample",
    name: "AddSample",
    component: () => import("../views/AddSample.vue"),
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
