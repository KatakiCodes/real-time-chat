import { NgModule } from "@angular/core";
import { ButtonsModule } from "./buttons/buttons.module";
import { InputsModule } from "./inputs/inputs.module";
import { SideBar } from './side-bar/side-bar';


@NgModule({
    declarations: [
    SideBar
  ],
    imports: [ButtonsModule,InputsModule],
    exports: [ButtonsModule,InputsModule,SideBar],
})
export class ComponentsModule {}