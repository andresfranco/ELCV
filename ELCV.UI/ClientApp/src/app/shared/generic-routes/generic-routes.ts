import { Routes } from "@angular/router";

export class GenericRoutes {
 

  getRoutesbyRouteName(routes: Routes) {
    const routeNames = {};
    routes.forEach((eachRoute) => {
      if (eachRoute.data && eachRoute.data.routeName) {
        routeNames[eachRoute.data.routeName] = eachRoute.path;
      }
    });

    return routeNames;
  }
}
