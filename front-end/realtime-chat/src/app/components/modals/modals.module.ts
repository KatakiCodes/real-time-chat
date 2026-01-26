import { NgModule } from "@angular/core";
import { ConfirmationModal } from "./confirmation-modal/confirmation-modal";
import { ButtonsModule } from "../buttons/buttons.module";
import { InputsModule } from "../inputs/inputs.module";
import { EditChat } from './edit-chat/edit-chat';

@NgModule({
  declarations: [ConfirmationModal, EditChat],
  imports: [ButtonsModule, InputsModule],
  exports: [ConfirmationModal, EditChat]
})
export class ModalsModule {}