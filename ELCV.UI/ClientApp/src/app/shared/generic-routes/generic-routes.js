"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var GenericRoutes = /** @class */ (function () {
    function GenericRoutes() {
    }
    GenericRoutes.prototype.getRoutesbyRouteName = function (routes) {
        var routeNames = {};
        routes.forEach(function (eachRoute) {
            if (eachRoute.data && eachRoute.data.routeName) {
                routeNames[eachRoute.data.routeName] = eachRoute.path;
            }
        });
        return routeNames;
    };
    return GenericRoutes;
}());
exports.GenericRoutes = GenericRoutes;
//# sourceMappingURL=generic-routes.js.map