import { NgModule } from "@angular/core";
import { ButtonsModule } from "./buttons/buttons.module";
import { InputsModule } from "./inputs/inputs.module";


@NgModule({
    declarations: [],
    imports: [ButtonsModule,InputsModule],
    exports: [ButtonsModule,InputsModule]
})
export class ComponentsModule {}