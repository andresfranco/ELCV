"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var country_list_component_1 = require("../country-list/country-list.component");
var country_detail_component_1 = require("../country-detail/country-detail.component");
var country_edit_component_1 = require("../country-edit/country-edit.component");
var CountryRoutes = /** @class */ (function () {
    function CountryRoutes() {
        this.routes = [
            { path: 'countries', component: country_list_component_1.CountryListComponent, data: { routeName: "countryList" } },
            { path: 'countries/:id', component: country_detail_component_1.CountryDetailComponent, data: { routeName: "countryDetail" } },
            { path: 'countries/:id/edit', component: country_edit_component_1.CountryEditComponent, data: { routeName: "countryEdit" } }
        ];
    }
    return CountryRoutes;
}());
exports.CountryRoutes = CountryRoutes;
//# sourceMappingURL=country-routes.js.map