import { NgModule } from "@angular/core";
import { ConfirmationModal } from "./confirmation-modal/confirmation-modal";
import { ButtonsModule } from "../buttons/buttons.module";
import { InputsModule } from "../inputs/inputs.module";

@NgModule({
  declarations: [ConfirmationModal],
  imports: [ButtonsModule, InputsModule],
  exports: [ConfirmationModal]
})
export class ModalsModule {}