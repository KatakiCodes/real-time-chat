import { NgModule } from "@angular/core";
import { ButtonPrimary } from "./button-primary/button-primary";
import { ButtonPrimaryOutlined } from "./button-primary-outlined/button-primary-outlined";

@NgModule({
    declarations: [ButtonPrimary,ButtonPrimaryOutlined],
    imports: [],
    exports: [ButtonPrimary,ButtonPrimaryOutlined]
})
export class ButtonsModule { }