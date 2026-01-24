import { NgModule } from "@angular/core";
import { ButtonPrimary } from "./button-primary/button-primary";
import { ButtonPrimaryOutlined } from "./button-primary-outlined/button-primary-outlined";
import { ButtonDanger } from './button-danger/button-danger';

@NgModule({
    declarations: [ButtonPrimary,ButtonPrimaryOutlined, ButtonDanger],
    imports: [],
    exports: [ButtonPrimary,ButtonPrimaryOutlined, ButtonDanger]
})
export class ButtonsModule { }