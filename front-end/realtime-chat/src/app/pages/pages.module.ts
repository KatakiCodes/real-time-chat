import { Component, NgModule } from "@angular/core";
import { Login } from "./login/login";
import { ComponentsModule } from "../components/components.module";

@NgModule({
    declarations: [Login],
    imports: [ComponentsModule],
    exports: [Login]
})
export class PagesModule {}