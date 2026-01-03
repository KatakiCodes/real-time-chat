import { NgModule } from "@angular/core";
import { Login } from "./login/login";
import { ComponentsModule } from "../components/components.module";
import { IntroduceLayout } from './layouts/introduce-layout/introduce-layout';
import { CreateAccount } from './create-account/create-account';

@NgModule({
    declarations: [Login,IntroduceLayout,CreateAccount, IntroduceLayout, CreateAccount],
    imports: [ComponentsModule],
    exports: [Login, IntroduceLayout, CreateAccount],
})
export class PagesModule {}